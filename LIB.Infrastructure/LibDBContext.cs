using LIB.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure
{
    public class LibDBContext : DbContext
    {
        public LibDBContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Editor> Editors{ get; set; }
        public DbSet<Publisher> Publishers{ get; set; }
        public DbSet<Genre> Genres{ get; set; }
        public DbSet<Library> Libraries{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
    }
}
