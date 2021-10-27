using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Helpers
{
    public class ExcelReader
    {
        public static IEnumerable<Dictionary<string, object>> ReadCodesFromFile(byte[] fileBytes)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var reader = ExcelReaderFactory.CreateReader(new MemoryStream(fileBytes)))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    UseColumnDataType = true,
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true,
                    }
                });
                List<IEnumerable<Dictionary<string, object>>> excelData = new List<IEnumerable<Dictionary<string, object>>>();
                foreach (var dataTable in result.Tables.Cast<DataTable>())
                {

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        var row = new Dictionary<string, object>();
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            //check for empty cells in mandatory fields
                            if ((!dataTable.Columns[j].ColumnName.Trim().Replace(" ", string.Empty).Equals("Description", StringComparison.OrdinalIgnoreCase)
                                && !dataTable.Columns[j].ColumnName.Trim().Replace(" ", string.Empty).Equals("DescriptionAr", StringComparison.OrdinalIgnoreCase)
                                && !dataTable.Columns[j].ColumnName.Trim().Replace(" ", string.Empty).Equals("ActiveTo", StringComparison.OrdinalIgnoreCase)
                                && !dataTable.Columns[j].ColumnName.Trim().Replace(" ", string.Empty).Equals("RequestReason", StringComparison.OrdinalIgnoreCase)
                                && !dataTable.Columns[j].ColumnName.Trim().Replace(" ", string.Empty).Equals("EGSRelatedCode", StringComparison.OrdinalIgnoreCase))
                                && string.IsNullOrWhiteSpace(dataTable.Rows[i][dataTable.Columns[j]].ToString()))
                            {
                                throw new Exception($"Invalid File Data: '{dataTable.Columns[j]}' is empty at row {i + 2}");
                            }
                            // handle Codes being read as decimal instead of int on serialization
                            var value = dataTable.Rows[i][dataTable.Columns[j]];
                            if (decimal.TryParse(value.ToString(), out decimal number))
                            {
                                value = decimal.ToInt32(number);
                            }
                            row.Add(dataTable.Columns[j].ColumnName.Trim().Replace(" ", string.Empty), value);
                        }
                        yield return row;
                    }
                }
            }
        }
    }
}
