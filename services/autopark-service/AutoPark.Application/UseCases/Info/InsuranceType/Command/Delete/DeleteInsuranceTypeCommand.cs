using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class DeleteInsuranceTypeCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
