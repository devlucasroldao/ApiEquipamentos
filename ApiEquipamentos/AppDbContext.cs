using Microsoft.EntityFrameworkCore;

namespace ApiEquipamentos;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Equipamento> Equipamentos => Set<Equipamento>();
}