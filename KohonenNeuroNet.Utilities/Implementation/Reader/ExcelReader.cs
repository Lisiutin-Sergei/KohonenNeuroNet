using KohonenNeuroNet.Utilities.Interface.Reader;
using System.Data;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace KohonenNeuroNet.Utilities.Implementation.Reader
{
    /// <summary>
    /// Поставщик данных - Excel.
    /// </summary>
    public class ExcelReader : IReader
    {
        /// <summary>
        /// Прочитать данные из файла.
        /// </summary>
        /// <param name="fileName">Имя файла/путь к файлу.</param>
        /// <returns>Таблица с данными.</returns>
        public DataTable ReadFromFile(string fileName)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;

            try
            {
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(fileName);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                // Создадим таблицу и колонки
                var table = new DataTable();
                for (int j = 1; j <= colCount; j++)
                {
                    table.Columns.Add(new DataColumn());
                }

                for (int i = 1; i <= rowCount; i++)
                {
                    var dataTableRow = table.NewRow();
                    for (int j = 1; j <= colCount; j++)
                    {
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                            dataTableRow[j - 1] = xlRange.Cells[i, j].Value2;
                        }
                    }
                    table.Rows.Add(dataTableRow);
                }

                return table;
            }
            finally
            {
                // Освободить ресурсы
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close();
                }
                if (xlWorkbook != null)
                {
                    xlApp.Quit();
                }
                Finalize(xlRange);
                Finalize(xlWorksheet);
                Finalize(xlWorkbook);
                Finalize(xlApp);
            }
        }

        /// <summary>
        /// Освободить ресурсы.
        /// </summary>
        /// <param name="o">Объект, держащий ресурс.</param>
        public void Finalize(object o)
        {
            if (o != null)
            {
                Marshal.ReleaseComObject(o);
            }
        }
    }
}
