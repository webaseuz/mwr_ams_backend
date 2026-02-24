namespace AutoPark.Application.Constants;

public class StaticFileConst
{
    public class ExcelTemplate
    {
        private static string FOLDER = "exceltemplates";
        public static string GetFileName(string culture, string fileName) => Path.Combine(FOLDER, culture, fileName);
    }

    public class Report
    {
        private static string FOLDER = "exceltemplates";

        public static readonly string DRIVERTEMPLATE = "DriverTemplate.xlsx";

        public static string GetFileName(string templateName) => Path.Combine(FOLDER, templateName);
    }
}
