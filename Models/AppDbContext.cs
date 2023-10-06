using AppMVC.Models.Blogs;
using AppMVC.Models.Contacts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Models
{

    // AppMVC.Models.AppDbContext
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if(tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            builder.Entity<Category>(builder =>{
                builder.HasIndex(p => p.Slug).IsUnique();
            });

            builder.Entity<PostCategory>(entity => {
               entity.HasKey(c => new {c.PostID, c.CategoryID}); 
            });

            builder.Entity<Post>(entity => {
                entity.HasIndex(p => p.Slug).IsUnique();
            });


        }
        public DbSet<ContactModel> Contacts {get; set;}

        public DbSet<Category> category {get; set;}

        public DbSet<Post> posts {get; set;}

        public DbSet<PostCategory> postCategories {get; set;}
    }
}