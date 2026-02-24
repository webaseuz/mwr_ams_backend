using MediatR;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class GetCitizenshipByIdQuery :
    IRequest<CitizenshipDto>
{
    public int Id { get; set; }
}
