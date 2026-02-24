using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoPark.Application.UseCases.Drivers;

public class InsertFromExcelQuery :
    IRequest<DriverDto>
{
    public IFormFile File { get; set; }

    public InsertFromExcelQuery() { }
}
