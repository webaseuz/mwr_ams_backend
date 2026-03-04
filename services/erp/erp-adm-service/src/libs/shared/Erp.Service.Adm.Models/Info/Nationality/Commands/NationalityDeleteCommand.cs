using MediatR;

namespace Erp.Service.Adm.Models;

public class NationalityDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
