using LIB.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIB.Infrastructure
{
    public class LibDBContext : DbContext
    {
        public LibDBContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var allEntities = modelBuilder.Model.GetEntityTypes();
            foreach (var entity in allEntities)
            {
                entity.AddProperty("DateCreated", typeof(DateTime));
                entity.AddProperty("DateUpdated", typeof(DateTime));
            }

        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added
                || e.State == EntityState.Modified);
            foreach (var entityEntry in entries)
            {
                entityEntry.Property("DateUpdated").CurrentValue = DateTime.Now;
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("DateCreated").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Editor> Editors{ get; set; }
        public DbSet<Publisher> Publishers{ get; set; }
        public DbSet<Genre> Genres{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<BookEditor> BookEditors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookPublisher> BookPublishers{ get; set; }
        public DbSet<EditorPublisher> EditorPublishers{ get; set; }
    }
}
