using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Howest.MagicCards.DAL.Models
{
    public partial class MyCardsContext : DbContext
    {
        public MyCardsContext()
        {
        }

        public MyCardsContext(DbContextOptions<MyCardsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardColor> CardColors { get; set; }
        public virtual DbSet<CardType> CardTypes { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Rarity> Rarity { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__artists__3213E83FC867953C");

                entity.ToTable("artists");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("full_name");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__types__3213E83F62126D10");

                entity.ToTable("types");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__sets__3213E83F0F72A017");

                entity.ToTable("sets");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("code");
            });

            modelBuilder.Entity<Rarity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__rarities__3213E83F710C9509");

                entity.ToTable("rarities");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("code");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__colors__3213E83F2D3B99AB");

                entity.ToTable("colors");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("code");
            });



            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__cards__3213E83F03749037");

                entity.ToTable("cards");

                entity.Navigation(x => x.Artist)
                      .AutoInclude();

                entity.Navigation(x => x.Rarity)
                     .AutoInclude();

                entity.Navigation(x => x.Set)
                     .AutoInclude();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ManaCost)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("mana_cost");

                entity.Property(e => e.ConvertedManaCost)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("converted_mana_cost");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.RarityCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rarity_code");

                entity.Property(e => e.SetCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("set_code");

                entity.Property(e => e.Text)
                    .HasMaxLength(int.MaxValue)
                    .IsUnicode(false)
                    .HasColumnName("text");

                entity.Property(e => e.Flavor)
                    .HasMaxLength(int.MaxValue)
                    .IsUnicode(false)
                    .HasColumnName("flavor");

                entity.Property(e => e.ArtistId)
                    .HasColumnName("artist_id");

                entity.Property(e => e.Number)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("number");

                entity.Property(e => e.Number)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("number");

                entity.Property(e => e.Power)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("power");

                entity.Property(e => e.Toughness)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("toughness");

                entity.Property(e => e.Layout)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("layout");

                entity.Property(e => e.MutiverseId)
                    .HasColumnName("multiverse_id");

                entity.Property(e => e.OriginalImageUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("original_image_url");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.OriginalText)
                    .HasMaxLength(int.MaxValue)
                    .IsUnicode(false)
                    .HasColumnName("original_text");

                entity.Property(e => e.OriginalType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("original_type");

                entity.Property(e => e.MtgId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("mtg_id");

                entity.Property(e => e.Variations)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("variations");

                entity.HasOne(c => c.Artist)
                    .WithMany(a => a.Cards)
                    .HasForeignKey(c => c.ArtistId)
                    .HasConstraintName("FK_cards_artists");

                entity.HasOne(c => c.Rarity)
                    .WithMany(a => a.Cards)
                    .HasPrincipalKey(r => r.Code)
                    .HasForeignKey(c => c.RarityCode)
                    .HasConstraintName("FK_cards_rarities");

                entity.HasOne(c => c.Set)
                    .WithMany(a => a.Cards)
                    .HasPrincipalKey(s => s.Code)
                    .HasForeignKey(c => c.SetCode)
                    .HasConstraintName("FK_cards_sets");
            });

            modelBuilder.Entity<CardColor>(entity =>
            {
                entity.HasKey(e => new { e.CardId, e.ColorId })
                    .HasName("card_colors_card_id_color_id_primary");

                entity.ToTable("card_colors");

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.HasOne(cc => cc.Color)
                    .WithMany(c => c.CardColors)
                    .HasForeignKey(cc => cc.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_card_colors_colors");

                entity.HasOne(cc => cc.Card)
                   .WithMany(c => c.CardColors)
                   .HasForeignKey(cc => cc.CardId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_card_colors_cards");
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.HasKey(e => new { e.CardId, e.TypeId })
                    .HasName("card_types_card_id_type_id_primary");

                entity.ToTable("card_types");

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(ct => ct.Type)
                    .WithMany(t => t.CardTypes)
                    .HasForeignKey(ct => ct.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_card_types_types");

                entity.HasOne(ct => ct.Card)
                   .WithMany(c => c.CardTypes)
                   .HasForeignKey(ct => ct.CardId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_card_types_cards");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
