using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using RectanglesWebApi.Database;
using RectanglesWebApi.Models;
using RectanglesWebApi.Services;
using RectanglesWebApi.Services.Implementations;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RectanglesWebApi_Tests
{
	public class IRectangleServiceMock
	{
		public static IRectangleService GetMock()
		{
			List<Rectangle> rectangles = GenerateTestData();

			var databaseMock = new Mock<DatabaseContext>();

			databaseMock.Setup<DbSet<Rectangle>>(x => x.Rectangles).ReturnsDbSet(rectangles);

			return new RectangleService(databaseMock.Object);
		}

		private static List<Rectangle> GenerateTestData()
		{
			List<Rectangle> rectangles = new()
			{
				new Rectangle()
				{
					Id = 1,
					X = 10,
					Y = 20,
					Width = 30,
					Height = 25
				},
				new Rectangle()
				{
					Id = 2,
					X = -5,
					Y = -9.5,
					Width = 2,
					Height = 4
				},
				new Rectangle()
				{
					Id = 3,
					X = 3.7,
					Y = 1.5,
					Width = 0.5,
					Height = 78
				},
				new Rectangle()
				{
					Id = 4,
					X = -10,
					Y = -20,
					Width = 15,
					Height = 3
				},
				new Rectangle()
				{
					Id = 5,
					X = 5,
					Y = 7,
					Width = 3,
					Height = 7
				},
				new Rectangle()
				{
					Id = 6,
					X = 25,
					Y = 98,
					Width = 50,
					Height = 15

				},
				new Rectangle()
				{
					Id = 7,
					X = 35,
					Y = 55,
					Width = 60,
					Height = 70
				}
			};

			return rectangles;
		}
	}
}
