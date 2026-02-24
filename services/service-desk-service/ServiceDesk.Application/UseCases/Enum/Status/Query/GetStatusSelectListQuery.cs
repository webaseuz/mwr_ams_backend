using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Enum;

public class GetStatusSelectListQuery : IRequest<SelectList<int>>
{
}
