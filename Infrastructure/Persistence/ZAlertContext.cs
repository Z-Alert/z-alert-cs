using Microsoft.EntityFrameworkCore;
using ZAlert.Api.Domain.Entity;

namespace ZAlert.Api.Infrastructure.Persistence
{
	public class ZAlertContext : DbContext
	{
		public ZAlertContext(DbContextOptions<ZAlertContext> options) : base(options) { }

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Dependente> Dependentes { get; set; }
		public DbSet<Alerta> Alertas { get; set; }
		public DbSet<Dispositivo> Dispositivos { get; set; }
		public DbSet<Localizacao> Localizacoes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Usuario>()
				.HasMany(u => u.Dependentes)
				.WithOne(d => d.Usuario)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Dependente>()
				.HasMany(d => d.Alertas)
				.WithOne(a => a.Dependente)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Dependente>()
				.HasMany(d => d.Localizacoes)
				.WithOne(l => l.Dependente)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Dependente>()
				.HasOne(d => d.Dispositivo)
				.WithOne(disp => disp.Dependente)
				.HasForeignKey<Dispositivo>(d => d.IdDisposit);

			base.OnModelCreating(modelBuilder);
		}
	}
}
