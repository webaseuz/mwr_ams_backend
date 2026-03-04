namespace Erp.Service.Adm.Job.Models;

public class OrganizationReportDto
{
    /// <summary>
    /// Hudud yoki Tuman ID
    /// </summary>
    public int LocationId { get; set; }

    /// <summary>
    /// Hudud/Tuman nomi
    /// </summary>
    public string LocationName { get; set; }

    /// <summary>
    /// Jami tashkilotlar soni
    /// </summary>
    public int TotalOrganizations { get; set; }

    /// <summary>
    /// Ma'muriy boshqaruv muassasalari (OrganizationTypeId = 1)
    /// </summary>
    public int Adm.JobinManagementCount { get; set; }

    /// <summary>
    /// Ta'lim muassasalari va tashkilotlari (OrganizationTypeId = 2)
    /// </summary>
    public int EducationCount { get; set; }

    /// <summary>
    /// Teatr va sirk muassasalari (OrganizationTypeId = 26)
    /// </summary>
    public int TheaterCircusCount { get; set; }

    /// <summary>
    /// Kino muassasalari (OrganizationTypeId = 27)
    /// </summary>
    public int CinemaCount { get; set; }

    /// <summary>
    /// Konsert-tomosha muassasalari (OrganizationTypeId = 28)
    /// </summary>
    public int ConcertShowCount { get; set; }

    /// <summary>
    /// Madaniy faoliyat muassasalari (OrganizationTypeId = 29)
    /// </summary>
    public int CulturalActivityCount { get; set; }

    /// <summary>
    /// Madaniy-ma'rifiy, axborotlashtirish va kutubxona muassasalari (OrganizationTypeId = 30)
    /// </summary>
    public int LibraryInfoCount { get; set; }

    /// <summary>
    /// Filiallar va hududiy bo'linmalar (OrganizationTypeId = 31)
    /// </summary>
    public int BranchesCount { get; set; }
}
