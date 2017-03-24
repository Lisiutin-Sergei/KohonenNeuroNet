using KohonenNeuroNet.Core.Model.Domain;
using System.Collections.Generic;

namespace KohonenNeuroNet.Core.Interface.Domain
{
	/// <summary>
	/// Интерфейс репозитория нейронов.
	/// </summary>
	public interface INeuronRepository
	{
		/// <summary>
		/// Получить нейрон по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор нейрона.</param>
		/// <returns>Нейрон.</returns>
		Neuron GetByID(int id);

		/// <summary>
		/// Получить список нейронов.
		/// </summary>
		/// <returns>Список нейронов.</returns>
		IEnumerable<Neuron> GetAll();

		/// <summary>
		/// Создать новый нейрон.
		/// </summary>
		/// <param name="entity">Нейрон для сохранения.</param>
		/// <returns>Идентификатор нового экземпляра сущности.</returns>
		int Insert(Neuron entity);

		/// <summary>
		/// Обновить нейрон.
		/// </summary>
		/// <param name="entity">Нейрон для сохранения.</param>
		void Update(Neuron entity);

		/// <summary>
		/// Удалить нейрон.
		/// </summary>
		/// <param name="entity">Нейрон для удаления.</param>
		void Delete(Neuron entity);
	}
}
