using KohonenNeuroNet.Core.Interface.Domain;
using System;

namespace KohonenNeuroNet.Core.Interface.Data
{
	/// <summary>
	/// Единица работы (Паттерн Unit of Work).
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		#region Репозитории

		/// <summary>
		/// Репозиторий нейронных сетей.
		/// </summary>
		INetworkRepository NetworkRepository { get; }

		/// <summary>
		/// Репозиторий нейронов.
		/// </summary>
		INeuronRepository NeuronRepository { get; }

		/// <summary>
		/// Репозиторий весов.
		/// </summary>
		IWeightRepository WeightRepository { get; }

		/// <summary>
		/// Репозиторий атрибутов.
		/// </summary>
		IInputAttributeRepository InputAttributeRepository { get; }

		#endregion

		/// <summary>
		/// Открыть транзакцию.
		/// </summary>
		void BeginTransaction();

		/// <summary>
		/// Подтвердить транзакцию, если она открыта.
		/// </summary>
		void CommitTransaction();

		/// <summary>
		/// Откатить транзакцию, если она открыта.
		/// </summary>
		void RollbackTransaction();
	}
}
