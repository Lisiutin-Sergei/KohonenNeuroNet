using Microsoft.Extensions.Configuration;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace KohonenNeuroNet.Interface.DI
{
	/// <summary>
	/// Контейнер зависимостей.
	/// </summary>
	public class IoC
	{
		protected IoC()
		{
			var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"]?.ConnectionString;
			if (connectionString == null)
			{
				throw new Exception("Не задана строка подключения к БД");
			}
			var config = new List<KeyValuePair<string, string>>()
			{
				new KeyValuePair<string, string>("Data:DbContext:ConnectionString", connectionString)
			};

			Configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddInMemoryCollection(config)
				.Build();
		}
		private static IoC _instance;
		public static IoC Instance
		{
			get
			{
				return IoC._instance ?? (IoC._instance = new IoC());
			}
		}
		
		/// <summary>
		/// Конфигурация проекта с подключением к БД.
		/// </summary>
		public IConfigurationRoot Configuration { get; }

		/// <summary>
		/// Ядро IoC контейнера.
		/// </summary>
		protected IKernel _kernel;

		/// <summary>
		/// Инициализировать контейнер.
		/// </summary>
		/// <param name="kernel">Ядро контейнера.</param>
		public void Initialize(IKernel kernel)
		{
			_kernel = kernel;
			ServiceConfigurator.ConfigureServices(_kernel, Configuration);
		}
		
		/// <summary>
		/// Получить реализацию интерфейса.
		/// </summary>
		/// <typeparam name="S">Интрерфейс.</typeparam>
		/// <param name="arguments">Аргументы.</param>
		/// <returns>Реализация интерфейса.</returns>
		public S Resolve<S>(params NinjectArgument[] arguments)
		{
			return _kernel.Get<S>(arguments);
		}

		/// <summary>
		/// Создать аргумент ninject.
		/// </summary>
		/// <param name="name">Название аргумента.</param>
		/// <param name="value">Значение.</param>
		/// <returns>Аргумент.</returns>
		public static NinjectArgument GetArgument(string name, object value)
		{
			return new NinjectArgument(name, value);
		}

		/// <summary>
		/// Класс аргументов для ninject.
		/// </summary>
		public class NinjectArgument : ConstructorArgument
		{
			public NinjectArgument(string name, object value)
				: base(name, value)
			{
			}
		}
	}
}
