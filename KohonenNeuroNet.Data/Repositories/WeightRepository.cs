﻿using Dommel;
using KohonenNeuroNet.Core.Interface.Domain;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.Data.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace KohonenNeuroNet.Data.Repositories
{
	/// <summary>
	/// Репозиторий весов.
	/// </summary>
	public class WeightRepository : IWeightRepository
	{
		private DataContext _dataContext;

		/// <summary>
		/// Конструктор репозитория весов.
		/// </summary>
		/// <param name="dataContext">Контекст данных (подключение к базе и транзакция).</param>
		public WeightRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		/// <summary>
		/// Вставить новый экземпляр сущности.
		/// </summary>
		/// <param name="item">Модель нового экземпляра сущности.</param>
		/// <returns>Идентификатор нового экземпляра сущности.</returns>
		public int Insert(WeightBase item)
		{
			return (int)_dataContext.Connection.Insert(item, _dataContext.Transaction);
		}

		/// <summary>
		/// Обновить существующий экземпляр сущности.
		/// </summary>
		/// <param name="item">Модель экземпляра сущности.</param>
		public void Update(WeightBase item)
		{
			_dataContext.Connection.Update(item, _dataContext.Transaction);
		}

		/// <summary>
		/// Удалить существующий экземпляр сущности.
		/// </summary>
		/// <param name="item">Модель экземпляра сущности.</param>
		public void Delete(WeightBase item)
		{
			_dataContext.Connection.Delete(item, _dataContext.Transaction);
		}

		/// <summary>
		/// Получить список всех экземпляров сущности.
		/// </summary>
		/// <returns>Список всех экземпляров сущности.</returns>
		public IEnumerable<WeightBase> GetAll()
		{
			return _dataContext.Connection.GetAll<WeightBase>().ToList();
		}

		/// <summary>
		/// Получить экземпляр сущности по его идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор экземпляра сущности.</param>
		/// <returns>Найденный экземпляр сущности.</returns>
		public WeightBase GetByID(int id)
		{
			return _dataContext.Connection.Get<WeightBase>(id);
		}
	}
}
