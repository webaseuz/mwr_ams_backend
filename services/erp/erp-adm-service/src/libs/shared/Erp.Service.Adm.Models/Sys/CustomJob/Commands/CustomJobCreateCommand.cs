using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public record CustomJobCreateCommand(
    int JobTypeId,
    bool IsForceUpdate,
    string ExtendData,
    int? OrganizationId,
    int? RegionId,
    int? DistrictId) : IRequest<WbHaveId<long>>;
