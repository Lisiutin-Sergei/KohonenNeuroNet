using Dapper.FluentMap.Dommel.Mapping;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Data.Mapping
{
	/// <summary>
	/// Маппинг сущности "Нейрон" на БД.
	/// </summary>
	public class NeuronMap : DommelEntityMap<Neuron>
	{
		public NeuronMap()
		{
			ToTable("neuron");

			Map(e => e.Id)
				.IsKey()
				.IsIdentity()
				.ToColumn("neuron_id");
			Map(e => e.OrderNumber)
				.ToColumn("order_number");
			Map(e => e.NetworkId)
				.ToColumn("network_id");
		}
	}
}
