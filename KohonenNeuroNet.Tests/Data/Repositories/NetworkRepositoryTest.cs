using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using KohonenNeuroNet.Data.UnitOfWork;
using System.Linq;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Tests
{
	/// <summary>
	/// Тест репозитория сетей.
	/// </summary>
	[TestClass]
	public class NetworkRepositoryTest : BaseTest
	{
		/// <summary>
		/// Тест выборки по идентификатору.
		/// </summary>
		[TestMethod]
		public void ShouldGetNetworkById()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				var list = unitOfWork.NetworkRepository.GetAll();
				Assert.IsNotNull(list);

				if (list.Any())
				{
					var network = list.First();
					var foundNetwork = unitOfWork.NetworkRepository.GetByID(network.NetworkId);
					Assert.IsNotNull(foundNetwork);
					Assert.IsInstanceOfType(foundNetwork, typeof(NetworkBase));
					Assert.AreEqual(network.NetworkId, foundNetwork.NetworkId);
				}
			}
		}

		/// <summary>
		/// Тест выборки.
		/// </summary>
		[TestMethod]
		public void ShouldGetAllNetworks()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				var list = unitOfWork.NetworkRepository.GetAll();
				Assert.IsNotNull(list);
			}
		}

		/// <summary>
		/// Тест вставки.
		/// </summary>
		[TestMethod]
		public void ShouldCrudNetwork()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				NetworkBase insertedNetwork = null;
				try
				{
					// Create
					var network = new NetworkBase()
					{
						Name = "New test network"
					};
					var id = unitOfWork.NetworkRepository.Insert(network);
					Assert.IsTrue(id > 0);

					// Read
					insertedNetwork = unitOfWork.NetworkRepository.GetByID(id);
					Assert.IsNotNull(insertedNetwork);
					Assert.AreEqual(id, insertedNetwork.NetworkId);

					// Update
					insertedNetwork.Name = "Updated test network";
					unitOfWork.NetworkRepository.Update(insertedNetwork);

					insertedNetwork = unitOfWork.NetworkRepository.GetByID(id);
					Assert.IsNotNull(insertedNetwork);
					Assert.AreEqual(id, insertedNetwork.NetworkId);
					Assert.AreEqual("Updated test network", insertedNetwork.Name);

					// Delete
					unitOfWork.NetworkRepository.Delete(insertedNetwork);
					insertedNetwork = unitOfWork.NetworkRepository.GetByID(id);
					Assert.IsNull(insertedNetwork);
				}
				finally
				{
					if (insertedNetwork != null)
					{
						unitOfWork.NetworkRepository.Delete(insertedNetwork);
					}
				}
			}
		}
	}
}
