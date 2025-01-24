namespace Portfolio.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MoreResource> MoreResources { get; set; }
        public DbSet<ResourceLink> ResourceLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            // User -> Role (Many-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRole)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
             .HasOne(u => u.ProfilePicture)
             .WithOne()
             .HasForeignKey<User>(u => u.ProfilePictureId)
             .OnDelete(DeleteBehavior.SetNull);

           
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProjectId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Image)
                .WithMany()
                .HasForeignKey(c => c.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<MoreResource>()
                .HasMany(m => m.Images)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ResourceLink>()
                .HasOne(r => r.MoreResource)
                .WithMany(m => m.Links)
                .HasForeignKey(r => r.MoreResourceId);


            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Програмиране", Description = "Приложения, или сайтове, които съм напрвил" },
            new Category { Id = 2, Name = "3D моделиране", Description = "Това са проекти, свързани със 3D моделиране и принтиране" },
            new Category { Id = 3, Name = "Електроника", Description = "Това са проекти, които използват техника, а може би и 3D моделиране" },
            new Category { Id = 4, Name = "Фотография", Description = "Интересни снимки, които съм правил наскоро" },
            new Category { Id = 5, Name = "Рисуване", Description = "Опити за рисуване ; )" },
            new Category { Id = 6, Name = "Други : )", Description = "Това са други проекти, които не съвпадат с другите категории" }
            );

            modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, RoleType = RoleType.Admin },
            new Role { Id = 2, RoleType = RoleType.User }
            );
            //modelBuilder.Entity<Flower>().HasData(

            //new Flower { Id = 1, Price = 2, Type = "Rose" },

            //new Flower { Id = 2, Price = 4, Type = "SunFlower" },

            //new Flower { Id = 3, Price = 5, Type = "Lostus" }



            //);

            base.OnModelCreating(modelBuilder);

        }
        //public DbSet<Portfolio.Models.Project> Project { get; set; }
    }
}
