using KohonenNeuroNet.Core.Model.Business;
using KohonenNeuroNet.Core.Model.Domain;
using System.Collections.Generic;

namespace KohonenNeuroNet.Core.Interface.Service
{
	/// <summary>
	/// Интерфейс сервиса работы с сетью.
	/// </summary>
	public interface INetworkService
	{
		void SaveNetworkData(NeuralNetworkData networkData);

		/// <summary>
		/// Загрузить список нейронных сетей.
		/// </summary>
		/// <returns>Список нейронных сетей.</returns>
		List<NetworkBase> LoadAllNetworks();

		/// <summary>
		/// Получить данные о нейронной сети.
		/// </summary>
		/// <returns>Данные о нейронной сети.</returns>
		NeuralNetworkData GetNetworkData(int networkId);
	}
}
