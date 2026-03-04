using MediatR;

namespace Erp.Service.Adm.Models;

public record CustomJobDeleteCommand(long Id) : IRequest<bool>;
