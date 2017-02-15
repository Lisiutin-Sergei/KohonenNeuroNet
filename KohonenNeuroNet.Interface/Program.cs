using KohonenNeuroNet.Core.NeuralNetwork;
using KohonenNeuroNet.Utilities;
using KohonenNeuroNet.Utilities.Implementation.Reader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KohonenNeuroNet.Interface
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            var reader = new ExcelReader();
            var excelFileName = "Data.xlsx";
            var excelFilePath = Path.Combine(CommonUtils.ResourcesDirectory, excelFileName);

            var dataTable = reader.ReadFromFile(excelFilePath);

            var networkConverter = new NetworkDataSetConverter();
            var networkDataSet = networkConverter.Convert(dataTable);

        }
    }
}
