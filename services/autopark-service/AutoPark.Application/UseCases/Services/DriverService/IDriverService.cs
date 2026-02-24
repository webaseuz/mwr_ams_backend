using Bms.WEBASE.Models;
namespace AutoPark.Application.UseCases.Drivers;

public interface IDriverService
{
    Task<IHaveId<int>> CreateAsync(CreateDriverCommand request, CancellationToken cancellationToken);
}
