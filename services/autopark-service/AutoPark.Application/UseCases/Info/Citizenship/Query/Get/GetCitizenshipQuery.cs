using MediatR;

namespace AutoPark.Application.UseCases.Citizenships;

public class GetCitizenshipQuery :
    IRequest<CitizenshipDto>
{ }
