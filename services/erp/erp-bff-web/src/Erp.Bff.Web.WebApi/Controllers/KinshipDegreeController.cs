using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web;

[ApiController]
[Route("[controller]/[action]")]
public class KinshipDegreeController : ControllerBase
{
    private readonly IKinshipDegree _kinshipDegree;

    public KinshipDegreeController(IKinshipDegree kinshipDegree)
    {
        _kinshipDegree = kinshipDegree;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<KinshipDegreeBriefDto>), 200)]
    public async Task<IActionResult> GetList([FromBody] KinshipDegreeGetListQuery query)
        => Ok(await _kinshipDegree.GetListAsync(query));


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(KinshipDegreeDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _kinshipDegree.GetByIdAsync(id));

    #endregion

    #region POST
    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _kinshipDegree.GetSecurityInfo());
    #endregion
}
