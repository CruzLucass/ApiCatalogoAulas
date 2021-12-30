using Microsoft.EntityFrameworkCore;
using System;
using ApiCatalogoAulas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ApiCatalogoAulas.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Modulo> Modulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Modulo>()
                .HasData(
                    new Modulo { Id=1, Nome="Backend"},
                    new Modulo { Id=2, Nome="Frontend"},
                    new Modulo { Id=3, Nome="Devops"});

            modelBuilder.Entity<Aula>()
                .HasData(
                    new Aula { Id = 1, Nome = ".Net Core", Data = DateTime.Parse("19/01/2022"), ModuloId = 1 },
                    new Aula { Id = 2, Nome = "C# MVC", Data = DateTime.Parse("20/01/2022"), ModuloId = 1 },
                    new Aula { Id = 3, Nome = "Web API .Net", Data = DateTime.Parse("21/01/2022"), ModuloId = 1 },
                    new Aula { Id = 4, Nome = "React.JS", Data = DateTime.Parse("19/01/2022"), ModuloId = 2 },
                    new Aula { Id = 5, Nome = "React Native", Data = DateTime.Parse("20/01/2022"), ModuloId = 2 },
                    new Aula { Id = 6, Nome = "Html 5 e Css 3", Data = DateTime.Parse("21/01/2022"), ModuloId = 2 },
                    new Aula { Id = 7, Nome = "Kubernetes", Data = DateTime.Parse("19/01/2022"), ModuloId = 3 },
                    new Aula { Id = 8, Nome = "Cloud", Data = DateTime.Parse("20/01/2022"), ModuloId = 3 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
