namespace AutoPark.Application.UseCases;

public class PermissionGroupSelectListDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public IEnumerable<PermissionSubGroupSelectListDto> SubGroups { get; set; }
}

public class PermissionSubGroupSelectListDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public IEnumerable<PermissionSelectListDto> Permissions { get; set; }
}

public class PermissionSelectListDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
}
