﻿using KohonenNeuroNet.Core.Model.Domain;
using System.Collections.Generic;

namespace KohonenNeuroNet.Core.Interface.Domain
{
	/// <summary>
	/// Интерфейс репозитория весов.
	/// </summary>
	public interface IWeightRepository
	{
		/// <summary>
		/// Получить вес по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор веса.</param>
		/// <returns>Вес.</returns>
		Weight GetByID(int id);

		/// <summary>
		/// Получить список весов.
		/// </summary>
		/// <returns>Список весов.</returns>
		IEnumerable<Weight> GetAll();

		/// <summary>
		/// Создать новый вес.
		/// </summary>
		/// <param name="entity">Вес для сохранения.</param>
		/// <returns>Идентификатор нового экземпляра сущности.</returns>
		int Insert(Weight entity);

		/// <summary>
		/// Обновить вес.
		/// </summary>
		/// <param name="entity">Вес для сохранения.</param>
		void Update(Weight entity);

		/// <summary>
		/// Удалить вес.
		/// </summary>
		/// <param name="entity">Вес для удаления.</param>
		void Delete(Weight entity);
	}
}
