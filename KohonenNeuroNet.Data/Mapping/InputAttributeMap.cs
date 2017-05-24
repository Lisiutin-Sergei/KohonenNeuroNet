using Dapper.FluentMap.Dommel.Mapping;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Data.Mapping
{
	/// <summary>
	/// Маппинг сущности "Атрибут" на БД.
	/// </summary>
	public class InputAttributeMap : DommelEntityMap<InputAttributeBase>
	{
		public InputAttributeMap()
		{
			ToTable("input_attribute");

			Map(e => e.InputAttributeId)
				.IsKey()
				.IsIdentity()
				.ToColumn("input_attribute_id");
			Map(e => e.Name)
				.ToColumn("input_attribute_name");
			Map(e => e.InputAttributeNumber)
				.ToColumn("input_attribute_number");
			Map(e => e.NetworkId)
				.ToColumn("network_id");
		}
	}
}
