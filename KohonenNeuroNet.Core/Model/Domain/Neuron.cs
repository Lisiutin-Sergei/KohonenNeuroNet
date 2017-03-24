namespace KohonenNeuroNet.Core.Model.Domain
{
	/// <summary>
	/// Доменная модель нейрона сети для хранения.
	/// </summary>
	public class Neuron
	{
		/// <summary>
		/// Идентификатор нейрона.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Порядковый номер нейрона.
		/// </summary>
		public int OrderNumber { get; set; }

		/// <summary>
		/// Ссылка на нейронную сеть.
		/// </summary>
		public int NetworkId { get; set; }
	}
}
