using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class shopMVCContext : DbContext
    {
        public shopMVCContext()
        {
        }

        public shopMVCContext(DbContextOptions<shopMVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adre> Adres { get; set; }
        public virtual DbSet<Klient> Klients { get; set; }
        public virtual DbSet<Koszyk> Koszyks { get; set; }
        public virtual DbSet<Opinium> Opinia { get; set; }
        public virtual DbSet<Plytum> Plyta { get; set; }
        public virtual DbSet<PozycjaKoszyka> PozycjaKoszykas { get; set; }
        public virtual DbSet<PozycjaZamowienium> PozycjaZamowienia { get; set; }
        public virtual DbSet<Pracownik> Pracowniks { get; set; }
        public virtual DbSet<SiteUser> SiteUsers { get; set; }
        public virtual DbSet<Zamowienie> Zamowienies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=PIOTR-PC\\BRACSQL;Database=shopMVC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Adre>(entity =>
            {
                entity.HasKey(e => e.IdAdres)
                    .HasName("PK__adres__8A89DA2B26E5BC2A");

                entity.ToTable("adres");

                entity.Property(e => e.IdAdres).HasColumnName("id_adres");

                entity.Property(e => e.KodPocztowy)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("kod_pocztowy")
                    .IsFixedLength(true);

                entity.Property(e => e.Lokal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lokal");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("miasto");

                entity.Property(e => e.NumerLokal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numer_lokal");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ulica");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("PK__klient__C6465E77641AC61A");

                entity.ToTable("klient");

                entity.HasIndex(e => e.IdSiteUser, "UQ__klient__535B38B5AABA6D93")
                    .IsUnique();

                entity.HasIndex(e => e.IdAdres, "UQ__klient__8A89DA2A05784DFB")
                    .IsUnique();

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.Property(e => e.DataZostaniaKlientem)
                    .HasColumnType("datetime")
                    .HasColumnName("data_zostania_klientem");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdAdres).HasColumnName("id_adres");

                entity.Property(e => e.IdSiteUser).HasColumnName("id_siteUser");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("imie");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefon");

                entity.HasOne(d => d.IdAdresNavigation)
                    .WithOne(p => p.Klient)
                    .HasForeignKey<Klient>(d => d.IdAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__klient__id_adres__1BFD2C07");

                entity.HasOne(d => d.IdSiteUserNavigation)
                    .WithOne(p => p.Klient)
                    .HasForeignKey<Klient>(d => d.IdSiteUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__klient__id_siteU__1CF15040");
            });

            modelBuilder.Entity<Koszyk>(entity =>
            {
                entity.HasKey(e => e.IdKoszyk)
                    .HasName("PK__koszyk__2685876CD32290BE");

                entity.ToTable("koszyk");

                entity.Property(e => e.IdKoszyk).HasColumnName("id_koszyk");

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Koszyks)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__koszyk__id_klien__2C3393D0");
            });

            modelBuilder.Entity<Opinium>(entity =>
            {
                entity.HasKey(e => e.IdOpinia)
                    .HasName("PK__opinia__0B34D055A8152BB8");

                entity.ToTable("opinia");

                entity.Property(e => e.IdOpinia).HasColumnName("id_opinia");

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.Property(e => e.IdPlyta).HasColumnName("id_plyta");

                entity.Property(e => e.Tresc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("tresc");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Opinia)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__opinia__id_klien__21B6055D");

                entity.HasOne(d => d.IdPlytaNavigation)
                    .WithMany(p => p.Opinia)
                    .HasForeignKey(d => d.IdPlyta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__opinia__id_plyta__22AA2996");
            });

            modelBuilder.Entity<Plytum>(entity =>
            {
                entity.HasKey(e => e.IdPlyta)
                    .HasName("PK__plyta__7AE63C4194C7C7BA");

                entity.ToTable("plyta");

                entity.Property(e => e.IdPlyta).HasColumnName("id_plyta");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("autor");

                entity.Property(e => e.Cena)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("cena");

                entity.Property(e => e.DataWydania)
                    .HasColumnType("datetime")
                    .HasColumnName("data_wydania");

                entity.Property(e => e.Gatunek)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("gatunek");

                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("opis");

                entity.Property(e => e.Tytul)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tytul");

                entity.Property(e => e.Zdjecie1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("zdjecie1");

                entity.Property(e => e.Zdjecie2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("zdjecie2");
            });

            modelBuilder.Entity<PozycjaKoszyka>(entity =>
            {
                entity.HasKey(e => e.IdPozycjaKoszyka)
                    .HasName("PK__pozycjaK__25ED81171C54D617");

                entity.ToTable("pozycjaKoszyka");

                entity.Property(e => e.IdPozycjaKoszyka).HasColumnName("id_pozycjaKoszyka");

                entity.Property(e => e.IdKoszyk).HasColumnName("id_koszyk");

                entity.Property(e => e.IdPlyta).HasColumnName("id_plyta");

                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.HasOne(d => d.IdKoszykNavigation)
                    .WithMany(p => p.PozycjaKoszykas)
                    .HasForeignKey(d => d.IdKoszyk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pozycjaKo__id_ko__2F10007B");

                entity.HasOne(d => d.IdPlytaNavigation)
                    .WithMany(p => p.PozycjaKoszykas)
                    .HasForeignKey(d => d.IdPlyta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pozycjaKo__id_pl__300424B4");
            });

            modelBuilder.Entity<PozycjaZamowienium>(entity =>
            {
                entity.HasKey(e => e.IdPozycjaZamowienia)
                    .HasName("PK__pozycjaZ__50C1D43BFCAC6EBF");

                entity.ToTable("pozycjaZamowienia");

                entity.Property(e => e.IdPozycjaZamowienia).HasColumnName("id_pozycjaZamowienia");

                entity.Property(e => e.IdPlyta).HasColumnName("id_plyta");

                entity.Property(e => e.IdZamowienie).HasColumnName("id_zamowienie");

                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.HasOne(d => d.IdPlytaNavigation)
                    .WithMany(p => p.PozycjaZamowienia)
                    .HasForeignKey(d => d.IdPlyta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pozycjaZa__id_pl__286302EC");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.PozycjaZamowienia)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pozycjaZa__id_za__29572725");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("PK__pracowni__417BA443D1D59321");

                entity.ToTable("pracownik");

                entity.HasIndex(e => e.IdSiteUser, "UQ__pracowni__535B38B5E7CCB57A")
                    .IsUnique();

                entity.HasIndex(e => e.IdAdres, "UQ__pracowni__8A89DA2A92BC7CF9")
                    .IsUnique();

                entity.Property(e => e.IdPracownik).HasColumnName("id_pracownik");

                entity.Property(e => e.DataZatrudnienia)
                    .HasColumnType("datetime")
                    .HasColumnName("data_zatrudnienia");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdAdres).HasColumnName("id_adres");

                entity.Property(e => e.IdSiteUser).HasColumnName("id_siteUser");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("imie");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefon");

                entity.HasOne(d => d.IdAdresNavigation)
                    .WithOne(p => p.Pracownik)
                    .HasForeignKey<Pracownik>(d => d.IdAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pracownik__id_ad__164452B1");

                entity.HasOne(d => d.IdSiteUserNavigation)
                    .WithOne(p => p.Pracownik)
                    .HasForeignKey<Pracownik>(d => d.IdSiteUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pracownik__id_si__173876EA");
            });

            modelBuilder.Entity<SiteUser>(entity =>
            {
                entity.HasKey(e => e.IdSiteUser)
                    .HasName("PK__siteUser__535B38B43B469CE3");

                entity.ToTable("siteUser");

                entity.Property(e => e.IdSiteUser).HasColumnName("id_siteUser");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("user_login");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserRole)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("user_role");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("PK__zamowien__D19B897CBD977A99");

                entity.ToTable("zamowienie");

                entity.Property(e => e.IdZamowienie).HasColumnName("id_zamowienie");

                entity.Property(e => e.CenaZamowienia)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("cena_zamowienia");

                entity.Property(e => e.DataZamowienia)
                    .HasColumnType("datetime")
                    .HasColumnName("data_zamowienia");

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.Property(e => e.StanZamowienia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stan_zamowienia");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Zamowienies)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__zamowieni__id_kl__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
