using MediatR;

namespace Erp.Service.Adm.Models;

public record CustomJobUpdateCommand(
    long Id,
    int JobTypeId,
    bool IsForceUpdate,
    string ExtendData,
    string Message,
    int? OrganizationId,
    int? RegionId,
    int? DistrictId) : IRequest<bool>;
