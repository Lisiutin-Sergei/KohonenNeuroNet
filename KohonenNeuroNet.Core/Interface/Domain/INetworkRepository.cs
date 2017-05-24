using KohonenNeuroNet.Core.Model.Domain;
using System.Collections.Generic;

namespace KohonenNeuroNet.Core.Interface.Domain
{
	/// <summary>
	/// Интерфейс репозитория нейронных сетей.
	/// </summary>
	public interface INetworkRepository
	{
		/// <summary>
		/// Получить нейронную сеть по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор нейронной сети.</param>
		/// <returns>Нейронная сеть.</returns>
		NetworkBase GetByID(int id);

		/// <summary>
		/// Получить список нейронных сетей.
		/// </summary>
		/// <returns>Список нейронных сетей.</returns>
		IEnumerable<NetworkBase> GetAll();

		/// <summary>
		/// Вставить новую нейронную сеть.
		/// </summary>
		/// <param name="entity">Нейронная сеть для сохранения.</param>
		/// <returns>Идентификатор нового экземпляра сущности.</returns>
		int Insert(NetworkBase entity);

		/// <summary>
		/// Обновить нейронную сеть.
		/// </summary>
		/// <param name="entity">Нейронная сеть для сохранения.</param>
		void Update(NetworkBase entity);

		/// <summary>
		/// Удалить нейронную сеть.
		/// </summary>
		/// <param name="entity">Нейронная сеть для удаления.</param>
		void Delete(NetworkBase entity);
	}
}
