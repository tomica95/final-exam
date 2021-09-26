using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configs
{
	public class PropertyConfig : IEntityTypeConfiguration<Property>
	{
		public void Configure(EntityTypeBuilder<Property> builder)
		{
			builder.HasIndex(r => r.Type)
				.IsUnique();

			builder.Property(r => r.Type)
				.IsRequired();	
			
			builder.Property(r => r.Address)
				.IsRequired();
			
			builder.Property(r => r.City)
				.IsRequired();
			
			builder.Property(r => r.Country)
				.IsRequired();

			builder.HasMany(r => r.Rooms)
				.WithOne(p => p.Property)
				.HasForeignKey(r => r.PropertyId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
