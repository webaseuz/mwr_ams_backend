using OfficeOpenXml;

namespace Erp.Core.Extensions;

public static class ExportDataExtensions
{
    public static byte[] PrintAsExcelWithoutOrderNumber(System.IO.Stream TemplateStream, IEnumerable<dynamic> datalist, string reporttitle = null, DateTime? date = null)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelPackage pck = new ExcelPackage(TemplateStream);

        var importTemplateRowRange = pck.Workbook.Names["ImportTemplateRow"];
        var importPropertyRowRange = pck.Workbook.Names["ImportPropertyRow"];

        var ws = importTemplateRowRange.Worksheet;

        if (!string.IsNullOrWhiteSpace(reporttitle))
        {
            var titleRange = pck.Workbook.Names["report"];
            if (titleRange != null)
            {
                var titleCell = titleRange.Worksheet.Cells[titleRange.Address];
                titleCell.Value = reporttitle + titleCell.Value;
            }
        }

        //if (!string.IsNullOrWhiteSpace(reporttitle) && importTemplateRowRange.Worksheet.Names.Any(x => x.Name == "report"))
        //    importTemplateRowRange.Worksheet.Names["report"].Value = reporttitle;

        if (date.HasValue)
        {
            var dateRange = pck.Workbook.Names["Date"];
            if (dateRange != null)
            {
                var dateCell = dateRange.Worksheet.Cells[dateRange.Address];
                dateCell.Value = date.Value;
                dateCell.Style.Numberformat.Format = "dd.MM.yyyy";
            }
        }

        int TemplateRowIndex = importPropertyRowRange.Start.Row + 1;

        foreach (var currentitem in datalist)
        {
            if (currentitem is IDictionary<String, Object>)
            {
                var currentrow = (IDictionary<String, Object>)currentitem;
                ws.InsertRow(TemplateRowIndex, 1, importTemplateRowRange.Start.Row);
                try
                {
                    for (int j = importPropertyRowRange.Start.Column; j < importPropertyRowRange.End.Column + 1; j++)
                    {

                        string propertyname = ws.Cells[importPropertyRowRange.Start.Row, j]?.Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(propertyname) && currentrow.ContainsKey(propertyname))
                        {
                            try
                            {
                                ws.Cells[TemplateRowIndex, j].Value = currentrow[propertyname];
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Error reading property: " + propertyname + " " + ex.Message);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error reading row: " + Newtonsoft.Json.JsonConvert.SerializeObject(currentitem) + " " + ex.Message);

                }
            }
            else if (currentitem is Newtonsoft.Json.Linq.JObject)
            {
                var currentrow = (Newtonsoft.Json.Linq.JObject)currentitem;
                ws.InsertRow(TemplateRowIndex, 1, importTemplateRowRange.Start.Row);
                try
                {
                    for (int j = importPropertyRowRange.Start.Column; j < importPropertyRowRange.End.Column + 1; j++)
                    {

                        string propertyname = ws.Cells[importPropertyRowRange.Start.Row, j]?.Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(propertyname) && currentrow.ContainsKey(propertyname))
                        {
                            try
                            {
                                ws.Cells[TemplateRowIndex, j].Value = currentrow[propertyname].ToString();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Error reading property: " + propertyname + " " + ex.Message);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error reading row: " + Newtonsoft.Json.JsonConvert.SerializeObject(currentitem) + " " + ex.Message);

                }
            }
            else
            {
                ws.InsertRow(TemplateRowIndex, 1, importTemplateRowRange.Start.Row);
                var itemType = currentitem.GetType();

                for (int j = importPropertyRowRange.Start.Column; j < importPropertyRowRange.End.Column + 1; j++)
                {
                    string propertyname = ws.Cells[importPropertyRowRange.Start.Row, j]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(propertyname))
                    {
                        var property = itemType.GetProperty(propertyname);
                        if (property != null)
                        {
                            ws.Cells[TemplateRowIndex, j].Value = property.GetValue(currentitem);
                        }
                    }
                }
            }

            TemplateRowIndex++;
        }
        ws.DeleteRow(importTemplateRowRange.Start.Row, 2);


        byte[] res = null;
        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
        {//Сохранения
            pck.SaveAs(ms);
            pck.Dispose();
            res = ms.ToArray();
        }
        return res;
    }
    public static byte[] PrintAsExcel(System.IO.Stream TemplateStream, IEnumerable<dynamic> datalist, string reporttitle = null, DateTime? date = null)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelPackage pck = new ExcelPackage(TemplateStream);

        var importTemplateRowRange = pck.Workbook.Names["ImportTemplateRow"];
        var importPropertyRowRange = pck.Workbook.Names["ImportPropertyRow"];


        var ws = importTemplateRowRange.Worksheet;
        if (!string.IsNullOrWhiteSpace(reporttitle) && importTemplateRowRange.Worksheet.Names.Any(x => x.Name == "report"))
            importTemplateRowRange.Worksheet.Names["report"].Value = reporttitle;

        if (date.HasValue)
        {
            var dateRange = pck.Workbook.Names["Date"];
            if (dateRange != null)
            {
                var dateCell = dateRange.Worksheet.Cells[dateRange.Address];
                dateCell.Value = date.Value;
                dateCell.Style.Numberformat.Format = "dd.MM.yyyy";
            }
        }

        int TemplateRowIndex = importPropertyRowRange.Start.Row + 1;
        int i = 1;
        foreach (var currentitem in datalist)
        {
            if (currentitem is IDictionary<String, Object>)
            {
                var currentrow = (IDictionary<String, Object>)currentitem;
                ws.InsertRow(TemplateRowIndex, 1, importTemplateRowRange.Start.Row);
                try
                {
                    ws.Cells[TemplateRowIndex, 1].Value = i++;
                    for (int j = importPropertyRowRange.Start.Column; j < importPropertyRowRange.End.Column + 1; j++)
                    {

                        string propertyname = ws.Cells[importPropertyRowRange.Start.Row, j]?.Value?.ToString();

                        if (!string.IsNullOrWhiteSpace(propertyname) && currentrow.ContainsKey(propertyname))
                        {
                            try
                            {
                                var value = currentrow[propertyname];
                                DateTime parsedDate;

                                if (value != null && DateTime.TryParse(value.ToString(), out parsedDate))
                                {
                                    ws.Cells[TemplateRowIndex, j].Value = parsedDate;
                                    ws.Cells[TemplateRowIndex, j].Style.Numberformat.Format = "dd.MM.yyyy";
                                }
                                else
                                {
                                    ws.Cells[TemplateRowIndex, j].Value = value;
                                }

                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Error reading property: " + propertyname + " " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error reading row: " + Newtonsoft.Json.JsonConvert.SerializeObject(currentitem) + " " + ex.Message);

                }
            }
            else if (currentitem is Newtonsoft.Json.Linq.JObject)
            {
                var currentrow = (Newtonsoft.Json.Linq.JObject)currentitem;
                ws.InsertRow(TemplateRowIndex, 1, importTemplateRowRange.Start.Row);
                try
                {
                    ws.Cells[TemplateRowIndex, 1].Value = i++;
                    for (int j = importPropertyRowRange.Start.Column; j < importPropertyRowRange.End.Column + 1; j++)
                    {

                        string propertyname = ws.Cells[importPropertyRowRange.Start.Row, j]?.Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(propertyname) && currentrow.ContainsKey(propertyname))
                        {
                            try
                            {
                                ws.Cells[TemplateRowIndex, j].Value = currentrow[propertyname].ToString();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Error reading property: " + propertyname + " " + ex.Message);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error reading row: " + Newtonsoft.Json.JsonConvert.SerializeObject(currentitem) + " " + ex.Message);

                }
            }
            else
            {
                ws.InsertRow(TemplateRowIndex, 1, importTemplateRowRange.Start.Row);
                ws.Cells[TemplateRowIndex, 1].Value = i++;
                var itemType = currentitem.GetType();

                for (int j = importPropertyRowRange.Start.Column; j < importPropertyRowRange.End.Column + 1; j++)
                {
                    string propertyname = ws.Cells[importPropertyRowRange.Start.Row, j]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(propertyname))
                    {
                        var property = itemType.GetProperty(propertyname);
                        if (property != null)
                        {
                            var value = property.GetValue(currentitem);

                            if (value != null && value is DateTime)
                            {
                                ws.Cells[TemplateRowIndex, j].Value = (DateTime)value;
                                ws.Cells[TemplateRowIndex, j].Style.Numberformat.Format = "dd.MM.yyyy";
                            }
                            else
                            {
                                ws.Cells[TemplateRowIndex, j].Value = value;
                            }
                        }
                    }
                }
            }
            TemplateRowIndex++;
        }
        ws.DeleteRow(importTemplateRowRange.Start.Row, 2);

        byte[] res = null;
        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
        {//Сохранения
            pck.SaveAs(ms);
            pck.Dispose();
            res = ms.ToArray();
        }
        return res;

    }

    public static byte[] PrintAsExcelWithSummaryRow<T>(
    Stream templateStream,
    IEnumerable<T> datalist,
    T summaryRow,
    string reporttitle = null,
    DateTime? date = null)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var pck = new ExcelPackage(templateStream);

        var importTemplateRowRange = pck.Workbook.Names["ImportTemplateRow"];
        var importPropertyRowRange = pck.Workbook.Names["ImportPropertyRow"];
        var importSummaryTemplateRowRange = pck.Workbook.Names["ImportSummaryTemplateRow"];

        if (importTemplateRowRange == null)
            throw new Exception("Named range 'ImportTemplateRow' not found.");

        if (importPropertyRowRange == null)
            throw new Exception("Named range 'ImportPropertyRow' not found.");

        if (importSummaryTemplateRowRange == null)
            throw new Exception("Named range 'ImportSummaryTemplateRow' not found.");

        var ws = importTemplateRowRange.Worksheet;

        // Title (oddiy report title)
        if (!string.IsNullOrWhiteSpace(reporttitle))
        {
            var titleRange = pck.Workbook.Names["report"];
            if (titleRange != null)
            {
                ws.Cells[titleRange.Address].Value = reporttitle;
            }
        }

        // Sana
        if (date.HasValue)
        {
            var dateRange = pck.Workbook.Names["Date"];
            if (dateRange != null)
            {
                var dateCell = ws.Cells[dateRange.Address];
                dateCell.Value = date.Value;
                dateCell.Style.Numberformat.Format = "dd.MM.yyyy";
            }
        }

        int currentRowIndex = importSummaryTemplateRowRange.Start.Row;

        var type = typeof(T);

        // =========================
        // 1️⃣ SUMMARY ROW INSERT
        // =========================
        ws.InsertRow(currentRowIndex, 1, importSummaryTemplateRowRange.Start.Row);

        for (int j = importPropertyRowRange.Start.Column;
             j <= importPropertyRowRange.End.Column; j++)
        {
            string propertyName =
                ws.Cells[importPropertyRowRange.Start.Row, j]?.Value?.ToString();

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                var prop = type.GetProperty(propertyName);
                if (prop != null)
                {
                    var value = prop.GetValue(summaryRow);
                    ws.Cells[currentRowIndex, j].Value = value;
                }
            }
        }

        currentRowIndex++;
        int order = 1;

        // =========================
        // 2️⃣ DATA ROWS INSERT
        // =========================
        foreach (var item in datalist)
        {
            ws.InsertRow(currentRowIndex, 1, importTemplateRowRange.Start.Row);

            // 🔹 ORDER NUMBER (A ustuni = 1)
            ws.Cells[currentRowIndex, 1].Value = order++;

            for (int j = importPropertyRowRange.Start.Column;
                 j <= importPropertyRowRange.End.Column; j++)
            {
                // A ustunini skip qilamiz
                if (j == 1) continue;

                string propertyName =
                    ws.Cells[importPropertyRowRange.Start.Row, j]?.Value?.ToString();

                if (!string.IsNullOrWhiteSpace(propertyName))
                {
                    var prop = type.GetProperty(propertyName);
                    if (prop != null)
                    {
                        var value = prop.GetValue(item);
                        ws.Cells[currentRowIndex, j].Value = value;
                    }
                }
            }

            currentRowIndex++;
        }

        // Template qatorlarni o‘chirish
        ws.DeleteRow(importTemplateRowRange.Start.Row, 1);
        ws.DeleteRow(importSummaryTemplateRowRange.Start.Row, 1);
        ws.DeleteRow(importPropertyRowRange.Start.Row, 1);

        using var ms = new MemoryStream();
        pck.SaveAs(ms);
        return ms.ToArray();
    }
}
