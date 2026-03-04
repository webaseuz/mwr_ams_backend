namespace Erp.Core.Sdk.Models;

public class PersonAddressDto
{
    public int Id { get; set; }
    public int OwnerId { get; set; }

    public int? LivingCountryId { get; set; }
    public string LivingCountry { get; set; }
    public int? LivingRegionId { get; set; }
    public string LivingRegion { get; set; }
    public int? LivingDistrictId { get; set; }
    public string LivingDistrict { get; set; }
    public int? LivingMfyId { get; set; }
    public string LivingMfy { get; set; }
    public string LivingAddress { get; set; }
    public string LivingCadastre { get; set; }
    public DateTime? LivingRegistrationDate { get; set; }

    public bool IsTemporary { get; set; }
    public int? TemporaryResidenceTypeId { get; set; }
    public int? TemporaryCountryId { get; set; }    
    public string TemporaryCountry { get; set; }
    public int? TemporaryRegionId { get; set; }
    public string TemporaryRegion { get; set; }
    public int? TemporaryDistrictId { get; set; }
    public string TemporaryDistrict { get; set; }
    public int? TemporaryMfyId { get; set; }
    public string TemporaryMfy { get; set; }
    public string TemporaryAddress { get; set; }
    public string TemporaryCadastre { get; set; }
    public DateTime? TemporaryDateFrom { get; set; }
    public DateTime? TemporaryDateTill { get; set; }
}
