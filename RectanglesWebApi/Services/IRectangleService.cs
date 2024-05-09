using Microsoft.AspNetCore.Mvc;
using RectanglesWebApi.Models;

namespace RectanglesWebApi.Services
{
	public interface IRectangleService
	{
		/// <summary>
		/// Add rectangle to collection of rectangles
		/// </summary>
		/// <param name="rectangle">New rectangle</param>
		/// <returns>Result of operation</returns>
		Task<IActionResult> AddRectangle(Rectangle rectangle);

		/// <summary>
		/// Get all rectangles
		/// </summary>
		/// <returns>Collesction of rectangles</returns>
		Task<List<Rectangle>> GetRectangles();

		/// <summary>
		/// Get rectangle by id
		/// </summary>
		/// <param name="id">Id of rectangle for search</param>
		/// <returns>Rectangle by given id or null if rectangle is not presented in the collection</returns>
		Task<Rectangle> GetRectangleById(int id);

		/// <summary>
		/// Update existing rectangle
		/// </summary>
		/// <param name="rectangle">Updated rectangle</param>
		/// <returns>Result of updating</returns>
		Task<IActionResult> UpdateRectangle(Rectangle rectangle);

		/// <summary>
		/// Delete rectangle by id
		/// </summary>
		/// <param name="id">Id of rectangle for delete</param>
		/// <returns>Result of delete opeeration</returns>
		Task<IActionResult> DeleteRectangle(int id);

		/// <summary>
		/// Method for finding intersected Rectangles with Segment
		/// </summary>
		/// <param name="segment">Input segment</param>
		/// <returns>Collection of Rectangles that intersecting given Segment</returns>
		Task<IEnumerable<Rectangle>> SearchIntersectionsWithSegment(Segment segment);
	}
}
