using Dapper.FluentMap.Dommel.Mapping;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Data.Mapping
{
	/// <summary>
	/// Маппинг сущности "Нейрон" на БД.
	/// </summary>
	public class NeuronMap : DommelEntityMap<NeuronBase>
	{
		public NeuronMap()
		{
			ToTable("neuron");

			Map(e => e.NeuronId)
				.IsKey()
				.IsIdentity()
				.ToColumn("neuron_id");
			Map(e => e.NeuronNumber)
				.ToColumn("neuron_number");
			Map(e => e.NetworkId)
				.ToColumn("network_id");
		}
	}
}
