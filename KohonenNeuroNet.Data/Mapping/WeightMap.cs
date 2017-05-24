using Dapper.FluentMap.Dommel.Mapping;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Data.Mapping
{
	/// <summary>
	/// Маппинг сущности "Вес" на БД.
	/// </summary>
	public class WeightMap : DommelEntityMap<WeightBase>
	{
		public WeightMap()
		{
			ToTable("weight");

			Map(e => e.WeightId)
				.IsKey()
				.IsIdentity()
				.ToColumn("weight_id");
			Map(e => e.Value)
				.ToColumn("value");
			Map(e => e.InputAttributeId)
				.ToColumn("input_attribute_id");
			Map(e => e.NeuronId)
				.ToColumn("neuron_id");
			Map(e => e.NeuronNumber)
				.ToColumn("neuron_number");
			Map(e => e.InputAttributeNumber)
				.ToColumn("input_attribute_number");
		}
	}
}
