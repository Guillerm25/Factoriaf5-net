using Microsoft.EntityFrameworkCore;

namespace CarouselImagesApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<CarouselSliders> Carousel { get; set; }
    }
}
