using Erp.Core.Models;
using MediatR;

namespace Erp.Service.Adm.Models;
public class UserGetByIdQuery : IRequestGetByIdQuery<int, UserBriefDto>
{
    public int Id { get; set; }
    public bool IsDocChangeLog { get; set; }
}
