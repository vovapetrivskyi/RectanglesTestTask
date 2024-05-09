using RectanglesWebApi.Models;
using RectanglesWebApi.Services;

namespace RectanglesWebApi_Tests
{
	public class RectanglesTests
	{
		private IRectangleService _RectangleService;

		private const int RectanglesCount = 7;

		public RectanglesTests()
		{
			_RectangleService = IRectangleServiceMock.GetMock();
		}

		[Fact]
		public async void GetRectangles_Count_Equal()
		{
			var rectangles = await _RectangleService.GetRectangles();

			Assert.Equal(rectangles?.Count, RectanglesCount);
		}

		[Fact]
		public async void GetRectangles_Count_NotEqual()
		{
			var rectangles = await _RectangleService.GetRectangles();

			Assert.NotEqual(rectangles?.Count, 3);
		}

		[Fact]
		public async void GetRectangleById_Exists()
		{
			var rectangle = await _RectangleService.GetRectangleById(1);

			Assert.NotNull(rectangle);
		}

		[Fact]
		public async void GetRectangleById_NotExists()
		{
			var rectangle = await _RectangleService.GetRectangleById(8);

			Assert.Null(rectangle);
		}

		[Theory]
		[InlineData(1, 1, 2, 2, 0)]
		[InlineData(55, 6.58, -2.9, 74, 0)]
		[InlineData(24, 97, 70, 105, 2)]
		[InlineData(-10, -10, 10, 10, 3)]
		public async void SearchIntersectionsWithSegment_Count(double x1, double y1, double x2, double y2, int intersectedRectanglesCount)
		{
			var segment = new Segment()
			{
				X1 = x1,
				Y1 = y1,
				X2 = x2,
				Y2 = y2
			};

			var intersectedRectangles = await _RectangleService.SearchIntersectionsWithSegment(segment);

			Assert.Equal(intersectedRectangles.Count(), intersectedRectanglesCount);
		}
	}
}