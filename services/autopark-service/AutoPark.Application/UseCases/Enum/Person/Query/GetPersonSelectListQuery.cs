using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.Persons;

public class GetPersonSelectListQuery :
    IRequest<SelectList<long>>
{
    public int? BranchId { get; set; }
}

