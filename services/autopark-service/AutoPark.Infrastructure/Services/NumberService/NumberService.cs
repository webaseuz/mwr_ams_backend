using AutoPark.Application;
using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AutoPark.Infrastructure;

public class NumberService : INumberService
{
    private readonly IWriteEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;

    public NumberService(
        IWriteEfCoreContext context,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _authService = authService;
    }
    public (int nextNumber, string docNumber) GetNext(string document)
        => GetNext(document, document, null);

    public (int nextNumber, string docNumber) GetNext(string document, INumberService.GetNextNumberKeyMapFunc keyMapper)
        => GetNext(document, document, keyMapper);

    public (int nextNumber, string docNumber) GetNext(string templateDocument, string numberDocument, INumberService.GetNextNumberKeyMapFunc keyMapper)
    {
        int nextNumber = 0;
        var template = _context.NumberTemplates
            .FirstOrDefault(t => t.Document == templateDocument);

        int financeYear = DateTime.Now.Year;

        // check if template is null
        if (template == null)
            return (nextNumber, string.Empty);
        else
            nextNumber = GetNextNumber(numberDocument, financeYear).GetAwaiter().GetResult();

        string result = Regex.Replace(template.Template, @"{[a-zA-Z]+}", match =>
        {
            var key = match.Value.TrimStart('{').TrimEnd('}');
            switch (key)
            {
                case "nextnumber":
                    return nextNumber.ToString();
                case "financeyear":
                    return financeYear.ToString();
                case "shortfinanceyear":
                    return financeYear.ToString().Substring(2);
                default:
                    if (keyMapper != null)
                        return keyMapper(key, nextNumber);
                    else
                        return "";
            }
        });

        SaveCurrentNumber(nextNumber, numberDocument, financeYear).GetAwaiter().GetResult();

        return (nextNumber, result);
    }

    private async Task<int> GetNextNumber(string document, int financeYear)
    {
        var entity = GetEntity();

        if (entity == null)
        {
            _context.NumberTemplates.Lock(a => a.Document == document);
            entity = GetEntity();

            if (entity == null)
            {
                var user = await _authService.GetUserAsync();
                int? branchId = user.BranchId;
                int? organizationId = user.OrganizationId;

                entity = new Number
                {
                    Document = document,
                    FinanceYear = financeYear,
                    BranchId = branchId,
                    OrganizationId = organizationId.Value//_authAppService.GetOrganizationAsync().Id
                };

                await _context.Numbers.AddAsync(entity);

                await _context.SaveChangesAsync(new CancellationToken());
            }
        }

        _context.Numbers.Lock(a => a.Id == entity.Id);
        entity = GetEntity();
        return entity.CurrentNumber + 1;

        Number GetEntity()
        {
            var ordganizationId = 1;// _authAppService.GetOrganizationAsync().Id;
            return _context.Numbers.FirstOrDefault(a => a.OrganizationId == ordganizationId && a.Document == document);
        }
        ;
    }

    private async Task SaveCurrentNumber(int number, string document, int financeYear)
    {
        var ordganizationId = 1;// _authAppService.GetOrganizationAsync().Id;
        var entity = await _context.Numbers.FirstOrDefaultAsync(a => a.OrganizationId == ordganizationId && a.Document == document);

        entity.CurrentNumber = number;

        await _context.SaveChangesAsync(new CancellationToken());
    }
}
