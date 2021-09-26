using DataAccess.Configs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
	public class Context : DbContext
	{
		public DbSet<RoomType> RoomTypes { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Property> Properties { get; set; }
		public DbSet<Facility> Facilities { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=booking_reservation_db;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new RoomTypeConfig());
			modelBuilder.ApplyConfiguration(new RoomConfig());
			modelBuilder.ApplyConfiguration(new PropertyConfig());
			modelBuilder.ApplyConfiguration(new FacilityConfig());

			modelBuilder.Entity<FacilityRoom>()
				.HasKey(fr => new { fr.FacilityId, fr.RoomId});
		}

		public override int SaveChanges()
		{
			return HandleSaveChangesOverride();
		}

		private int HandleSaveChangesOverride()
		{
			foreach (var item in ChangeTracker.Entries())
			{
				if (item.Entity is BaseEntity baseEntity)
				{
					switch (item.State)
					{
						case EntityState.Added:
							baseEntity.CreatedAt = DateTime.Now;
							break;

						case EntityState.Modified:
							/// <summary>
							///     If entity is soft deleted
							///     DeletedAt field is populated
							///     UpdatedAt field keeps date if it already existed, if not - it's set to null
							/// </summary>
							/// <returns></returns>

							if (baseEntity.DeletedAt == null)
							{
								baseEntity.UpdatedAt = DateTime.Now;
							}
							else
							{
								if (baseEntity.UpdatedAt == null)
								{
									baseEntity.UpdatedAt = null;
								}
							}
							break;
					}
				}
			}
			return base.SaveChanges();
		}
	}
}