﻿using KohonenNeuroNet.Core.NetworkData;
using KohonenNeuroNet.Core.NeuralNetwork;
using KohonenNeuroNet.Utilities;
using KohonenNeuroNet.Utilities.Implementation.Reader;
using KohonenNeuroNet.Utilities.Interface.Reader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KohonenNeuroNet.Interface
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Утилита чтения данных из файла.
        /// </summary>
        private IReader _reader;

        /// <summary>
        /// Конвертер для получения входных данных нейросети из DataTable.
        /// </summary>
        private NetworkDataSetConverter _converter;

        /// <summary>
        /// Посредник для работы с данными в интерфейсе.
        /// </summary>
        private InterfaceMediator _interfaceMediator = new InterfaceMediator();

        /// <summary>
        /// Данные для обучения сети.
        /// </summary>
        private NetworkDataSet _learningDataSet;

        /// <summary>
        /// Данные для тестирования сети.
        /// </summary>
        private NetworkDataSet _testingDataSet;

        /// <summary>
        /// Кластеры, получающиеся в результате тестирования.
        /// </summary>
        public List<NetworkClaster> Clasters = new List<NetworkClaster>();

        /// <summary>
        /// Нейронная сеть.
        /// </summary>
        public AbstractNetwork NeuralNetwork { get; set; }

        public MainForm()
        {
            InitializeComponent();
            _reader = new ExcelReader();
            _converter = new NetworkDataSetConverter();
        }

        /// <summary>
        /// Загрузить данные из файла для обучения сети.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChooseLearningFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.InitialDirectory = CommonUtils.ResourcesDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using(new CursorHandler())
                    {
                        var excelFilePath = Path.Combine(CommonUtils.ResourcesDirectory, openFileDialog.FileName);
                        tbLearningFile.Text = excelFilePath;
                        var learningDataTable = _reader.ReadFromFile(excelFilePath);
                        _learningDataSet = _converter.Convert(learningDataTable);
                        _interfaceMediator.DrawDataIntoGrid(_learningDataSet, dgvInputLearningData);
                    }
                }
            }
        }

        /// <summary>
        /// Обучить нейронную сеть.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_LearnNetwork_Click(object sender, EventArgs e)
        {
            var epochCount = 6;
            int clastersCount = (int)tbClastersCount.Value;
            if (clastersCount < 1)
            {
                MessageBox.Show("Количество кластеров должно быть положительным", "Ошибка");
            }

            using (new CursorHandler())
            {
                NeuralNetwork = new ClassicKohonenNetwork();
                NeuralNetwork.Study(_learningDataSet, clastersCount, epochCount);

                // Сформировать пустые кластеры
                Clasters = new List<NetworkClaster>();
                for (int i = 0; i < clastersCount; i++)
                {
                    Clasters.Add(new NetworkClaster() { Number = i });
                }

                tabPanelMain.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// Выбрать файл для тестирования.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChooseTestingFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.InitialDirectory = CommonUtils.ResourcesDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (new CursorHandler())
                    {
                        var excelFilePath = Path.Combine(CommonUtils.ResourcesDirectory, openFileDialog.FileName);
                        tbTestingFile.Text = excelFilePath;
                        var dataTable = _reader.ReadFromFile(excelFilePath);
                        _testingDataSet = _converter.Convert(dataTable);
                        _interfaceMediator.DrawDataIntoGrid(_testingDataSet, dgvTesingData);
                    }
                }
            }
        }

        /// <summary>
        /// Тестировать сеть.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Test_Click(object sender, EventArgs e)
        {
            using (new CursorHandler())
            {
                foreach (var data in _testingDataSet.Entities)
                {
                    var result = NeuralNetwork.GetNeuronWinner(data).Number;
                    Clasters.First(c => c.Number == result).Entities.Add(data);
                }

                _interfaceMediator.DrawClasters(Clasters, dgvClasters);
                tabPanelMain.SelectedIndex = 2;
            }
        }

        /// <summary>
        /// При изменении выбора кластера отображать его элементы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_Clasters_SelectionChanged(object sender, EventArgs e)
        {
            // Очистить таблицу с элементами кластера
            _interfaceMediator.DrawDataIntoGrid(null, null, dgvClasterEntities);

            if (dgvClasters.CurrentRow == null || dgvClasters.CurrentRow.Index < 0)
            {
                return;
            }

            var selectedRow = dgvClasters.Rows[dgvClasters.CurrentRow.Index];
            if (!selectedRow.Selected)
            {
                return;
            }

            var clasterNumber = (int)selectedRow.Cells["ClasterNumber"].Value;
            var claster = Clasters.First(c => c.Number == clasterNumber);

            _interfaceMediator.DrawDataIntoGrid(claster.Entities, _testingDataSet.Attributes, dgvClasterEntities);
        }
    }
}
