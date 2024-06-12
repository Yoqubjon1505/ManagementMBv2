using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<CashFlow> CashFlows { get; set; }
        public DbSet<FinancialIndicators> FinancialIndicators { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<MaterialResources> MaterialResources { get; set; }
        public DbSet<Liabilitiies> Liabilitiies { get; set; }
        public DbSet<Debtors> Debtors { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BaseEntity>();
            modelBuilder.Entity<Product>(entity => entity.HasKey(p => p.Id));
            modelBuilder.Entity<Category>(entity => entity.HasKey(cat => cat.Id));
            modelBuilder.Entity<Balance>(entity => entity.HasKey(b => b.Id));
            modelBuilder.Entity<CashFlow>(entity => entity.HasKey(c => c.Id));
            modelBuilder.Entity<FinancialIndicators>(entity => entity.HasKey(f => f.Id));
            modelBuilder.Entity<Purchase>(entity => entity.HasKey(p => p.Id));
            modelBuilder.Ignore<User>();
            modelBuilder.Entity<Admin>(entity => entity.HasKey(a => a.Id));

            modelBuilder.Entity<Owner>(entity => entity.HasKey(o => o.Id));
            modelBuilder.Entity<Worker>(entity => entity.HasKey(w => w.Id));
            modelBuilder.Entity<Expenses>(entity => entity.HasKey(e => e.Id));
            
            modelBuilder.Entity<Sale>(entity => entity.HasKey(e => e.Id));
            modelBuilder.Entity<Purchase>(entity => entity.HasKey(e => e.Id));

            modelBuilder.Entity<MaterialResources>(entity => entity.HasKey(m => m.Id));
            modelBuilder.Entity<Liabilitiies>(entity => entity.HasKey(m => m.Id));
            modelBuilder.Entity<Debtors>(entity => entity.HasKey(m => m.Id));

        }
    }
}
