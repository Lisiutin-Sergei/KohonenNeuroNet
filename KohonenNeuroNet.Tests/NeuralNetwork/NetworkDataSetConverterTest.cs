using KohonenNeuroNet.NeuralNetwork.NetworkData;
using KohonenNeuroNet.Utilities;
using KohonenNeuroNet.Utilities.Implementation.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace KohonenNeuroNet.Tests
{
	/// <summary>
	/// Тесты для конвертера даннных в формат, с которым работает нейронная сеть.
	/// </summary>
	[TestClass]
    public class NetworkDataSetConverterTest
    {
        /// <summary>
        /// Должен конвертировать из DataTable.
        /// </summary>
        [TestMethod]
        public void ShouldConvertFromDataTable()
        {
            var reader = new ExcelReader();
            var excelFileName = "Sample.xlsx";
            var excelFilePath = Path.Combine(CommonUtils.ResourcesDirectory, excelFileName);

            // Получаем DataTable, заодно проверяем работу провайдера данных из Excel
            var dataTable = reader.ReadFromFile(excelFilePath);
            Assert.IsNotNull(dataTable);
            Assert.IsTrue(dataTable.Rows.Count > 0);
            Assert.IsTrue(dataTable.Columns.Count > 0);
            Assert.IsNotNull(dataTable.Rows[0][0]);

            // Проверяем конвертер
            var networkConverter = new NetworkDataSetConverter();
            var networkDataSet = networkConverter.Convert(dataTable);
            Assert.IsNotNull(networkDataSet);
            Assert.IsTrue(networkDataSet.Entities != null && networkDataSet.Entities.Any());
            Assert.IsTrue(networkDataSet.Attributes != null && networkDataSet.Attributes.Any());
        }
    }
}
