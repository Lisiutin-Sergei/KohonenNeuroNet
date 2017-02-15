using KohonenNeuroNet.Utilities;
using KohonenNeuroNet.Utilities.Implementation.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.IO;

namespace KohonenNeuroNet.Tests
{
    /// <summary>
    /// Тесты для поставщика данных из таблиц Excel.
    /// </summary>
    [TestClass]
    public class ExcelReaderTest
    {
        /// <summary>
        /// Получить данные из тестового файла.
        /// </summary>
        [TestMethod]
        public void ShouldGetDataFromSampleFile()
        {
            var reader = new ExcelReader();
            var excelFileName = ConfigurationManager.AppSettings["SampleExcelFileName"];
            var excelFilePath = Path.Combine(CommonUtils.ResourcesDirectory, excelFileName);

            var data = reader.ReadFromFile(excelFilePath);
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Rows.Count > 0);
            Assert.IsTrue(data.Columns.Count > 0);
            Assert.IsNotNull(data.Rows[0][0]);
        }
    }
}
