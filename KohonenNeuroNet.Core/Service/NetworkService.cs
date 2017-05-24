using KohonenNeuroNet.Core.Interface.Data;
using KohonenNeuroNet.Core.Interface.Service;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.Core.Model.Business;

namespace KohonenNeuroNet.Core.Service
{
	/// <summary>
	/// Сервис работы с сетью.
	/// </summary>
	public class NetworkService : INetworkService
	{
		private IConfiguration _configuration;
		private IUnitOfWorkFactory _unitOfWorkFactory;

		public NetworkService(IConfiguration configuration, IUnitOfWorkFactory unitOfWorkFactory)
		{
			_configuration = configuration;
			_unitOfWorkFactory = unitOfWorkFactory;
		}

		/// <summary>
		/// Загрузить список нейронных сетей.
		/// </summary>
		/// <returns>Список нейронных сетей.</returns>
		public List<NetworkBase> LoadAllNetworks()
		{
			using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create(_configuration))
			{
				return unitOfWork.NetworkRepository.GetAll()
					.ToList();
			}
		}

		/// <summary>
		/// Получить данные о нейронной сети.
		/// </summary>
		/// <returns>Данные о нейронной сети.</returns>
		public NeuralNetworkData GetNetworkData(int networkId)
		{
			using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create(_configuration))
			{
				var netwotk = unitOfWork.NetworkRepository.GetByID(networkId);
				var neurons = unitOfWork.NeuronRepository.GetAll()
					.Where(e => e.NetworkId == networkId)
					.ToList();
				var inputAttributes = unitOfWork.InputAttributeRepository.GetAll()
					.Where(e => e.NetworkId == networkId)
					.ToList();
				var weights = unitOfWork.WeightRepository.GetAll()
					.Where(e => neurons.Select(n => n.NeuronId).Contains(e.NeuronId))
					.ToList();

				return new NeuralNetworkData
				{
					Network = netwotk,
					Neurons = neurons,
					InputAttributes = inputAttributes,
					Weights = weights
				};
			}
		}

		public void SaveNetworkData(NeuralNetworkData networkData)
		{

		}
	}
}
