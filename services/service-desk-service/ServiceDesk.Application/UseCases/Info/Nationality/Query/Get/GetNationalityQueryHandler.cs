using MediatR;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class GetNationalityQueryHandler :
    IRequestHandler<GetNationalityQuery, NationalityDto>
{
    public Task<NationalityDto> Handle(
        GetNationalityQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new NationalityDto());
}
