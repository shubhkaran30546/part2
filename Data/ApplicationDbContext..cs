//using System.Collections.Generic;
//using System.Reflection.Emit;

//public class ApplicationDbContext : DbContext
//{
//    public DbSet<Picture> Pictures { get; set; }

//    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//    : base(options)
//    {
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//        modelBuilder.Entity<Picture>().HasData(
//            new Picture { Id = 1, Title = "Sample Image 1", FileName = "image1.jpg", FilePath = "/images/image1.jpg", AltText = "Sample Image 1" },
//            new Picture { Id = 2, Title = "Sample Image 2", FileName = "image2.jpg", FilePath = "/images/image2.jpg", AltText = "Sample Image 2" }
//        );
//    }
//}
