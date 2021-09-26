using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandHendler;
using Application.Commands.Facility;
using Application.Commands.Property;
using Application.Commands.Room;
using Application.Commands.RoomType;
using Application.Queries.Facility;
using Application.Queries.Property;
using Application.Queries.Room;
using Application.Queries.RoomType;
using DataAccess;
using Implementation.Commands.FacilityCommands;
using Implementation.Commands.PropertyCommand;
using Implementation.Commands.RoomCommands;
using Implementation.Commands.RoomTypeCommands;
using Implementation.Profiles;
using Implementation.Queries.Facility;
using Implementation.Queries.Property;
using Implementation.Queries.Room;
using Implementation.Queries.RoomType;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookingReservation
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<CommandExecutor>();

			#region DbContext
			services.AddTransient<Context>();
			#endregion
																												 
			#region Automapper
			services.AddAutoMapper(typeof(RoomTypeProfile), typeof(RoomProfile), typeof(PropertyProfile), typeof(FacilityProfile));
			#endregion

			#region RoomType

			services.AddTransient<ICreateRoomType, EFCreateRoomType>();
			services.AddTransient<IGetAllRoomTypes, EFGetAllRoomTypesQuery>();
			#endregion	  

			#region Room
			services.AddTransient<ICreateRoom, EFCreateRoom>();
			services.AddTransient<IGetAllRooms, EFGetAllRoomsQuery>();
			#endregion 

			#region Property
			services.AddTransient<ICreateProperty, EFCreateProperty>();
			services.AddTransient<IGetAllProperties, EFGetAllProperties>();
			#endregion 

			#region Facility
			services.AddTransient<ICreateFacility, EFCreateFacility>();
			services.AddTransient<IGetAllFacilities, EFGetAllFacilities>();
			#endregion

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(x =>
			{
				x.AllowAnyOrigin();
				x.AllowAnyMethod();
				x.AllowAnyHeader();
			});

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
