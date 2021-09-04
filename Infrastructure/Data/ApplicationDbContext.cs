using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWMountAndPetCreator.Infrastructure.Entities;

namespace WoWMountAndPetCreator.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Creature> Creatures { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<SpellIcon> SpellIcons { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemIcon> ItemIcons { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Creature>()
                .ToTable("creature_template")
                .HasKey(q => q.Entry);

            builder.Entity<Spell>()
                .ToTable("db_spell_12340")
                .HasKey(q => q.ID);

            builder.Entity<SpellIcon>()
                .ToTable("db_spellicon_12340")
                .HasKey(q => q.ID);

            builder.Entity<Item>()
                .ToTable("item_template")
                .HasKey(q => q.Entry);

            builder.Entity<ItemIcon>()
                .ToTable("db_itemdisplayinfo_12340")
                .HasKey(q => q.ID);
        }
    }
}
