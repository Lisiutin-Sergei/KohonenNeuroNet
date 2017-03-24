using KohonenNeuroNet.Core.Model.Domain;
using System.Collections.Generic;

namespace KohonenNeuroNet.Core.Interface.Domain
{
	/// <summary>
	/// Интерфейс репозитория весов.
	/// </summary>
	public interface IInputAttributeRepository
	{
		/// <summary>
		/// Получить атрибут по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор атрибута.</param>
		/// <returns>Атрибут.</returns>
		InputAttribute GetByID(int id);

		/// <summary>
		/// Получить список атрибутов.
		/// </summary>
		/// <returns>Список атрибутов.</returns>
		IEnumerable<InputAttribute> GetAll();

		/// <summary>
		/// Создать новый атрибут.
		/// </summary>
		/// <param name="entity">Атрибут для сохранения.</param>
		/// <returns>Идентификатор нового экземпляра сущности.</returns>
		int Insert(InputAttribute entity);

		/// <summary>
		/// Обновить атрибут.
		/// </summary>
		/// <param name="entity">Атрибут для сохранения.</param>
		void Update(InputAttribute entity);

		/// <summary>
		/// Удалить атрибут.
		/// </summary>
		/// <param name="entity">Атрибут для удаления.</param>
		void Delete(InputAttribute entity);
	}
}
