using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.WebAPI.Data
{
    public class LotteryDbContext : DbContext
    {
        public LotteryDbContext(DbContextOptions<LotteryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lottery>()
                .ToTable("Lotteries");

            modelBuilder.Entity<Lottery>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Lottery>()
                .Property(l => l.Number)
                .IsRequired();

            modelBuilder.Entity<Lottery>()
                .HasIndex(l => l.Number)
                .HasName("INX_NUMBER");

            modelBuilder.Entity<Lottery>()
                .HasMany(l => l.Tickets)
                .WithOne(t => t.Lottery)
                .HasForeignKey(t => t.LotteryId);

            modelBuilder.Entity<Ticket>()
                .ToTable("Tickets");

            modelBuilder.Entity<Ticket>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Number)
                .IsRequired();

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Number)
                .HasMaxLength(7);

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.Number)
                .HasName("INX_NUMBER");

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => new { t.LotteryId, t.Number })
                .IsUnique();

            modelBuilder.Entity<Lottery>().HasData(
                new Lottery { Id = 1, Number = "101", DateOfConducting = new DateTime(2018, 5, 1) },
                new Lottery { Id = 2, Number = "102", DateOfConducting = new DateTime(2018, 5, 10) },
                new Lottery { Id = 3, Number = "103", DateOfConducting = new DateTime(2018, 5, 15) });

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, Number = "AS7239G", LotteryId = 1, IsWinning = false },
                new Ticket { Id = 2, Number = "AL7249J", LotteryId = 1, IsWinning = false },
                new Ticket { Id = 3, Number = "BS7K3LP", LotteryId = 1, IsWinning = true },
                new Ticket { Id = 4, Number = "9L7Y69G", LotteryId = 2, IsWinning = false },
                new Ticket { Id = 5, Number = "AY7739U", LotteryId = 2, IsWinning = true },
                new Ticket { Id = 6, Number = "A8MN390", LotteryId = 2, IsWinning = false },
                new Ticket { Id = 7, Number = "Z888399", LotteryId = 3, IsWinning = true },
                new Ticket { Id = 8, Number = "Z677392", LotteryId = 3, IsWinning = false },
                new Ticket { Id = 9, Number = "3607391", LotteryId = 3, IsWinning = false },
                new Ticket { Id = 10, Number = "08J8K19", LotteryId = 3, IsWinning = false });
        }

        public DbSet<Lottery> Lotteries { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
