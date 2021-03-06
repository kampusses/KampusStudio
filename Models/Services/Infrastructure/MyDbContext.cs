﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using kampus.Models.Entities;

#nullable disable

namespace kampus.Models.Services.Infrastructure
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comune> Comuni { get; set; }
        public virtual DbSet<Provincia> Province { get; set; }
        public virtual DbSet<Regione> Regioni { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=kampus;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.FromString("5.7.17-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comune>(entity =>
            {
                entity.HasKey(e => e.CodiceCatastale)
                    .HasName("PRIMARY");

                entity.ToTable("comuni");

                entity.HasComment("Elenco dei comuni italiani");

                entity.Property(e => e.CodiceCatastale)
                    .HasColumnType("varchar(4)")
                    .HasColumnName("codiceCatastale")
                    .HasComment("Codice catastale")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Abitanti)
                    .HasColumnType("int(11)")
                    .HasColumnName("abitanti")
                    .HasComment("Numero abitanti");

                entity.Property(e => e.Cap)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasColumnName("cap")
                    .HasComment("CAP")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CodiceIstat)
                    .IsRequired()
                    .HasColumnType("varchar(6)")
                    .HasColumnName("codiceIstat")
                    .HasComment("Codice Istat")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FlagProvincia)
                    .HasColumnType("int(11)")
                    .HasColumnName("flagProvincia")
                    .HasComment("Flag provincia");

                entity.Property(e => e.FlagRegione)
                    .HasColumnType("int(1)")
                    .HasColumnName("flagRegione");

                entity.Property(e => e.NomeComune)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("nomeComune")
                    .HasComment("Nome comune")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Prefisso)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasColumnName("prefisso")
                    .HasComment("Prefisso telefonico")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CodiceProvincia)
                    .HasColumnType("int(11)")
                    .HasColumnName("provincia")
                    .HasComment("Provincia");

                entity.Property(e => e.CodiceRegione)
                    .HasColumnType("int(11)")
                    .HasColumnName("regione")
                    .HasComment("Regione");

                entity.HasOne(comune => comune.Provincia)
                      .WithMany(provincia => provincia.Comuni)
                      .HasForeignKey(provincia => provincia.CodiceProvincia);

                entity.HasOne(comune => comune.Regione)
                      .WithMany(regione => regione.Comuni)
                      .HasForeignKey(regione => regione.CodiceRegione);

            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.CodiceProvincia)
                    .HasName("PRIMARY");

                entity.ToTable("province");

                entity.Property(e => e.CodiceProvincia)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("codiceProvincia");

                entity.Property(e => e.CodiceRegione)
                    .HasColumnType("int(11)")
                    .HasColumnName("codiceRegione");

                entity.Property(e => e.NomeProvincia)
                    .IsRequired()
                    .HasColumnType("varchar(28)")
                    .HasColumnName("nomeProvincia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SiglaProvincia)
                    .IsRequired()
                    .HasColumnType("varchar(2)")
                    .HasColumnName("siglaProvincia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasMany(provincia => provincia.Comuni)
                      .WithOne(comune => comune.Provincia)
                      .HasForeignKey(comune => comune.CodiceProvincia);

                entity.HasOne(provincia => provincia.Regione)
                      .WithMany(regione => regione.Province); 
            });

            modelBuilder.Entity<Regione>(entity =>
            {
                entity.HasKey(e => e.CodiceRegione)
                    .HasName("PRIMARY");

                entity.ToTable("regioni");

                entity.HasComment("Elenco delle regioni italiane");

                entity.Property(e => e.CodiceRegione)
                    .HasColumnType("int(11)")
                    .HasColumnName("codiceRegione")
                    .HasComment("Codice Regione");

                entity.Property(e => e.CodiceCapoluogo)
                    .IsRequired()
                    .HasColumnType("varchar(4)")
                    .HasColumnName("codiceCapoluogo")
                    .HasComment("Codice capoluogo di regione")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NomeRegione)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("nomeRegione")
                    .HasComment("Nome Regione")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.RipartizioneGeografica)
                    .HasColumnType("int(11)")
                    .HasColumnName("ripartizioneGeografica")
                    .HasComment("Ripartizione geografica");

                entity.HasMany(regione => regione.Comuni)
                      .WithOne(comune => comune.Regione)
                      .HasForeignKey(comune => comune.CodiceRegione);
                    
                entity.HasMany(regione => regione.Province)
                      .WithOne(provincia => provincia.Regione)
                      .HasForeignKey(provincia => provincia.CodiceRegione);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
