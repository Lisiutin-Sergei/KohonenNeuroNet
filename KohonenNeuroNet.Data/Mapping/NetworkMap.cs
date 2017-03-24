﻿using Dapper.FluentMap.Dommel.Mapping;
using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Data.Mapping
{
	/// <summary>
	/// Маппинг сущности "Нейронная сеть" на БД.
	/// </summary>
	public class NetworkMap : DommelEntityMap<Network>
	{
		public NetworkMap()
		{
			ToTable("network");

			Map(e => e.Id)
				.IsKey()
				.IsIdentity()
				.ToColumn("id");
			Map(e => e.Name)
				.ToColumn("name");
			Map(e => e.CreatedOn)
				.ToColumn("created_on");
		}
	}
}
