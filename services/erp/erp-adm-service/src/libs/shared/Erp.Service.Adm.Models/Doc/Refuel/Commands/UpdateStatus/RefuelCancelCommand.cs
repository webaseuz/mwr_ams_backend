using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class RefuelCancelCommand : IRequest<WbHaveId<long>>
{
    public long Id { get; set; }
}
