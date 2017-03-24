using Dommel;
using KohonenNeuroNet.Core.Interface.Domain;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.Data.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace KohonenNeuroNet.Data.Repositories
{
	/// <summary>
	/// Репозиторий нейронов.
	/// </summary>
	public class NeuronRepository : INeuronRepository
	{
		private DataContext _dataContext;

		/// <summary>
		/// Конструктор репозитория нейронов.
		/// </summary>
		/// <param name="dataContext">Контекст данных (подключение к базе и транзакция).</param>
		public NeuronRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		/// <summary>
		/// Вставить новый экземпляр сущности.
		/// </summary>
		/// <param name="item">Модель нового экземпляра сущности.</param>
		/// <returns>Идентификатор нового экземпляра сущности.</returns>
		public int Insert(Neuron item)
		{
			return (int)_dataContext.Connection.Insert(item, _dataContext.Transaction);
		}

		/// <summary>
		/// Обновить существующий экземпляр сущности.
		/// </summary>
		/// <param name="item">Модель экземпляра сущности.</param>
		public void Update(Neuron item)
		{
			_dataContext.Connection.Update(item, _dataContext.Transaction);
		}

		/// <summary>
		/// Удалить существующий экземпляр сущности.
		/// </summary>
		/// <param name="item">Модель экземпляра сущности.</param>
		public void Delete(Neuron item)
		{
			_dataContext.Connection.Delete(item, _dataContext.Transaction);
		}

		/// <summary>
		/// Получить список всех экземпляров сущности.
		/// </summary>
		/// <returns>Список всех экземпляров сущности.</returns>
		public IEnumerable<Neuron> GetAll()
		{
			return _dataContext.Connection.GetAll<Neuron>().ToList();
		}

		/// <summary>
		/// Получить экземпляр сущности по его идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор экземпляра сущности.</param>
		/// <returns>Найденный экземпляр сущности.</returns>
		public Neuron GetByID(int id)
		{
			return _dataContext.Connection.Get<Neuron>(id);
		}
	}
}
