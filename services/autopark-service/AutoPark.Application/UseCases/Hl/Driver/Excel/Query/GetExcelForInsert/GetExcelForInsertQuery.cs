using MediatR;

namespace AutoPark.Application.UseCases.Hl.Driver.Excel.Query.GetExcelForInsert;

public class GetExcelForInsertQuery :
    IRequest<MemoryStream>
{
}
