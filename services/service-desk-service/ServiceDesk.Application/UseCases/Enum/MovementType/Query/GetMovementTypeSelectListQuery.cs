using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.MovementTypes;

public class GetMovementTypeSelectListQuery : IRequest<SelectList<int>>
{ }