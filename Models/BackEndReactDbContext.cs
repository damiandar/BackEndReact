using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BackEndReact.Models;

namespace BackEndReact.Models
{
    public partial class BackEndReactDbContext : DbContext
    {
        public DbSet<Automotor> Automotores { get;  set; }
        public DbSet<Comentario> Comentarios {get;set;}

        public BackEndReactDbContext()
        {
        }

        public BackEndReactDbContext(DbContextOptions<BackEndReactDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<BackEndReact.Models.Comentario> Comentario { get; set; }

        public DbSet<BackEndReact.Models.Automotor> Automotor { get; set; }
    }
}
