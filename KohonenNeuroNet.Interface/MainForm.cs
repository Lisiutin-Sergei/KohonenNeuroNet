using KohonenNeuroNet.Core.Interface.Service;
using KohonenNeuroNet.Core.Model.Business;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.Interface.DI;
using KohonenNeuroNet.NeuralNetwork.NetworkData;
using KohonenNeuroNet.NeuralNetwork.NeuralNetwork;
using KohonenNeuroNet.Utilities;
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
        private readonly InterfaceHelpers _interfaceMediator;

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
            int? parentNeuronId = null,
            NetworkDataSet parentNeuronDataSet = null)
        {
            InitializeComponent();

            _reader = reader;
            _networkService = networkService;
            _converter = new NetworkDataSetConverter();
            _interfaceMediator = new InterfaceHelpers();

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

            if (parentNeuronId > 0)
            {
                if (parentNeuronDataSet == null || !(parentNeuronDataSet?.Entities?.Any() ?? false))
                {
                    throw new Exception("Не задан набор обучающих данных для повторной кластеризации.");
                }
                _learningDataSet = parentNeuronDataSet;
                _testingDataSet = parentNeuronDataSet;
                btnChooseLearningFile.Enabled = false;
                btnChooseTestingFile.Enabled = false;

				RecalcMinMaxValues(_learningDataSet);
				RecalcMinMaxValues(_testingDataSet);

				_neuralNetwork.InputAttributes = _learningDataSet.Attributes
                    .Select(a => new InputAttributeBase
                    {
                        InputAttributeNumber = a.OrderNumber,
                        Name = a.Name
                    })
                    .ToList();

                _interfaceMediator.DrawDataIntoGrid(_learningDataSet.Entities, _neuralNetwork.InputAttributes, dgvInputLearningData);
                var normalizedData = _learningDataSet.Entities
                    .Select(l => new NetworkDataEntity()
                    {
                        Name = l.Name,
                        OrderNumber = l.OrderNumber,
                        AttributeValues = l.AttributeValues.Select(a => new NetworkEntityAttributeValue
                        {
                            Attribute = a.Attribute,
                            Value = a.GetNormalizedValue(_neuralNetwork.NormalizationType)
                        }).ToList()
                    })
                    .ToList();
                _interfaceMediator.DrawDataIntoGrid(normalizedData, _neuralNetwork.InputAttributes, dgvNormalizedLearningData);

                _interfaceMediator.DrawDataIntoGrid(_testingDataSet.Entities, _neuralNetwork.InputAttributes, dgvTesingData);
            }

            btnEditCluster.Enabled = isEdit;
            SetSaveButtonEnabled();
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

            // Заполнить сеть данными, полученными из БД
            _neuralNetwork.InitializeNetwork(
                networkData.Neurons.Select(e => e.Neuron).ToList(),
                networkData.InputAttributes,
                networkData.Weights);

            // Сформировать пустые кластеры
            _clusters = networkData.Neurons
                .Select(neuron => new NetworkCluster
                {
                    Number = neuron.Neuron.NeuronNumber,
                    NetworkId = neuron.Network?.Network?.NetworkId,
                    Clusters = GetClusters(neuron.Network?.Neurons)
                })
                .ToList();

            _interfaceMediator.DrawClusters(_clusters, tvClusters);
            _interfaceMediator.DrawNetworkWeights(_neuralNetwork, _neuralNetwork.InputAttributes, dgvWeights);
        }

        /// <summary>
        /// Сформировать дерево кластеров.
        /// </summary>
        /// <param name="neurons">Список нейронов.</param>
        /// <returns>Дерево кластеров.</returns>
        private List<NetworkCluster> GetClusters(List<NeuronData> neurons)
        {
            var list = new List<NetworkCluster>();

            if (!(neurons?.Any() ?? false))
            {
                return list;
            }

            foreach (var neuron in neurons)
            {
                list.Add(new NetworkCluster
                {
                    Number = neuron.Neuron.NeuronNumber,
                    NetworkId = neuron.Network?.Network?.NetworkId,
                    Clusters = GetClusters(neuron.Network?.Neurons)
                });
            }

            return list;
        }

        /// <summary>
        /// Загрузить данные из файла для обучения сети.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChooseLearningFile_Click(object sender, EventArgs e)
        {
            try
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
							
							RecalcMinMaxValues(_learningDataSet);
							RecalcMinMaxValues(_testingDataSet);

							var normalizedData = _learningDataSet.Entities
                                .Select(l => new NetworkDataEntity()
                                {
                                    Name = l.Name,
                                    OrderNumber = l.OrderNumber,
                                    AttributeValues = l.AttributeValues.Select(a => new NetworkEntityAttributeValue
                                    {
                                        Attribute = a.Attribute,
                                        Value = a.GetNormalizedValue(_neuralNetwork.NormalizationType)
                                    }).ToList()
                                })
                                .ToList();
                            _interfaceMediator.DrawDataIntoGrid(normalizedData, _neuralNetwork.InputAttributes, dgvNormalizedLearningData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обучить нейронную сеть.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_LearnNetwork_Click(object sender, EventArgs e)
        {
            try
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

                    SetSaveButtonEnabled();
                    tabPanelMain.SelectedIndex = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выбрать файл для тестирования.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChooseTestingFile_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Тестировать сеть.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Test_Click(object sender = null, EventArgs e = null)
        {
            try
            {
                if (_testingDataSet == null || _testingDataSet.Entities == null || _testingDataSet.Entities.Count == 0 ||
                _testingDataSet.Attributes == null || _testingDataSet.Attributes.Count == 0)
                {
                    MessageBox.Show("Выборка для кластеризации должна содержать хотя бы 1 сущность хотя бы с 1 параметром", "Ошибка");
                    return;
                }

                using (new CursorHandler())
                {
                    _clusters.ForEach(c => c.Entities.Clear());

                    foreach (var data in _testingDataSet.Entities)
                    {
                        var attributeValues = data.AttributeValues
                            .Select(attr => new InputAttributeValue
                            {
                                InputAttributeNumber = attr.Attribute.OrderNumber,
                                Value = attr.GetNormalizedValue(_neuralNetwork.NormalizationType)
                            })
                            .ToList();

                        var result = _neuralNetwork.GetNeuronWinner(attributeValues).NeuronNumber;
                        _clusters.First(c => c.Number == result).Entities.Add(data);
                    }

                    // Рекурсивно оттестить сеть
                    foreach (var cluster in _clusters)
                    {
                        TestDataRecursive(cluster);
                    }

                    _interfaceMediator.DrawClusters(_clusters, tvClusters);
                    tabPanelMain.SelectedIndex = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Тестировать сеть рекурсивно.
        /// </summary>
        /// <param name="cluster">Текущий кластер.</param>
        private void TestDataRecursive(NetworkCluster cluster)
        {
            if (!(cluster.Entities?.Any() ?? false) ||
                !(cluster.Clusters?.Any() ?? false) ||
                cluster.NetworkId == null)
            {
                return;
            }

            cluster.Clusters.ForEach(c => c.Entities.Clear());

            var currentNetworkData = _networkService.GetNetworkData(cluster.NetworkId.Value);
            var neuralNetwork = IoC.Instance.Resolve<AbstractNetwork>();
            neuralNetwork.InitializeNetwork(
                currentNetworkData.Neurons.Select(e => e.Neuron).ToList(),
                currentNetworkData.InputAttributes,
                currentNetworkData.Weights);

			RecalcMinMaxValues(cluster.Entities);

			foreach (var data in cluster.Entities)
            {
                var attributeValues = data.AttributeValues
                    .Select(attr => new InputAttributeValue
                    {
                        InputAttributeNumber = attr.Attribute.OrderNumber,
                        Value = attr.GetNormalizedValue(_neuralNetwork.NormalizationType)
                    })
                    .ToList();

                var result = neuralNetwork.GetNeuronWinner(attributeValues).NeuronNumber;
                cluster.Clusters.First(c => c.Number == result).Entities.Add(data);
            }

            foreach (var subCluster in cluster.Clusters)
            {
                TestDataRecursive(subCluster);
            }
        }

        /// <summary>
        /// Сохранить нейронную сеть.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SaveNetwork_Click(object sender, EventArgs e)
        {
            try
            {
                var network = _networkBase ?? new NetworkBase();
                network.Name = tbNetworkName.Text;

                if (string.IsNullOrEmpty(network.Name))
                {
                    throw new Exception("Введите название сети на вкладке \"Обучение\".");
                }

                var networkData = new NeuralNetworkData
                {
                    Network = network,
                    InputAttributes = _neuralNetwork.InputAttributes,
                    Neurons = _neuralNetwork.Neurons.Select(n => new NeuronData(n, null)).ToList(),
                    Weights = _neuralNetwork.Weights
                };
                _networkService.SaveNetworkData(networkData);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// При изменении выбора кластера отображать его элементы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tv_Clusters_SelectionChanged(object sender, TreeViewEventArgs e)
        {
            try
            {
                var isEdit = _networkBase.NetworkId > 0;

                // Очистить таблицу с элементами кластера
                _interfaceMediator.DrawDataIntoGrid(null, null, dgvClasterEntities);

                if (tvClusters.SelectedNode.Tag == null || string.IsNullOrEmpty(tvClusters.SelectedNode.Tag.ToString()))
                {
                    btnEditCluster.Enabled = false;
                    return;
                }

                var cluster = tvClusters.SelectedNode.Tag as NetworkCluster;

                _interfaceMediator.DrawDataIntoGrid(cluster.Entities, _neuralNetwork.InputAttributes, dgvClasterEntities);

                // Повторно кластеризовать можно только кластер, у которого есть данные
                btnEditCluster.Enabled = tvClusters.SelectedNode.Level == 1 && isEdit && (cluster.Entities?.Count ?? 0) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (tvClusters.SelectedNode?.Tag == null || string.IsNullOrEmpty(tvClusters.SelectedNode.Tag.ToString()))
                {
                    throw new Exception("Выберите кластер для изменения.");
                }

                var cluster = tvClusters.SelectedNode.Tag as NetworkCluster;
                var neuron = _neuralNetwork.Neurons.First(n => n.NeuronNumber == cluster.Number);
                if (neuron.NeuronId <= 0)
                {
                    throw new Exception("Невозможно изменить кластер у несохраненной нейронной сети.");
                }

                var dataSet = new NetworkDataSet()
                {
                    Entities = _testingDataSet.Entities
                        .Where(t => cluster.Entities.Select(c => c.OrderNumber).Contains(t.OrderNumber))
                        .ToList(),
                    Attributes = _testingDataSet.Attributes
                };
                var mainForm = IoC.Instance.Resolve<MainForm>(
                    new IoC.NinjectArgument("networkId", cluster.NetworkId),
                    new IoC.NinjectArgument("parentNeuronId", neuron.NeuronId),
                    new IoC.NinjectArgument("parentNeuronDataSet", dataSet.Clone() as NetworkDataSet));
                if (mainForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновить кластеры
                    InitializeExistingNetwork(_networkBase.NetworkId);
                    Btn_Test_Click();
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

        private void SetSaveButtonEnabled()
        {
            var isEdit = (_networkBase?.NetworkId ?? 0) > 0;
            btnSaveNetwork.Enabled = !isEdit && _clusters.Count > 0;
        }

		/// <summary>
		/// Пересчитать минимальное и максимальое значение.
		/// </summary>
		/// <param name="dataSet">Данные.</param>
		private void RecalcMinMaxValues(NetworkDataSet dataSet)
		{
			if (!(dataSet?.Attributes?.Any() ?? false))
			{
				return;
			}

			foreach (var attribute in dataSet.Attributes)
			{
				attribute.Max = dataSet.Entities
					.Max(e => e.AttributeValues.First(a => a.Attribute.OrderNumber == attribute.OrderNumber).Value);
				attribute.Min = dataSet.Entities
					.Min(e => e.AttributeValues.First(a => a.Attribute.OrderNumber == attribute.OrderNumber).Value);
				dataSet.Entities
					.ForEach(entity => entity.AttributeValues.First(a => a.Attribute.OrderNumber == attribute.OrderNumber).Attribute = attribute);
			}
		}

		/// <summary>
		/// Пересчитать минимальное и максимальое значение.
		/// </summary>
		/// <param name="dataSet">Данные.</param>
		private void RecalcMinMaxValues(List<NetworkDataEntity> dataSet)
		{
			if (!(dataSet?.Any() ?? false) || !(dataSet.First().AttributeValues?.Any() ?? false))
			{
				return;
			}

			foreach (var attribute in dataSet.First().AttributeValues.Select(e => e.Attribute))
			{
				attribute.Max = dataSet
					.Max(e => e.AttributeValues.First(a => a.Attribute.OrderNumber == attribute.OrderNumber).Value);
				attribute.Min = dataSet
					.Min(e => e.AttributeValues.First(a => a.Attribute.OrderNumber == attribute.OrderNumber).Value);
				dataSet
					.ForEach(entity => entity.AttributeValues.First(a => a.Attribute.OrderNumber == attribute.OrderNumber).Attribute = attribute);
			}
		}

	}
}
