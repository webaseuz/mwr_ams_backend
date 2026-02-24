using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Organizations;

public class OrganizationTypeSelectListItem<Tvalue> : SelectList<Tvalue>
{
    public string FullName { get; set; }
}
