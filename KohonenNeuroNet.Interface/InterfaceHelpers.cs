using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.NeuralNetwork.NetworkData;
using KohonenNeuroNet.NeuralNetwork.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace KohonenNeuroNet.Interface
{
	/// <summary>
	/// Посредник для работы с данными в интерфейсе.
	/// </summary>
	public class InterfaceMediator
	{
		/// <summary>
		/// Отобразить веса сети в DataGridView.
		/// </summary>
		/// <param name="network">Сеть.</param>
		/// <param name="attributes">Атрибуты сети.</param>
		/// <param name="grid">Таблица.</param>
		public void DrawNetworkWeights(AbstractNetwork network, List<InputAttributeBase> attributes, DataGridView grid)
		{
			var weightsPrecision = 5;
			grid.Rows.Clear();
			grid.Columns.Clear();
			if (network == null || !(network.Neurons?.Any() ?? false))
			{
				return;
			}

			grid.Columns.Add("Вход/Нейрон", "Вход/Нейрон");
			network.Neurons
				.OrderBy(n => n.NeuronNumber)
				.ToList()
				.ForEach(n => grid.Columns.Add(n.NeuronNumber.ToString(), n.NeuronNumber.ToString()));

			foreach (var attribute in attributes.OrderBy(a => a.InputAttributeNumber))
			{
				var row = new List<object> { $"{attribute.InputAttributeNumber}) {attribute.Name}" };

				foreach(var neuron in network.Neurons)
				{
					var weight = network.Weights
						.FirstOrDefault(e =>
							e.NeuronNumber == neuron.NeuronNumber &&
							e.InputAttributeNumber == attribute.InputAttributeNumber);
					row.Add((object)Math.Round(weight.Value, weightsPrecision));
				}
				
				grid.Rows.Add(row.ToArray());
			}
		}

		/// <summary>
		/// Отобразить данные сети в DataGridView.
		/// </summary>
		/// <param name="entities">Набор сущностей.</param>
		/// <param name="attributes">Атрибуты набора сущностей.</param>
		/// <param name="grid">DataGridView.</param>
		public void DrawDataIntoGrid(List<NetworkDataEntity> entities, List<InputAttributeBase> attributes, DataGridView grid)
		{
			grid.Rows.Clear();
			grid.Columns.Clear();
			if (entities == null || attributes == null)
			{
				return;
			}

			grid.Columns.Add("№", "№");
			grid.Columns.Add("Название", "Название");
			foreach (var attribute in attributes)
			{
				grid.Columns.Add(attribute.Name, attribute.Name);
			}
			foreach (var entity in entities)
			{
				var entityAttributeValues = new List<object> { entity.OrderNumber, entity.Name };
				entityAttributeValues.AddRange(entity.AttributeValues.Select(a => (object)a.Value));
				grid.Rows.Add(entityAttributeValues.ToArray());
			}
		}

        /// <summary>
        /// Отобразить кластеры рекурсивно.
        /// </summary>
        /// <param name="cluster">Кластер для отображения.</param>
        /// <param name="parentNode">Родительская вершина дерева.</param>
        private void DrawClustersRecursive(NetworkCluster cluster, TreeNode parentNode)
        {
            var index = parentNode.Nodes.Add(new TreeNode
            {
                Text = $"{cluster.Number} ({cluster.Entities?.Count ?? 0})",
                Tag = cluster
            });

            if (!(cluster.Clusters?.Any() ?? false))
            {
                return;
            }

            foreach(var subCluster in cluster.Clusters)
            {
                DrawClustersRecursive(subCluster, parentNode.Nodes[index]);
            }
        }

		/// <summary>
		/// Отобразить кластеры в DataGridView.
		/// </summary>
		/// <param name="clusters">Кластеры.</param>
		/// <param name="tree">DataGridView.</param>
		public void DrawClusters(List<NetworkCluster> clusters, TreeView tree)
		{
			var rootNode = tree.Nodes[0];

			rootNode.Nodes.Clear();
			if (clusters == null)
			{
				return;
			}

            foreach(var cluster in clusters)
            {
                DrawClustersRecursive(cluster, rootNode);
            }

            rootNode.ExpandAll();
        }

	}
}
