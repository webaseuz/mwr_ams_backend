using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IDocumentStatusApi
{
    /// <summary>
    /// Get a paginated list of document status
    /// </summary>
    [Post("/DocumentStatus/GetList")]
    Task<WbPagedResult<DocumentStatusBriefDto>> GetListAsync([Body] DocumentStatusGetListQuery query);

    /// <summary>
    /// Get document status by query parameters
    /// </summary>
    [Post("/DocumentStatus/Get")]
    Task<DocumentStatusDto> GetAsync();

    /// <summary>
    /// Get a document status by ID
    /// </summary>
    [Post("/DocumentStatus/Get/{id}")]
    Task<DocumentStatusDto> GetAsync(int id);

    /// <summary>
    /// Get document statuses as select list
    /// </summary>
    [Post("/DocumentStatus/GetAsSelectList")]
    Task<WbSelectList<int>> GetAsSelectListAsync([Body] DocumentStatusSelectListQuery query);

    /// <summary>
    /// Create a new document status
    /// </summary>
    [Post("/DocumentStatus/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] DocumentStatusCreateCommand command);

    /// <summary>
    /// Update an existing document status
    /// </summary>
    [Post("/DocumentStatus/Update")]
    Task<bool> UpdateAsync([Body] DocumentStatusUpdateCommand command);

    /// <summary>
    /// Delete document status by ID
    /// </summary>
    [Post("/DocumentStatus/Delete/{id}")]
    Task<bool> DeleteAsync(int id);


    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/DocumentStatus/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
