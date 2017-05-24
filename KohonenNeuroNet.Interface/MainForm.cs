using KohonenNeuroNet.Core.Interface.Service;
using KohonenNeuroNet.Core.Model.Business;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.Interface.DI;
using KohonenNeuroNet.NeuralNetwork.NetworkData;
using KohonenNeuroNet.NeuralNetwork.NeuralNetwork;
using KohonenNeuroNet.Utilities;
using KohonenNeuroNet.Utilities.Implementation.Reader;
using KohonenNeuroNet.Utilities.Interface.Reader;
using System;
using System.Collections.Generic;
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
		private readonly IReader _reader;

		/// <summary>
		/// Сервис для работы с данными.
		/// </summary>
		private readonly INetworkService _networkService;

		/// <summary>
		/// Конвертер для получения входных данных нейросети из DataTable.
		/// </summary>
		private readonly NetworkDataSetConverter _converter;

		/// <summary>
		/// Посредник для работы с данными в интерфейсе.
		/// </summary>
		private readonly InterfaceMediator _interfaceMediator;

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
		public List<NetworkCluster> Clasters = new List<NetworkCluster>();

		/// <summary>
		/// Нейронная сеть.
		/// </summary>
		public readonly AbstractNetwork NeuralNetwork;

		private NetworkBase _networkBase;

		public MainForm(INetworkService networkService, IReader reader, AbstractNetwork network, int? networkId = null)
		{
			InitializeComponent();

			_reader = reader;
			_networkService = networkService;
			_converter = new NetworkDataSetConverter();
			_interfaceMediator = new InterfaceMediator();

			NeuralNetwork = network;
			NeuralNetwork.IterationCompleted += OnNetworkWeightsChanged;

			// При редактировании существующей сети скрыть обучение
			if (networkId > 0)
			{
				InitializeExistingNetwork(networkId ?? 0);
			}
		}

		/// <summary>
		/// Инициализировать существующую сеть.
		/// </summary>
		/// <param name="networkId">Идентификатор сети.</param>
		private void InitializeExistingNetwork(int networkId)
		{
			((Control)tabLearning).Enabled = false;
			tabPanelMain.SelectedIndex = 1;

			// Получить данные сети из базы
			var networkData = _networkService.GetNetworkData(networkId);
            _networkBase = networkData.Network;
            tbNetworkName.Text = _networkBase.Name;

            // Заполнить нейроны полученными из БД
            NeuralNetwork.Neurons = networkData.Neurons;
            NeuralNetwork.InputAttributes = networkData.InputAttributes;
            NeuralNetwork.Weights = networkData.Weights;
            
			// Сформировать пустые кластеры
			Clasters = NeuralNetwork.Neurons
				.Select(neuron => new NetworkCluster
				{
					Number = neuron.NeuronNumber
				})
				.ToList();

            var attributes = NeuralNetwork.InputAttributes.Select(e => new NetworkAttribute { Name = e.Name, OrderNumber = e.InputAttributeNumber }).ToList();
            _interfaceMediator.DrawNetworkWeights(NeuralNetwork, attributes, dgvWeights);
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
					using (new CursorHandler())
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
			int clastersCount = (int)tbClastersCount.Value;
			int iterationsCount = (int)tbIterationsCount.Value;
			if (clastersCount < 1)
			{
				MessageBox.Show("Количество кластеров должно быть положительным", "Ошибка");
				return;
			}
			if (iterationsCount < 1)
			{
				MessageBox.Show("Количество эпох обучения должно быть положительным", "Ошибка");
				return;
			}
			if (_learningDataSet == null || _learningDataSet.Entities == null || _learningDataSet.Entities.Count == 0 ||
				_learningDataSet.Attributes == null || _learningDataSet.Attributes.Count == 0)
			{
				MessageBox.Show("Выборка для обучения должна содержать хотя бы 1 сущность хотя бы с 1 параметром", "Ошибка");
				return;
			}

			using (new CursorHandler())
			{
				NeuralNetwork.Study(_learningDataSet, clastersCount, iterationsCount);

				// Сформировать пустые кластеры
				Clasters = NeuralNetwork.Neurons
					.Select(neuron => new NetworkCluster
					{
						Number = neuron.NeuronNumber
					})
					.ToList();

				tabPanelMain.SelectedIndex = 2;
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
			if (_testingDataSet == null || _testingDataSet.Entities == null || _testingDataSet.Entities.Count == 0 ||
				_testingDataSet.Attributes == null || _testingDataSet.Attributes.Count == 0)
			{
				MessageBox.Show("Выборка для кластеризации должна содержать хотя бы 1 сущность хотя бы с 1 параметром", "Ошибка");
				return;
			}

			using (new CursorHandler())
			{
				foreach (var data in _testingDataSet.Entities)
				{
					var attributeValues = data.AttributeValues
						.Select(attr => new InputAttributeValue
						{
							InputAttributeNumber = attr.Attribute.OrderNumber,
							Value = attr.Value
						});

					var result = NeuralNetwork.GetNeuronWinner(attributeValues).NeuronNumber;
					Clasters.First(c => c.Number == result).Entities.Add(data);
				}

				_interfaceMediator.DrawClasters(Clasters, dgvClasters);
				tabPanelMain.SelectedIndex = 3;
			}
		}

		/// <summary>
		/// Сохранить нейронную сеть.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_SaveNetwork_Click(object sender, EventArgs e)
		{
            var network = _networkBase ?? new NetworkBase();
            network.Name = tbNetworkName.Text;

            var networkData = new NeuralNetworkData
			{
				Network = network,
                InputAttributes = NeuralNetwork.InputAttributes,
                Neurons = NeuralNetwork.Neurons,
                Weights = NeuralNetwork.Weights
            };
            _networkService.SaveNetworkData(networkData);

            DialogResult = DialogResult.OK;
            Close();
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

			var clusterNumber = (int)selectedRow.Cells["ClusterNumber"].Value;
			var claster = Clasters.First(c => c.Number == clusterNumber);

			_interfaceMediator.DrawDataIntoGrid(claster.Entities, _testingDataSet.Attributes, dgvClasterEntities);
		}

		/// <summary>
		/// Отобразить веса сети при их изменении.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNetworkWeightsChanged(object sender, EventArgs e)
		{
			_interfaceMediator.DrawNetworkWeights(NeuralNetwork, _learningDataSet.Attributes, dgvWeights);
		}
	}
}
