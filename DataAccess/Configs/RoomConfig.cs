using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configs
{
	public class RoomConfig : IEntityTypeConfiguration<Room>
	{
		public void Configure(EntityTypeBuilder<Room> builder)
		{
			builder.HasIndex(r => r.Name)
				.IsUnique();

			builder.Property(r => r.Name)
				.IsRequired();
			
			builder.Property(r => r.Description)
				.IsRequired();	
			
			builder.Property(r => r.Space)
				.IsRequired();

			builder.HasOne(rt => rt.RoomType)
				.WithMany(r => r.Rooms)
				.HasForeignKey(r => r.RoomTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(p => p.Property)
				.WithMany(r => r.Rooms)
				.HasForeignKey(r => r.PropertyId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(rf => rf.RoomFacilities)
			   .WithOne(rf => rf.Room)
			   .HasForeignKey(rf => rf.RoomId)
			   .OnDelete(DeleteBehavior.Restrict);

		}
	}
}
