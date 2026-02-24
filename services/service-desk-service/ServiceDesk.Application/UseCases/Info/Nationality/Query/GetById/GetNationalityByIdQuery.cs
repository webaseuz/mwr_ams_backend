using MediatR;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class GetNationalityByIdQuery :
    IRequest<NationalityDto>
{
    public int Id { get; set; }
}
