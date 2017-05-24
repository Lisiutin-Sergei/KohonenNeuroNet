namespace KohonenNeuroNet.Core.Model.Domain
{
	/// <summary>
	/// Вес аксона нейронной сети.
	/// </summary>
	public class WeightBase
	{
		/// <summary>
		/// Идентификатор веса.
		/// </summary>
		public int WeightId { get; set; }

		/// <summary>
		/// Значение веса.
		/// </summary>
		public double Value { get; set; }

		/// <summary>
		/// Ссылка на нейрон.
		/// </summary>
		public int NeuronId { get; set; }

		/// <summary>
		/// Ссылка на входной атрибут.
		/// </summary>
		public int InputAttributeId { get; set; }

		/// <summary>
		/// Порядковый номер нейрона.
		/// </summary>
		public int NeuronNumber { get; set; }

		/// <summary>
		/// Порядковый номер входного атрибута.
		/// </summary>
		public int InputAttributeNumber { get; set; }
	}
}
