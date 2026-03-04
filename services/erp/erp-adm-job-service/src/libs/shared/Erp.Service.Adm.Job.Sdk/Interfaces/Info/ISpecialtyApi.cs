using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

/// <summary>
/// Specialty API client interface
/// </summary>
public interface ISpecialtyApi
{
    [Post("/Specialty/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] SpecialtyCreateCommand command);

    [Post("/Specialty/Update")]
    Task<bool> UpdateAsync([Body] SpecialtyUpdateCommand command);

    [Post("/Specialty/Get")]
    Task<SpecialtyDto> GetByQueryAsync([Body] SpecialtyGetByIdQuery query);

    [Post("/Specialty/GetList")]
    Task<WbPagedResult<SpecialtyDto>> GetListAsync([Body] SpecialtyGetListQuery query);

    [Post("/Specialty/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Specialty/Get")]
    Task<SpecialtyDto> GetAsync();

    [Post("/Specialty/Get/{id}")]
    Task<SpecialtyDto> GetByIdAsync(int id);

    [Post("/Specialty/GetAsSelectList")]
    Task<WbSelectList<int, SpecialtySelectListDto>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Specialty/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
