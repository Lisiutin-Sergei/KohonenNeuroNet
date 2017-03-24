using Dapper.FluentMap.Dommel.Mapping;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Data.Mapping
{
	/// <summary>
	/// Маппинг сущности "Атрибут" на БД.
	/// </summary>
	public class InputAttributeMap : DommelEntityMap<InputAttribute>
	{
		public InputAttributeMap()
		{
			ToTable("input_attribute");

			Map(e => e.Id)
				.IsKey()
				.IsIdentity()
				.ToColumn("id");
			Map(e => e.Name)
				.ToColumn("name");
			Map(e => e.NetworkId)
				.ToColumn("network_id");
		}
	}
}
