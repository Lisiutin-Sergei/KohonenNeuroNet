using KohonenNeuroNet.Core.Interface.Data;
using KohonenNeuroNet.Core.Interface.Service;
using KohonenNeuroNet.Core.Service;
using KohonenNeuroNet.Data;
using KohonenNeuroNet.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Ninject;

namespace KohonenNeuroNet.Interface.DI
{
	/// <summary>
	/// Конфигуратор сервисов для контейнера зависимостей.
	/// </summary>
	public class ServiceConfigurator
	{
		public static void ConfigureServices(IKernel kernel, IConfiguration configuration)
		{
			kernel.Bind<IConfiguration>().ToMethod((serviceProvider) => configuration).InSingletonScope();

			ConfigureCoreServices(kernel);
			ConfigureDataServices(kernel);
		}

		/// <summary>
		/// Задать зависимости проекта .Core.
		/// </summary>
		/// <param name="kernel">Ядро IoC.</param>
		private static void ConfigureCoreServices(IKernel kernel)
		{
			kernel.Bind<INetworkService>().To<NetworkService>().InTransientScope();
		}

		/// <summary>
		/// Задать зависимости проекта .Data.
		/// </summary>
		/// <param name="kernel">Ядро IoC.</param>
		private static void ConfigureDataServices(IKernel kernel)
		{
			FluentMappingConfiguration.ConfigureMapping();
			kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>().InTransientScope();
		}
	}
}
