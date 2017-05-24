using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using KohonenNeuroNet.Data.UnitOfWork;
using System.Linq;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Tests
{
	/// <summary>
	/// Тест репозитория нейронов.
	/// </summary>
	[TestClass]
	public class NeuronRepositoryTest : BaseTest
	{
		/// <summary>
		/// Тест выборки по идентификатору.
		/// </summary>
		[TestMethod]
		public void ShouldGetNeuronById()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				var list = unitOfWork.NeuronRepository.GetAll();
				if (list.Any())
				{
					var neuron = list.First();
					var foundNeuron = unitOfWork.NeuronRepository.GetByID(neuron.NeuronId);
					Assert.IsNotNull(foundNeuron);
					Assert.IsInstanceOfType(foundNeuron, typeof(NeuronBase));
					Assert.AreEqual(neuron.NeuronId, foundNeuron.NeuronId);
				}
			}
		}

		/// <summary>
		/// Тест выборки.
		/// </summary>
		[TestMethod]
		public void ShouldGetAllNeurons()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				var list = unitOfWork.NeuronRepository.GetAll();
				Assert.IsNotNull(list);
			}
		}

		/// <summary>
		/// Тест вставки.
		/// </summary>
		[TestMethod]
		public void ShouldCrudNeuron()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				NeuronBase insertedNeuron = null;
				NetworkBase network = null;
				try
				{
					network = new NetworkBase()
					{
						Name = "Test network"
					};
					var networkId = unitOfWork.NetworkRepository.Insert(network);
					network = unitOfWork.NetworkRepository.GetByID(networkId);

					// Create
					var neuron = new NeuronBase()
					{
						NetworkId = network.NetworkId,
						NeuronNumber = 2
					};
					var id = unitOfWork.NeuronRepository.Insert(neuron);
					Assert.IsTrue(id > 0);

					// Read
					insertedNeuron = unitOfWork.NeuronRepository.GetByID(id);
					Assert.IsNotNull(insertedNeuron);
					Assert.AreEqual(id, insertedNeuron.NeuronId);

					// Update
					insertedNeuron.NeuronNumber = 3;
					unitOfWork.NeuronRepository.Update(insertedNeuron);

					insertedNeuron = unitOfWork.NeuronRepository.GetByID(id);
					Assert.IsNotNull(insertedNeuron);
					Assert.AreEqual(id, insertedNeuron.NeuronId);
					Assert.AreEqual(3, insertedNeuron.NeuronNumber);

					// Delete
					unitOfWork.NeuronRepository.Delete(insertedNeuron);
					insertedNeuron = unitOfWork.NeuronRepository.GetByID(id);
					Assert.IsNull(insertedNeuron);
				}
				finally
				{
					if (insertedNeuron != null)
					{
						unitOfWork.NeuronRepository.Delete(insertedNeuron);
					}
					if (network != null)
					{
						unitOfWork.NetworkRepository.Delete(network);
					}
				}
			}
		}
	}
}
