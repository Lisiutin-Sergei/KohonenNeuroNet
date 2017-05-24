using Dapper.FluentMap.Dommel.Mapping;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Data.Mapping
{
	/// <summary>
	/// Маппинг сущности "Нейронная сеть" на БД.
	/// </summary>
	public class NetworkMap : DommelEntityMap<NetworkBase>
	{
		public NetworkMap()
		{
			ToTable("network");

			Map(e => e.NetworkId)
				.IsKey()
				.IsIdentity()
				.ToColumn("network_id");
			Map(e => e.Name)
				.ToColumn("network_name");
			Map(e => e.CreatedOn)
				.ToColumn("created_on");
		}
	}
}
