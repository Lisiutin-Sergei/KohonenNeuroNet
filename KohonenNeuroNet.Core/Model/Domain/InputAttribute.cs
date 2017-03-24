namespace KohonenNeuroNet.Core.Model.Domain
{
	/// <summary>
	/// Доменная модель атрибута входной сущности для хранения.
	/// </summary>
	public class InputAttribute
	{
		/// <summary>
		/// Идентификатор атрибута.
		/// </summary>
		public int Id { get; set; }

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
