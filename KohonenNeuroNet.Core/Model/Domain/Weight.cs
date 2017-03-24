namespace KohonenNeuroNet.Core.Model.Domain
{
	/// <summary>
	/// Вес аксона нейронной сети.
	/// </summary>
	public class Weight
	{
		/// <summary>
		/// Идентификатор веса.
		/// </summary>
		public int Id { get; set; }

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
	}
}
