using KohonenNeuroNet.Core.Interface.Data;
using KohonenNeuroNet.Core.Interface.Domain;
using KohonenNeuroNet.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

namespace KohonenNeuroNet.Data.UnitOfWork
{
	/// <summary>
	/// Единица работы (Паттерн Unit of Work).
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// Имя узла конфигурации, хранящее значение строки подключения к БД.
		/// </summary>
		private const string _CONNECTION_STRING_NAME = "Data:DbContext:ConnectionString";
		private Lazy<DataContext> _dataContext;

		#region Репозитории

		/// <summary>
		/// Репозиторий нейронных сетей.
		/// </summary>
		public INetworkRepository NetworkRepository => new NetworkRepository(_dataContext.Value);

		/// <summary>
		/// Репозиторий нейронов.
		/// </summary>
		public INeuronRepository NeuronRepository => new NeuronRepository(_dataContext.Value);

		/// <summary>
		/// Репозиторий весов.
		/// </summary>
		public IWeightRepository WeightRepository => new WeightRepository(_dataContext.Value);

		/// <summary>
		/// Репозиторий атрибутов.
		/// </summary>
		public IInputAttributeRepository InputAttributeRepository => new InputAttributeRepository(_dataContext.Value);

		#endregion

		/// <summary>
		/// Конструктор единицы работы.
		/// </summary>
		/// <param name="configuration">Конфигурация запускаемого проекта. 
		/// Должен быть заполнен узел для строки подключения к базе данных (<see cref="_CONNECTION_STRING_NAME"/>).</param>
		public UnitOfWork(IConfiguration configuration)
		{
			_dataContext = new Lazy<DataContext>(() => _CreateDataContext(configuration), true);
		}

		/// <summary>
		/// Установка соединения с базой данных.
		/// </summary>
		/// <param name="configuration">Конфигурация запускаемого проекта.</param>
		/// <returns>Контекст данных.</returns>
		private DataContext _CreateDataContext(IConfiguration configuration)
		{
			string connectionString = configuration.GetValue<string>(_CONNECTION_STRING_NAME);
			IDbConnection connection = new NpgsqlConnection(connectionString);
			connection.Open();
			return new DataContext(connection, null);
		}

		/// <summary>
		/// Открыть транзакцию.
		/// </summary>
		public void BeginTransaction()
		{
			_dataContext.Value.Transaction = _dataContext.Value.Connection.BeginTransaction();
		}

		/// <summary>
		/// Подтвердить транзакцию, если она открыта.
		/// </summary>
		public void CommitTransaction()
		{
			if (_dataContext.Value.Transaction != null)
			{
				_dataContext.Value.Transaction.Commit();
				_dataContext.Value.Transaction.Dispose();
				_dataContext.Value.Transaction = null;
			}
		}

		/// <summary>
		/// Откатить транзакцию, если она открыта.
		/// </summary>
		public void RollbackTransaction()
		{
			if (_dataContext.Value.Transaction != null)
			{
				_dataContext.Value.Transaction.Rollback();
				_dataContext.Value.Transaction.Dispose();
				_dataContext.Value.Transaction = null;
			}
		}

		/// <summary>
		/// Освободить неуправляемые ресурсы единицы работы такие, как подключение к базе данных и транзакция.
		/// Если транзакция не закрыта, она откатывается.
		/// </summary>
		public void Dispose()
		{
			if (_dataContext.IsValueCreated)
			{
				RollbackTransaction();
				if (_dataContext.Value.Connection != null)
				{
					_dataContext.Value.Connection.Dispose();
					_dataContext.Value.Connection = null;
				}
			}
		}
	}
}
