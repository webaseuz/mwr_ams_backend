using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.Extensions.Hosting;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetExcelForInsertQueryHandler(
    IHostEnvironment hostEnvironment,
    ICultureHelper cultureHelper) : IRequestHandler<DriverGetExcelTemplateQuery, MemoryStream>
{
    private const string TEMPLATE_FILE_NAME = "DriverTemplate.xlsx";

    public Task<MemoryStream> Handle(DriverGetExcelTemplateQuery request, CancellationToken cancellationToken)
    {
        var cultureCode = cultureHelper.CurrentCulture.Code;

        var filePath = Path.Combine(hostEnvironment.ContentRootPath, "AppData", "Templates", cultureCode, TEMPLATE_FILE_NAME);

        if (!File.Exists(filePath))
            filePath = Path.Combine(hostEnvironment.ContentRootPath, "AppData", "Templates", "ru", TEMPLATE_FILE_NAME);

        var bytes = File.ReadAllBytes(filePath);
        return Task.FromResult(new MemoryStream(bytes));
    }
}
