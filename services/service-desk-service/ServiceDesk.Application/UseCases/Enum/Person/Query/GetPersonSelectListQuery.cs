using Bms.WEBASE.Models;
using MediatR;
namespace ServiceDesk.Application.UseCases.Persons;

public class GetPersonSelectListQuery :
    IRequest<SelectList<long>>
{
}

