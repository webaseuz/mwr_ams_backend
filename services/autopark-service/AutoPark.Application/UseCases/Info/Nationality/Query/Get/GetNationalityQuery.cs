using MediatR;

namespace AutoPark.Application.UseCases.Nationalities;

public class GetNationalityQuery :
    IRequest<NationalityDto>
{ }
