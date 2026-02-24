using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases;

public class GetStateSelectListQuery : IRequest<SelectList<int>>
{
}
