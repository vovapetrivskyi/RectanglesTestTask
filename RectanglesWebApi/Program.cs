using Microsoft.EntityFrameworkCore;
using RectanglesWebApi.Database;
using RectanglesWebApi.Models;
using RectanglesWebApi.Services.Implementations;
using RectanglesWebApi.Services;

namespace RectanglesWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
				);

			builder.Services.AddTransient<IRectangleService, RectangleService>();

			var app = builder.Build();

			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

				dbContext.Database.EnsureCreated();
			}

			app.MapPost("/rectangles/AddRectangle", async (IRectangleService rectangleService, Rectangle rectangle) =>
			{
				await rectangleService.AddRectangle(rectangle);
			});

			app.MapGet("/rectangles/GetRectangles", async (IRectangleService rectangleService) =>
			{
				return await rectangleService.GetRectangles();
			});

			app.MapGet("/rectangles/GetRectangleById", async (IRectangleService rectangleService, int id) =>
			{
				return await rectangleService.GetRectangleById(id);
			});

			app.MapPut("/rectangles/UpdateRectangle", async (IRectangleService rectangleService, Rectangle rectangle) =>
			{
				await rectangleService.UpdateRectangle(rectangle);
			});

			app.MapDelete("/rectangles/DeleteRectangle", async (IRectangleService rectangleService, int id) =>
			{
				await rectangleService.DeleteRectangle(id);
			});

			app.MapPost("/rectangles/SearchIntersectionsWithSegment", async (IRectangleService rectangleService, Segment segment) =>
			{
				return await rectangleService.SearchIntersectionsWithSegment(segment);
			});

			app.Run();
		}
	}
}
