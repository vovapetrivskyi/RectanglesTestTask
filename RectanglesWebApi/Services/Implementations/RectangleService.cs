using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RectanglesWebApi.Database;
using RectanglesWebApi.Models;

namespace RectanglesWebApi.Services.Implementations
{
	public class RectangleService : IRectangleService
	{
		DatabaseContext _DatabaseContext;
		public RectangleService(DatabaseContext databaseContext)
		{
			_DatabaseContext = databaseContext;
		}

		public async Task<IActionResult> AddRectangle(Rectangle rectangle)
		{
			_DatabaseContext.Rectangles.Add(rectangle);

			await _DatabaseContext.SaveChangesAsync();

			return new OkResult();
		}

		public async Task<List<Rectangle>> GetRectangles()
		{
			return await _DatabaseContext.Rectangles.ToListAsync();
		}

		public async Task<Rectangle> GetRectangleById(int id)
		{
			return await _DatabaseContext.Rectangles.FirstOrDefaultAsync(r => r.Id == id);
		}

		public async Task<IActionResult> UpdateRectangle(Rectangle rectangle)
		{
			var existRectangle = await _DatabaseContext.Rectangles.FirstOrDefaultAsync(r => r.Id == rectangle.Id);

			if (existRectangle != null)
			{
				existRectangle.X = rectangle.X;
				existRectangle.Y = rectangle.Y;
				existRectangle.Width = rectangle.Width;
				existRectangle.Height = rectangle.Height;

				await _DatabaseContext.SaveChangesAsync();
			}
			else
			{
				return new NotFoundResult();
			}

			return new OkResult();
		}

		public async Task<IActionResult> DeleteRectangle(int id)
		{
			var existRectangle = await _DatabaseContext.Rectangles.FirstOrDefaultAsync(r => r.Id == id);

			if (existRectangle != null)
			{
				_DatabaseContext.Rectangles.Remove(existRectangle);

				await _DatabaseContext.SaveChangesAsync();
			}

			return new OkResult();
		}

		public async Task<IEnumerable<Rectangle>> SearchIntersectionsWithSegment(Segment segment)
		{
			return await _DatabaseContext.Rectangles.Where(r =>
					r.X < segment.X2 &&
					r.X + r.Width > segment.X1 &&
					r.Y < segment.Y2 &&
					r.Y + r.Height > segment.Y1
				).ToListAsync();
		}
	}
}
