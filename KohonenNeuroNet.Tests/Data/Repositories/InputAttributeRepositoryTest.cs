using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using KohonenNeuroNet.Data.UnitOfWork;
using System.Linq;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Tests
{
	/// <summary>
	/// Тест репозитория входных атрибутов.
	/// </summary>
	[TestClass]
	public class InputAttributeRepositoryTest : BaseTest
	{
		/// <summary>
		/// Тест выборки по идентификатору.
		/// </summary>
		[TestMethod]
		public void ShouldGetInputAttributeById()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				var list = unitOfWork.InputAttributeRepository.GetAll();
				Assert.IsNotNull(list);

				if (list.Any())
				{
					var inputAttribute = list.First();
					var foundInputAttribute = unitOfWork.InputAttributeRepository.GetByID(inputAttribute.Id);
					Assert.IsNotNull(foundInputAttribute);
					Assert.IsInstanceOfType(foundInputAttribute, typeof(InputAttribute));
					Assert.AreEqual(inputAttribute.Id, foundInputAttribute.Id);
				}
			}
		}

		/// <summary>
		/// Тест выборки.
		/// </summary>
		[TestMethod]
		public void ShouldGetAllInputAttributes()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				var list = unitOfWork.InputAttributeRepository.GetAll();
				Assert.IsNotNull(list);
			}
		}

		/// <summary>
		/// Тест вставки.
		/// </summary>
		[TestMethod]
		public void ShouldCrudInputAttribute()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				InputAttribute insertedInputAttribute = null;
				Network network = null;
				try
				{
					// Create
					network = new Network()
					{
						Name = "New test network"
					};
					var networkId = unitOfWork.NetworkRepository.Insert(network);
					network = unitOfWork.NetworkRepository.GetByID(networkId);

					var inputAttribute = new InputAttribute()
					{
						Name = "Test Attribute",
						NetworkId = networkId
					};
					var attributeId = unitOfWork.InputAttributeRepository.Insert(inputAttribute);

					// Read
					insertedInputAttribute = unitOfWork.InputAttributeRepository.GetByID(attributeId);
					Assert.IsNotNull(insertedInputAttribute);
					Assert.AreEqual(attributeId, insertedInputAttribute.Id);

					// Update
					insertedInputAttribute.Name = "Updated Test Attribute";
					unitOfWork.InputAttributeRepository.Update(insertedInputAttribute);

					insertedInputAttribute = unitOfWork.InputAttributeRepository.GetByID(attributeId);
					Assert.IsNotNull(insertedInputAttribute);
					Assert.AreEqual(attributeId, insertedInputAttribute.Id);
					Assert.AreEqual("Updated Test Attribute", insertedInputAttribute.Name);

					// Delete
					unitOfWork.InputAttributeRepository.Delete(insertedInputAttribute);
					insertedInputAttribute = unitOfWork.InputAttributeRepository.GetByID(attributeId);
					Assert.IsNull(insertedInputAttribute);
				}
				finally
				{
					if (insertedInputAttribute != null)
					{
						unitOfWork.InputAttributeRepository.Delete(insertedInputAttribute);
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
