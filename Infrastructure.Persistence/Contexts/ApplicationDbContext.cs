using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime,
            IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<ServiceField> ServiceFields { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionService> TransactionServices { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
                         .SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }

            builder.Entity<Transaction>().HasOne(x => x.Player)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.PlayerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<TransactionService>().HasOne(x => x.Transaction)
                .WithMany(x => x.TransactionServices)
                .HasForeignKey(x => x.TransactionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<TransactionService>().HasOne(x => x.Service)
                .WithMany(x => x.TransactionServices)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ServiceField>().HasOne(x => x.Service)
                .WithMany(x => x.ServiceFields)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ServiceField>().HasOne(x => x.Field)
                .WithMany(x => x.ServiceFields)
                .HasForeignKey(x => x.FieldId)
                .OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(builder);
        }
    }
}