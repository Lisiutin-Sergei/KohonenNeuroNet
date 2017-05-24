using System;

namespace KohonenNeuroNet.Core.Model.Domain
{
	/// <summary>
	/// Доменная модель нейронной сети для хранения.
	/// </summary>
	public class NetworkBase
	{
		/// <summary>
		/// Идентификатор нейронной сети.
		/// </summary>
		public int NetworkId { get; set; }

		/// <summary>
		/// Название нейронной сети.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime? CreatedOn { get; set; }
	}
}
