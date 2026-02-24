using MediatR;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class GetCitizenshipQuery :
    IRequest<CitizenshipDto>
{ }
