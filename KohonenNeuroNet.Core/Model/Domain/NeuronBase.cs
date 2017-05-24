namespace KohonenNeuroNet.Core.Model.Domain
{
	/// <summary>
	/// Доменная модель нейрона сети для хранения.
	/// </summary>
	public class NeuronBase
	{
		/// <summary>
		/// Идентификатор нейрона.
		/// </summary>
		public int NeuronId { get; set; }

		/// <summary>
		/// Порядковый номер нейрона.
		/// </summary>
		public int NeuronNumber { get; set; }

		/// <summary>
		/// Ссылка на нейронную сеть.
		/// </summary>
		public int NetworkId { get; set; }
	}
}
