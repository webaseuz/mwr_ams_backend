using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

/// <summary>
/// Person API client interface
/// </summary>
public interface IPersonApi
{
    /// <summary>
    /// Get list of persons
    /// </summary>
    [Post("/Person/GetList")]
    Task<WbPagedResult<PersonBriefDto>> GetListAsync([Body] PersonGetListQuery query);

    /// <summary>
    /// Create a new person
    /// </summary>
    [Post("/Person/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] PersonCreateCommand command);

    /// <summary>
    /// Update an existing person
    /// </summary>
    [Post("/Person/Update")]
    Task<bool> UpdateAsync([Body] PersonUpdateCommand command);


    [Post("/Person/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Person/Get")]
    Task<PersonDto> GetAsync();

    [Post("/Person/Get/{id}")]
    Task<PersonDto> GetByIdAsync(int id);

    [Post("/Person/PersonGetByPassportData")]
    Task<PersonDto> PersonGetByPassportDataAsync([Body] PersonGetByPassportDataQuery query);

    [Post("/Person/PersonGetPhotoFromGSP")]
    Task<string> PersonGetPhotoFromGSPAsync([Body] PersonGetPhotoFromGSPQuery query);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Person/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
