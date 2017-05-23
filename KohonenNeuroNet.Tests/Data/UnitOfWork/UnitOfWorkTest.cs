using Microsoft.VisualStudio.TestTools.UnitTesting;
using KohonenNeuroNet.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace KohonenNeuroNet.Tests
{
	/// <summary>
	/// Тест для UnitOfWork.
	/// </summary>
	[TestClass]
	public class UnitOfWorkTest : BaseTest
	{
		/// <summary>
		/// Тест соединения с базой.
		/// </summary>
		[TestMethod]
		public void ConnectionTest()
		{
			IConfigurationRoot configuration = GetConfiguration();
			using (UnitOfWork unitOfWork = new UnitOfWork(configuration))
			{
				unitOfWork.BeginTransaction();
				var list = unitOfWork.NetworkRepository.GetAll();
				unitOfWork.RollbackTransaction();
			}
		}
	}
}
