using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.PlasticCardTypes;

public class GetPlasticCardTypeSelectListQuery :
    IRequest<SelectList<int>>
{
}
