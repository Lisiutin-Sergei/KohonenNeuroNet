using KohonenNeuroNet.Core.Model.Domain;
using System.Collections.Generic;

namespace KohonenNeuroNet.Core.Model.Business
{
	/// <summary>
	/// Полное описание нейронной сети.
	/// </summary>
	public class NeuralNetworkData
	{
		/// <summary>
		/// Сама нейронная сеть.
		/// </summary>
		public NetworkBase Network { get; set; }

		/// <summary>
		/// Список нейронов.
		/// </summary>
		public List<NeuronBase> Neurons { get; set; }

		/// <summary>
		/// Список входных атрибутов.
		/// </summary>
		public List<InputAttributeBase> InputAttributes { get; set; }

		/// <summary>
		/// Список весов атрибутов.
		/// </summary>
		public List<WeightBase> Weights { get; set; }
	}
}
