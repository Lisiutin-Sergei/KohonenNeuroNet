namespace KohonenNeuroNet.Core.Model.Domain
{
	/// <summary>
	/// Доменная модель атрибута входной сущности для хранения.
	/// </summary>
	public class InputAttributeBase
	{
		/// <summary>
		/// Идентификатор атрибута.
		/// </summary>
		public int InputAttributeId { get; set; }

		/// <summary>
		/// Порядковый номер входного атрибута.
		/// </summary>
		public int InputAttributeNumber { get; set; }

		/// <summary>
		/// Название атрибута.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Ссылка на нейронную сеть.
		/// </summary>
		public int NetworkId { get; set; }
	}
}
