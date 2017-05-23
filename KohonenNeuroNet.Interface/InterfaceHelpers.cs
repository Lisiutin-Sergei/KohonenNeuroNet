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
		public void DrawNetworkWeights(AbstractNetwork network, List<NetworkAttribute> attributes, DataGridView grid)
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
				.OrderBy(n => n.Number)
				.ToList()
				.ForEach(n => grid.Columns.Add(n.Number.ToString(), n.Number.ToString()));

			foreach (var attribute in attributes.OrderBy(a => a.OrderNumber))
			{
				var row = new List<object> { $"{attribute.OrderNumber}) {attribute.Name}" };
				row.AddRange(network.Neurons.Select(n => (object)Math.Round(n.Weights[attribute.OrderNumber], weightsPrecision)));
				grid.Rows.Add(row.ToArray());
			}
		}

		/// <summary>
		/// Отобразить данные сети в DataGridView.
		/// </summary>
		/// <param name="entities">Набор сущностей.</param>
		/// <param name="attributes">Атрибуты набора сущностей.</param>
		/// <param name="grid">DataGridView.</param>
		public void DrawDataIntoGrid(List<NetworkDataEntity> entities, List<NetworkAttribute> attributes, DataGridView grid)
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
		public void DrawDataIntoGrid(NetworkDataSet dataSet, DataGridView grid)
		{
			if (dataSet == null)
			{
				DrawDataIntoGrid(null, null, grid);
			}
			DrawDataIntoGrid(dataSet.Entities, dataSet.Attributes, grid);
		}

		/// <summary>
		/// Отобразить кластеры в DataGridView.
		/// </summary>
		/// <param name="clasters">Кластеры.</param>
		/// <param name="grid">DataGridView.</param>
		public void DrawClasters(List<NetworkClaster> clasters, DataGridView grid)
		{
			grid.Rows.Clear();
			grid.Columns.Clear();
			if (clasters == null)
			{
				return;
			}

			grid.Columns.Add("ClasterNumber", "Номер кластера");
			grid.Columns.Add("EntitiesCount", "Количество элементов");
			foreach (var claster in clasters)
			{
				grid.Rows.Add((object)claster.Number, (object)claster.Entities.Count);
			}
		}

	}
}
