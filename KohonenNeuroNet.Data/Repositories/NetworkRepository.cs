using Dommel;
using KohonenNeuroNet.Core.Interface.Domain;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.Data.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace KohonenNeuroNet.Data.Repositories
{
	/// <summary>
	/// Репозиторий нейронных сетей.
	/// </summary>
	public class NetworkRepository : INetworkRepository
	{
		private DataContext _dataContext;

		/// <summary>
		/// Конструктор репозитория нейронных сетей.
		/// </summary>
		/// <param name="dataContext">Контекст данных (подключение к базе и транзакция).</param>
		public NetworkRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		/// <summary>
		/// Вставить новый экземпляр сущности.
		/// </summary>
		/// <param name="item">Модель нового экземпляра сущности.</param>
		/// <returns>Идентификатор нового экземпляра сущности.</returns>
		public int Insert(Network item)
		{
			return (int)_dataContext.Connection.Insert(item, _dataContext.Transaction);
		}

		/// <summary>
		/// Обновить существующий экземпляр сущности.
		/// </summary>
		/// <param name="item">Модель экземпляра сущности.</param>
		public void Update(Network item)
		{
			_dataContext.Connection.Update(item, _dataContext.Transaction);
		}

		/// <summary>
		/// Удалить существующий экземпляр сущности.
		/// </summary>
		/// <param name="item">Модель экземпляра сущности.</param>
		public void Delete(Network item)
		{
			_dataContext.Connection.Delete(item, _dataContext.Transaction);
		}

		/// <summary>
		/// Получить список всех экземпляров сущности.
		/// </summary>
		/// <returns>Список всех экземпляров сущности.</returns>
		public IEnumerable<Network> GetAll()
		{
			return _dataContext.Connection.GetAll<Network>().ToList();
		}

		/// <summary>
		/// Получить экземпляр сущности по его идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор экземпляра сущности.</param>
		/// <returns>Найденный экземпляр сущности.</returns>
		public Network GetByID(int id)
		{
			return _dataContext.Connection.Get<Network>(id);
		}
	}
}
