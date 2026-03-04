using Erp.Core.Models;
using MediatR;

namespace Erp.Service.Adm.Models;

public class CustomJobGetByIdQuery : IRequestGetByIdQuery<long, CustomJobDto>
{
    public long Id { get; set; }
    public bool IsDocChangeLog { get; set; }
}
