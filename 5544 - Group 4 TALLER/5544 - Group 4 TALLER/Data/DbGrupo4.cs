using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _5544___Group_4_TALLER.Models;

public class DbGrupo4 : DbContext
{
    public DbGrupo4(DbContextOptions<DbGrupo4> options)
        : base(options)
    {
    }

    public DbSet<Equipo> Equipo { get; set; } = default!;
    public DbSet<Jugador> Jugador { get; set; } = default!;
    public DbSet<Partido> Partido { get; set; } = default!;
    public DbSet<TablaPosiciones> TablaPosiciones { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>()
            .Property(e => e.Presupuesto)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Jugador>()
            .Property(j => j.Sueldo)
            .HasPrecision(18, 2);

        base.OnModelCreating(modelBuilder);
    }
}
