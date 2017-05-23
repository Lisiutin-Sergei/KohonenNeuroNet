using KohonenNeuroNet.Core.Model.Domain;
using System.Collections.Generic;

namespace KohonenNeuroNet.Core.Interface.Service
{
	/// <summary>
	/// Интерфейс сервиса работы с сетью.
	/// </summary>
	public interface INetworkService
	{
		void SaveNetworkData();

		/// <summary>
		/// Загрузить список нейронных сетей.
		/// </summary>
		/// <returns>Список нейронных сетей.</returns>
		List<Network> LoadAllNetworks();
	}
}
