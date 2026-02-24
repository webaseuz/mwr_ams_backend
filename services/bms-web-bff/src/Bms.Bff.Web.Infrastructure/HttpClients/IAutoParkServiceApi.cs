using Refit;

namespace Bms.Bff.Web.Infrastructure.HttpClients;

/// <summary>
/// Refit interface for AutoPark service communication
/// </summary>
public interface IAutoParkServiceApi
{
    // Vehicle Management
    [Get("/api/vehicles")]
    Task<ApiResponse<List<VehicleDto>>> GetVehiclesAsync(
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId,
        [Query] int? page = null,
        [Query] int? pageSize = null);

    [Get("/api/vehicles/{id}")]
    Task<ApiResponse<VehicleDto>> GetVehicleByIdAsync(
        int id,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    [Post("/api/vehicles")]
    Task<ApiResponse<VehicleDto>> CreateVehicleAsync(
        [Body] CreateVehicleRequest request,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    [Put("/api/vehicles/{id}")]
    Task<ApiResponse<VehicleDto>> UpdateVehicleAsync(
        int id,
        [Body] UpdateVehicleRequest request,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    [Delete("/api/vehicles/{id}")]
    Task<ApiResponse<bool>> DeleteVehicleAsync(
        int id,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    // Driver Management
    [Get("/api/drivers")]
    Task<ApiResponse<List<DriverDto>>> GetDriversAsync(
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId,
        [Query] int? page = null,
        [Query] int? pageSize = null);

    [Get("/api/drivers/{id}")]
    Task<ApiResponse<DriverDto>> GetDriverByIdAsync(
        int id,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    [Post("/api/drivers")]
    Task<ApiResponse<DriverDto>> CreateDriverAsync(
        [Body] CreateDriverRequest request,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    // Health Check
    [Get("/health")]
    Task<ApiResponse<HealthCheckResponse>> GetHealthAsync();
}

// DTOs
public class VehicleDto
{
    public int Id { get; set; }
    public string LicensePlate { get; set; }
    public string VIN { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateVehicleRequest
{
    public string LicensePlate { get; set; }
    public string VIN { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}

public class UpdateVehicleRequest
{
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Status { get; set; }
}

public class DriverDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string LicenseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateDriverRequest
{
    public string FullName { get; set; }
    public string LicenseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

public class HealthCheckResponse
{
    public string Status { get; set; }
    public Dictionary<string, object> Checks { get; set; }
}