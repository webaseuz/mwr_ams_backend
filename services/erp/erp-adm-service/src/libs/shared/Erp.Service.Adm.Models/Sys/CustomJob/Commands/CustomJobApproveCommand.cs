using Erp.Core.Constants;
using MediatR;

namespace Erp.Service.Adm.Models;

public record CustomJobApproveCommand(
    long Id,
    string Message,
    int StatusId = StatusIdConst.APPROVED) : IRequest<bool>;
