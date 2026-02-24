using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Banks;

public class GetBankSelectListQuery : IRequest<SelectList<int>>
{
}

