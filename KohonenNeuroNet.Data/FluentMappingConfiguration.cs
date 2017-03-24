using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using KohonenNeuroNet.Data.Mapping;

namespace KohonenNeuroNet.Data
{
	/// <summary>
	/// Конфигурация Fluent Mapping для всех сущностей проекта.
	/// </summary>
	public static class FluentMappingConfiguration
	{
		public static void ConfigureMapping()
		{
			FluentMapper.Initialize(config =>
			{
				config.AddMap(new NetworkMap());
				config.AddMap(new NeuronMap());
				config.AddMap(new InputAttributeMap());
				config.AddMap(new WeightMap());
				config.ForDommel();
			});
		}
	}
}
