using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases;

public class GetStateSelectListQuery : IRequest<SelectList<int>>
{
}
