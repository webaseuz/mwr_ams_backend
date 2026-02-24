using MediatR;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class GetNationalityQuery :
    IRequest<NationalityDto>
{ }
