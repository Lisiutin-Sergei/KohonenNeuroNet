using KohonenNeuroNet.Core.Interface.Data;
using KohonenNeuroNet.Core.Interface.Service;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using KohonenNeuroNet.Core.Model.Domain;

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
		public List<Network> LoadAllNetworks()
		{
			using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create(_configuration))
			{
				return unitOfWork.NetworkRepository.GetAll()
					.ToList();
			}
		}

		public void SaveNetworkData()
		{

		}
	}
}
