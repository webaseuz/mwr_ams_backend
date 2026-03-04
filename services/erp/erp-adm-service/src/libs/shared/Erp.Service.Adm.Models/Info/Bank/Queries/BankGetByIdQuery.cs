using Erp.Core.Models;
using MediatR;

namespace Erp.Service.Adm.Models;
public class BankGetByIdQuery : IRequestGetByIdQuery<int, BankDto>
{
    public int Id { get; set; }
    public bool IsDocChangeLog { get; set; }
}
