namespace Portfolio.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Portfolio.Models;

    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LikedComments> LikedComments { get; set; }
        public DbSet<LikedProjects> LikedProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasData(
               new Image { Id = 1, Path = "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515520/cld-sample-3.jpg" },
               new Image { Id = 2, Path = "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515519/samples/dessert-on-a-plate.jpg" },
               new Image { Id = 3, Path = "path3" },
               new Image { Id = 4, Path = "path4" },
               new Image { Id = 5, Path = "path5" },
               new Image { Id = 6, Path = "path6" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Програмиране", Description = "Приложения, или сайтове, които съм напрвил", ImageId = 1 },
                new Category { Id = 2, Name = "3D моделиране", Description = "Това са проекти, свързани със 3D моделиране и принтиране", ImageId = 2 },
                new Category { Id = 3, Name = "Електроника", Description = "Това са проекти, които използват техника, а може би и 3D моделиране", ImageId = 3 },
                new Category { Id = 4, Name = "Фотография", Description = "Интересни снимки, които съм правил наскоро", ImageId = 4 },
                new Category { Id = 5, Name = "Рисуване", Description = "Опити за рисуване ; )", ImageId = 5 },
                new Category { Id = 6, Name = "Други : )", Description = "Това са други проекти, които не съвпадат с другите категории", ImageId = 6 }
            );

            // User -> Image (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.ProfilePicture)
                .WithOne()
                .HasForeignKey<User>(u => u.ProfilePictureId)
                .OnDelete(DeleteBehavior.SetNull);

            // User -> Projects (One-to-Many)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Category -> Projects (One-to-Many)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // LikedProjects (Many-to-Many)
            modelBuilder.Entity<LikedProjects>()
                .HasKey(lp => new { lp.UserId, lp.ProjectId });

            modelBuilder.Entity<LikedProjects>()
                .HasOne(lp => lp.User)
                .WithMany(u => u.LikedProjects)
                .HasForeignKey(lp => lp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LikedProjects>()
                .HasOne(lp => lp.Project)
                .WithMany(p => p.LikedProjects)
                .HasForeignKey(lp => lp.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // LikedComments (Many-to-Many)
            modelBuilder.Entity<LikedComments>()
                .HasKey(lc => new { lc.UserId, lc.CommentId });

            modelBuilder.Entity<LikedComments>()
                .HasOne(lc => lc.User)
                .WithMany(u => u.LikedComments)
                .HasForeignKey(lc => lc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LikedComments>()
                .HasOne(lc => lc.Comment)
                .WithMany(c => c.LikedComments)
                .HasForeignKey(lc => lc.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Comment -> Project (Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.NoAction); // Specify NoAction to avoid cycles or multiple cascade paths

            // Comment -> User (Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Comment -> Image (One-to-Many)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Image)
                .WithMany()
                .HasForeignKey(c => c.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            // Category -> Image (One-to-One)
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Image)
                .WithOne()
                .HasForeignKey<Category>(c => c.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}