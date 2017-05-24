using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using KohonenNeuroNet.Data.UnitOfWork;
using System.Linq;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Tests
{
	/// <summary>
	/// Тест репозитория весов.
	/// </summary>
	[TestClass]
	public class WeightRepositoryTest : BaseTest
	{
		/// <summary>
		/// Тест выборки по идентификатору.
		/// </summary>
		[TestMethod]
		public void ShouldGetWeightById()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				var list = unitOfWork.WeightRepository.GetAll();
				if (list.Any())
				{
					var weight = list.First();
					var foundWeight = unitOfWork.WeightRepository.GetByID(weight.WeightId);
					Assert.IsNotNull(foundWeight);
					Assert.IsInstanceOfType(foundWeight, typeof(WeightBase));
					Assert.AreEqual(weight.WeightId, foundWeight.WeightId);
				}
			}
		}

		/// <summary>
		/// Тест выборки.
		/// </summary>
		[TestMethod]
		public void ShouldGetAllWeights()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				var list = unitOfWork.WeightRepository.GetAll();
				Assert.IsNotNull(list);
			}
		}
	}
}
