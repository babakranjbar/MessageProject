using Data.Model.Chat;
using Data.Model.Message;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MesaggeContext : DbContext
    {
        public MesaggeContext(DbContextOptions<MesaggeContext> options) : base(options)
        {

        }

        public DbSet<Message> Message { get; set; }
        public DbSet<Chat> Chat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(config =>
            {
                config.HasKey(m => m.Id);
                config.HasIndex(m => m.Id).IsUnique(true);
                config.Property(m => m.Id).IsRequired();
                config.HasOne(m => m.Chat)
                      .WithMany(m => m.Messages)
                      .HasForeignKey(m => m.ChatId)
                      .OnDelete(DeleteBehavior.Cascade);
                config.HasOne(m => m.message)
                      .WithOne()
                      .HasForeignKey<Message>(m => m.ParentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Chat>(config =>
            {
                config.HasKey(m => m.Id);
                config.HasIndex(m => m.Id).IsUnique(true);
                config.Property(m => m.Id).IsRequired();
                config.HasMany(m => m.Messages)
                       .WithOne(m => m.Chat)
                       .HasForeignKey(m => m.ChatId)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
