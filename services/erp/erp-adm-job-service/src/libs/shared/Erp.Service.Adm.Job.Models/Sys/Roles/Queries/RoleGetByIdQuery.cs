using System.Text.Json.Serialization;
using Erp.Core.Models;
using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class RoleGetByIdQuery : IRequestGetByIdQuery<int, RoleDto>
{
    public int Id { get; set; }

    [JsonIgnore]
    public bool IsDocChangeLog { get; set; } = false;
}
