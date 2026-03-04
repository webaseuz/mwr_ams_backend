using MediatR;

namespace Erp.Service.Adm.Models;

public record CustomJobGetQuery() : IRequest<CustomJobDto>;
