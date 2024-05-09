using Microsoft.EntityFrameworkCore;
using RectanglesWebApi.Models;

namespace RectanglesWebApi.Database
{
	public class DatabaseContext : DbContext
	{
		public virtual DbSet<Rectangle> Rectangles { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{

		}

		public DatabaseContext()
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Rectangle>(entity =>
			{
				entity.HasKey(r => r.Id);
				entity.Property(r => r.Id).ValueGeneratedOnAdd();
			});
		}
	}
}
