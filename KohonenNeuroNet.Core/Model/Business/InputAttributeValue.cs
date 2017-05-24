namespace KohonenNeuroNet.Core.Model.Business
{
	/// <summary>
	/// Входной атрибут для сети Кохонена.
	/// </summary>
	public class InputAttributeValue
	{
		/// <summary>
		/// Порядковый номер входного атрибута.
		/// </summary>
		public int InputAttributeNumber { get; set; }

		/// <summary>
		/// Значение.
		/// </summary>
		public double Value { get; set; }
	}
}
