using System.Collections.Generic;

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

    /// <summary>
    /// Тестовая сущность.
    /// </summary>
    public class InputEntity
    {
        /// <summary>
        /// Значения атрибутов сущности.
        /// </summary>
        public List<InputAttributeValue> Attributes { get; set; } = new List<InputAttributeValue>();
        
        /// <summary>
        /// Название сущности.
        /// </summary>
        public string Name { get; set; }
    }
}
