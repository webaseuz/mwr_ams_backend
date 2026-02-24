using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.PlasticCardTypes;

public class GetPlasticCardTypeSelectListQuery :
    IRequest<SelectList<int>>
{
}
