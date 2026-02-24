using AutoPark.Application.UseCases.Persons;
using AutoPark.Domain.Constants;
using Bms.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using MiniExcelLibs;

namespace AutoPark.Application.UseCases.Drivers;

//public class InsertFromExcelQueryHandler :
//    IRequestHandler<InsertFromExcelQuery, DriverDto>
//{
//    private readonly IDriverService _driverService;
//    private readonly IWriteEfCoreContext _context;
//    public InsertFromExcelQueryHandler(IDriverService driverService, IWriteEfCoreContext context)
//    {
//        _driverService = driverService;
//        _context = context;
//    }

//    public async Task<DriverDto> Handle(
//    InsertFromExcelQuery request,
//    CancellationToken cancellationToken)
//    {

//        var canCommit = _context.Database.CurrentTransaction == null;
//        var transaction = _context.Database.CurrentTransaction ?? await _context.Database.BeginTransactionAsync(cancellationToken);

//        try
//        {
//            var dtos = GetListFromExcel(request.File);

//            foreach (var dto in dtos)
//                await _driverService.CreateAsync(dto, cancellationToken);

//            await transaction.CommitAsync();

//            return new DriverDto();
//        }
//        catch (Exception)
//        {
//            await transaction.RollbackAsync();
//            throw;
//        }
//        finally
//        {
//            await transaction.DisposeAsync();
//        }
//    }

//    public List<CreateDriverCommand> GetListFromExcel(IFormFile excelFile)
//    {
//        var drivers = new List<CreateDriverCommand>();

//        if (excelFile != null && excelFile.Length > 0)
//        {
//            using (var stream = excelFile.OpenReadStream())
//            {
//                var rows = stream.Query(useHeaderRow: true);
//                foreach (var row in rows)
//                {
//                    var rowDict = row as IDictionary<string, object>;
//                    var driver = new CreateDriverCommand();
//                    var document = new CreateDriverDocumentCommand
//                    {
//                        DocumentTypeId = DocumentTypeIdConst.DRIVER_LICENCE,
//                        DocumentNumber = rowDict["HAYDOVCHILIK GUVOHNOMASI RAQAMI"].ToString(),
//                        DocumentEndOn = DateTime.Parse(rowDict["HAYDOVCHILIK GUVOHNOMASI TUGASH SANASI"].ToString()),
//                    };

//                    var person = new CreatePersonCommand();

//                    person.Pinfl = rowDict["PINFL"].ToString();
//                    person.FirstName = rowDict["ISM"].ToString();
//                    person.LastName = rowDict["FAMILYA"].ToString();
//                    person.MiddleName = rowDict["OTASINING ISMI"].ToString();
//                    person.GenderId = int.Parse(rowDict["JINSI"].ToString());
//                    person.BirthOn = DateTime.Parse(rowDict["TUG'ILGAN SANA"].ToString());
//                    person.DocumentSeria = rowDict["PASSPORT SERIYA"].ToString();
//                    person.DocumentNumber = rowDict["PASSPORT RAQAM"].ToString();
//                    person.DocumentTypeId = DocumentTypeIdConst.PASSPORT;


//                    driver.OrganizationId = int.Parse(rowDict["TASHKILOT TARTIB RAQAMI"].ToString());
//                    var branchCode = rowDict["FILIAL TARTIB RAQAMI"].ToString();

//                    var branch = _context.Branches
//                        .Where(b => b.UniqueCode == branchCode)
//                        .FirstOrDefault();

//                    if (branch != null)
//                        if (branch.StateId == StateIdConst.ACTIVE)
//                            driver.BranchId = branch.Id;
//                        else
//                            throw new Exception($"{person.Pinfl} - ga berilgan branch Active emas!");
//                    else
//                        throw new Exception($"{person.Pinfl} - ga berilgan branch topilmadi!");


//                    if (document.DocumentNumber == null)
//                        continue;
//                    else
//                        driver.Documents.Add(document);

//                    if (person.Pinfl == null)
//                        throw new Exception("PINFL bo'sh bo'lishi mumkin emas!");
//                    else
//                        driver.Person = person;

//                    if (driver != null)
//                    {
//                        drivers.Add(driver);
//                    }
//                }
//            }
//        }

//        return drivers;
//    }
//}
