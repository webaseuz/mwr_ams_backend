namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public class UpdatePersonDataActionInputData
{
    public int PersonId { get; set; }
    
    public string Pinfl { get; set; } = default!;
    
    public string PassportNumber { get; set; } = default!;
    
    public DateTime BirthDate { get; set; }
}
