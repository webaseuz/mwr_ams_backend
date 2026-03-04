using MediatR;

namespace Erp.Service.Adm.Models;

public class DriverDocumentGetByIdQuery : IRequest<DriverDto>
{
    public int Id { get; set; }
}
