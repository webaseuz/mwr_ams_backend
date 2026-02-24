using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class GetCitizenshipSelectListQuery :
	IRequest<SelectList<int>>
{
}
