using AutoPark.Application.Constants;
using AutoPark.Application.Security;
using Bms.WEBASE.Helpers;
using Bms.WEBASE.Storage;
using MediatR;

namespace AutoPark.Application.UseCases.Hl.Driver.Excel.Query.GetExcelForInsert
{
    public class GetExcelForInsertQueryHandler :
    IRequestHandler<GetExcelForInsertQuery, MemoryStream>
    {
        private readonly IAsyncAppAuthService _authService;
        private readonly IStorageAsyncService _storageService;
        private readonly ICultureHelper _cultureHelper;

        public GetExcelForInsertQueryHandler(IAsyncAppAuthService authService, IStorageAsyncService storageService, ICultureHelper cultureHelper)
        {
            _authService = authService;
            _storageService = storageService;
            _cultureHelper = cultureHelper;
        }

        public async Task<MemoryStream> Handle(
            GetExcelForInsertQuery request,
            CancellationToken cancellationToken)
        {
            MemoryStream template = _storageService.GetStaticFile(StaticFileConst.ExcelTemplate.GetFileName(_cultureHelper.CurrentCulture.Code, StaticFileConst.Report.DRIVERTEMPLATE));

            return await Task.FromResult(template);
        }
    }
}
