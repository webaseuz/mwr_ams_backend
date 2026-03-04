using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class UserGetByIdQuery : IRequest<UserBriefDto>
{
    public int Id { get; set; }
}
