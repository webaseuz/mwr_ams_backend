using MediatR;

namespace AutoPark.Application.UseCases.Nationalities;

public class GetNationalityByIdQuery :
    IRequest<NationalityDto>
{
    public int Id { get; set; }
}
