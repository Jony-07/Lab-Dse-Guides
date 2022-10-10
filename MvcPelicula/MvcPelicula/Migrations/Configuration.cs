namespace MvcPelicula.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using MvcPelicula.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcPelicula.Models.PeliculaDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcPelicula.Models.PeliculaDBContext context)
        {
                 context.Peliculas.AddOrUpdate(i => i.Titulo,
                 new Pelicula
                 {
                     Titulo = "John Wick",
                     FechaLanzamiento = DateTime.Parse("2014-10-24"),
                     Genero = "Accion",
                     Calificacion = "D",
                     Productor = "Chad Staheliski",
                     Precio = 6.99M
                 },
                 new Pelicula
                 {
                     Titulo = "John Wick II",
                     FechaLanzamiento = DateTime.Parse("2015-10-26"),
                     Genero = "Accion",
                     Calificacion = "D",
                     Productor = "Erica Lee",
                     Precio = 6.99M
                 },
                 new Pelicula
                 {
                     Titulo = "John Wick III",
                     FechaLanzamiento = DateTime.Parse("2019-05-17"),
                     Genero = "Accion",
                     Calificacion = "D",
                     Productor = "Erica Lee",
                     Precio = 6.99M
                 },
                 new Pelicula
                 {
                     Titulo = "Votos de Amor",
                     FechaLanzamiento = DateTime.Parse("2012-02-06"),
                     Genero = "Romance",
                     Calificacion = "D",
                     Productor = "Gary Barber",
                     Precio = 6.99M
                                    }
              );

        }
    }
}
