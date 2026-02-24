using Bms.WEBASE.Translate;

namespace Bms.WEBASE.Authorization;

public class PermissionSubGroupDescription
{
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int PermissionGroupId { get; set; }
    public List<PermissionCodeDescription> PermissionCodes { get; set; } = new List<PermissionCodeDescription>();
    public List<TranslateDescription> Translates { get; set; } = new List<TranslateDescription>();
}

public class PermissionCodeDescription
{
    internal PermissionCodeDescription()
    {

    }

    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public List<TranslateDescription> Translates { get; set; } = new List<TranslateDescription>();
}

public class PermissionCodeHelper
{
    public static Dictionary<string, PermissionSubGroupDescription> GetDescriptions<TPermissionCodeEnum>()
        where TPermissionCodeEnum : struct
    {
        var dic = new Dictionary<string, PermissionSubGroupDescription>();

        foreach (var PermissionCodeField in typeof(TPermissionCodeEnum).GetFields().Where(a => a.IsStatic))
        {
            var PermissionCodeAttr = PermissionCodeField.GetCustomAttributes(typeof(PermissionCodeDescriptionAttribute), false).Cast<PermissionCodeDescriptionAttribute>().FirstOrDefault();

            if (PermissionCodeAttr == null)
                throw new Exception($"{nameof(PermissionCodeDescriptionAttribute)} not found in {typeof(TPermissionCodeEnum).Name}.{PermissionCodeField.Name}");

            var PermissionCodeDescription = new PermissionCodeDescription
            {
                Code = string.IsNullOrEmpty(PermissionCodeAttr.Code) ? PermissionCodeField.Name : PermissionCodeAttr.Code,
                ShortName = string.IsNullOrEmpty(PermissionCodeAttr.ShortName) ? PermissionCodeField.Name : PermissionCodeAttr.ShortName,
                FullName = string.IsNullOrEmpty(PermissionCodeAttr.FullName) ? PermissionCodeField.Name : PermissionCodeAttr.FullName,
            };
            PermissionCodeDescription.Translates.AddRange(TranslateHelper.GetDescriptions(PermissionCodeField));

            var PermissionSubGroupField = PermissionCodeAttr.PermissionSubGroup.GetType().GetField(PermissionCodeAttr.PermissionSubGroup.ToString());
            if (PermissionSubGroupField == null)
                throw new Exception($"Field not found in {PermissionCodeAttr.PermissionSubGroup.GetType().Name}.{PermissionCodeAttr.PermissionSubGroup}");

            var PermissionSubGroupAttr = PermissionSubGroupField.GetCustomAttributes(typeof(PermissionSubGroupDescriptionAttribute), false).Cast<PermissionSubGroupDescriptionAttribute>().FirstOrDefault();
            if (PermissionSubGroupAttr == null)
                throw new Exception($"{nameof(PermissionSubGroupDescriptionAttribute)} not found in {PermissionCodeAttr.PermissionSubGroup.GetType().Name}.{PermissionCodeAttr.PermissionSubGroup}");


            string PermissionSubGroupCode = string.IsNullOrEmpty(PermissionSubGroupAttr.Code) ? PermissionSubGroupField.Name : PermissionSubGroupAttr.Code;
            PermissionSubGroupDescription PermissionSubGroupDescription = null;

            if (dic.ContainsKey(PermissionSubGroupCode))
            {
                PermissionSubGroupDescription = dic[PermissionSubGroupCode];
            }
            else
            {
                PermissionSubGroupDescription = new PermissionSubGroupDescription
                {
                    Code = PermissionSubGroupCode,
                    ShortName = string.IsNullOrEmpty(PermissionSubGroupAttr.ShortName) ? PermissionSubGroupField.Name : PermissionSubGroupAttr.ShortName,
                    FullName = string.IsNullOrEmpty(PermissionSubGroupAttr.FullName) ? PermissionSubGroupField.Name : PermissionSubGroupAttr.FullName,
                    PermissionGroupId = PermissionSubGroupAttr.PermissionGroupId,
                };
                dic.Add(PermissionSubGroupCode, PermissionSubGroupDescription);
            }
            PermissionSubGroupDescription.Translates.AddRange(TranslateHelper.GetDescriptions(PermissionSubGroupField));
            PermissionSubGroupDescription.PermissionCodes.Add(PermissionCodeDescription);
        }

        return dic;
    }
}
