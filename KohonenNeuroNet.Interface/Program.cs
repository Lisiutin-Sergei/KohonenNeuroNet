using KohonenNeuroNet.Core.NetworkData;
using KohonenNeuroNet.Core.NeuralNetwork;
using KohonenNeuroNet.Utilities;
using KohonenNeuroNet.Utilities.Implementation.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KohonenNeuroNet.Interface
{
    static class Program
    {
        /// <summary>
        /// Получить набор входных данных для сети из файла.
        /// </summary>
        /// <param name="fileName">Имя файла.</param>
        /// <returns>Набор входных данных.</returns>
        public static NetworkDataSet GetDataSet(string fileName)
        {
            var reader = new ExcelReader();
            var excelFileName = fileName;
            var excelFilePath = Path.Combine(CommonUtils.ResourcesDirectory, excelFileName);
            var dataTable = reader.ReadFromFile(excelFilePath);
            var networkConverter = new NetworkDataSetConverter();
            var networkDataSet = networkConverter.Convert(dataTable);
            return networkDataSet;
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var trainingDataSet = GetDataSet("TrainingData.xlsx");
            var testingDataSet = GetDataSet("TestingData.xlsx");

            var epochCount = 6;
            var classesCount = 10;
            var network = new ClassicKohonenNetwork();
            network.Study(trainingDataSet, classesCount, epochCount);

            // Сформировать пустые кластеры
            var classes = new List<NetworkClaster>();
            for(int i = 0; i < classesCount; i++)
            {
                classes.Add(new NetworkClaster() { Number = i });
            }

            // Раскидать данные по кластерам
            foreach (var data in testingDataSet.Entities)
            {
                var result = network.GetNeuronWinner(data).Number;
                classes.First(c => c.Number == result).Entities.Add(data);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
