using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Banks;

public class GetBankSelectListQuery : IRequest<SelectList<int>>
{
}

