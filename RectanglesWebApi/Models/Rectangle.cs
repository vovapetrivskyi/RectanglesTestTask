namespace RectanglesWebApi.Models
{
	/// <summary>
	/// Class that represents rectangle by coordinates and size
	/// </summary>
	public class Rectangle
	{
		/// <summary>
		/// Id of the rectangle
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// X rectangle coordinate
		/// </summary>
		public double X { get; set; }
		/// <summary>
		/// Y rectangle coordinate
		/// </summary>
		public double Y { get; set; }
		/// <summary>
		/// Width of the rectangle
		/// </summary>
		public double Width { get; set; }
		/// <summary>
		/// Height of the rectangle
		/// </summary>
		public double Height { get; set; }
	}
}
