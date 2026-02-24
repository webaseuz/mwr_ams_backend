using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ExecutorTypes;

public class GetExecutorTypeSelectListQuery : IRequest<SelectList<int>>
{
}

