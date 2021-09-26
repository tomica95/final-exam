using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configs
{
	public class FacilityConfig : IEntityTypeConfiguration<Facility>
	{
		public void Configure(EntityTypeBuilder<Facility> builder)
		{
			builder.HasIndex(f => f.Name)
			.IsUnique();

			builder.Property(f => f.Name)
				.IsRequired();

			builder.HasMany(fr => fr.FacilityRooms)
			   .WithOne(fr => fr.Facility)
			   .HasForeignKey(fr => fr.FacilityId)
			   .OnDelete(DeleteBehavior.Restrict);
		}
	}
}
