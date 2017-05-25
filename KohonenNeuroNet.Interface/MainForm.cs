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
        private List<NetworkCluster> _clusters = new List<NetworkCluster>();

		/// <summary>
		/// Нейронная сеть.
		/// </summary>
		private readonly AbstractNetwork _neuralNetwork;

        /// <summary>
        /// Данные о нейронной сети из базы.
        /// </summary>
		private NetworkBase _networkBase;
        
		public MainForm(
            INetworkService networkService, 
            IReader reader, 
            AbstractNetwork network, 
            int? networkId = null, 
            int? parentNeuronId = null)
		{
			InitializeComponent();

			_reader = reader;
			_networkService = networkService;
			_converter = new NetworkDataSetConverter();
			_interfaceMediator = new InterfaceMediator();

			_neuralNetwork = network;
			_neuralNetwork.IterationCompleted += OnNetworkWeightsChanged;

            // При редактировании существующей сети скрыть обучение
            var isEdit = networkId > 0;
            if (isEdit)
			{
				InitializeExistingNetwork(networkId ?? 0);
			}
            else
            {
                _networkBase = new NetworkBase
                {
                    ParentNeuronId = parentNeuronId
                };
            }

            btnEditCluster.Enabled = isEdit;
            btnSaveNetwork.Enabled = !isEdit;
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
            _neuralNetwork.Neurons = networkData.Neurons;
            _neuralNetwork.InputAttributes = networkData.InputAttributes;
            _neuralNetwork.Weights = networkData.Weights;
            
			// Сформировать пустые кластеры
			_clusters = _neuralNetwork.Neurons
				.Select(neuron => new NetworkCluster
				{
					Number = neuron.NeuronNumber
				})
				.ToList();
			_interfaceMediator.DrawClusters(_clusters, tvClusters);
			
            _interfaceMediator.DrawNetworkWeights(_neuralNetwork, _neuralNetwork.InputAttributes, dgvWeights);
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
						_neuralNetwork.InputAttributes = _learningDataSet.Attributes
							.Select(a => new InputAttributeBase
							{
								InputAttributeNumber = a.OrderNumber,
								Name = a.Name
							})
							.ToList();

						_interfaceMediator.DrawDataIntoGrid(_learningDataSet.Entities, _neuralNetwork.InputAttributes, dgvInputLearningData);
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
				_neuralNetwork.Study(_learningDataSet, clastersCount, iterationsCount);

				// Сформировать пустые кластеры
				_clusters = _neuralNetwork.Neurons
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

						_interfaceMediator.DrawDataIntoGrid(_testingDataSet.Entities, _neuralNetwork.InputAttributes, dgvTesingData);
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

					var result = _neuralNetwork.GetNeuronWinner(attributeValues).NeuronNumber;
					_clusters.First(c => c.Number == result).Entities.Add(data);
				}

				_interfaceMediator.DrawClusters(_clusters, tvClusters);
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
                InputAttributes = _neuralNetwork.InputAttributes,
                Neurons = _neuralNetwork.Neurons,
                Weights = _neuralNetwork.Weights
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
		private void Tv_Clusters_SelectionChanged(object sender, EventArgs e)
		{
			// Очистить таблицу с элементами кластера
			_interfaceMediator.DrawDataIntoGrid(null, null, dgvClasterEntities);

			if (tvClusters.SelectedNode.Tag == null || (int)tvClusters.SelectedNode.Tag <= 0)
			{
				return;
			}
			
			var clusterNumber = (int)tvClusters.SelectedNode.Tag;
			var cluster = _clusters.First(c => c.Number == clusterNumber);

			_interfaceMediator.DrawDataIntoGrid(cluster.Entities, _neuralNetwork.InputAttributes, dgvClasterEntities);
		}

        /// <summary>
        /// Изменить кластер - повторная кластеризация.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_EditCluster_Click(object sender, EventArgs e)
        {
            try
            {
                var isEdit = _networkBase?.NetworkId > 0;
                if (!isEdit)
                {
                    throw new Exception("Невозможно изменить кластер у несохраненной нейронной сети.");
                }
				if (tvClusters.SelectedNode?.Tag == null || (int)tvClusters.SelectedNode?.Tag < 0)
				{
					throw new Exception("Выберите кластер для изменения.");
				}

                var clusterNumber = (int)tvClusters.SelectedNode.Tag;
				var neuron = _neuralNetwork.Neurons.First(n => n.NeuronNumber == clusterNumber);
                if (neuron.NeuronId <= 0)
                {
                    throw new Exception("Невозможно изменить кластер у несохраненной нейронной сети.");
                }
                
                var mainForm = IoC.Instance.Resolve<MainForm>(
					new IoC.NinjectArgument("networkId", null),
					new IoC.NinjectArgument("parentNeuronId", neuron.NeuronId));
                if (mainForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновить кластеры
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		/// <summary>
		/// Отобразить веса сети при их изменении.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNetworkWeightsChanged(object sender, EventArgs e)
		{
			_interfaceMediator.DrawNetworkWeights(_neuralNetwork, _neuralNetwork.InputAttributes, dgvWeights);
		}
	}
}
