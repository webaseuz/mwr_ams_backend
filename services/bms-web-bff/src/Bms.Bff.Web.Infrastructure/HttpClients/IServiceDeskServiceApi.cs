using Refit;

namespace Bms.Bff.Web.Infrastructure.HttpClients;

/// <summary>
/// Refit interface for ServiceDesk service communication
/// </summary>
public interface IServiceDeskServiceApi
{
    // Ticket Management
    [Get("/api/tickets")]
    Task<ApiResponse<List<TicketDto>>> GetTicketsAsync(
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId,
        [Query] string status = null,
        [Query] string priority = null,
        [Query] int? page = null,
        [Query] int? pageSize = null);

    [Get("/api/tickets/{id}")]
    Task<ApiResponse<TicketDto>> GetTicketByIdAsync(
        int id,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    [Post("/api/tickets")]
    Task<ApiResponse<TicketDto>> CreateTicketAsync(
        [Body] CreateTicketRequest request,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    [Put("/api/tickets/{id}")]
    Task<ApiResponse<TicketDto>> UpdateTicketAsync(
        int id,
        [Body] UpdateTicketRequest request,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    [Post("/api/tickets/{id}/assign")]
    Task<ApiResponse<TicketDto>> AssignTicketAsync(
        int id,
        [Body] AssignTicketRequest request,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    [Post("/api/tickets/{id}/comments")]
    Task<ApiResponse<CommentDto>> AddCommentAsync(
        int id,
        [Body] AddCommentRequest request,
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    // Category Management
    [Get("/api/categories")]
    Task<ApiResponse<List<CategoryDto>>> GetCategoriesAsync(
        [Header("X-User-Id")] string userId,
        [Header("X-Correlation-Id")] string correlationId);

    // Health Check
    [Get("/health")]
    Task<ApiResponse<HealthCheckResponse>> GetHealthAsync();
}

// DTOs
public class TicketDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CreatedBy { get; set; }
    public string AssignedTo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public List<CommentDto> Comments { get; set; }
}

public class CreateTicketRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public int CategoryId { get; set; }
}

public class UpdateTicketRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
}

public class AssignTicketRequest
{
    public string AssignToUserId { get; set; }
    public string Notes { get; set; }
}

public class CommentDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class AddCommentRequest
{
    public string Text { get; set; }
}

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}