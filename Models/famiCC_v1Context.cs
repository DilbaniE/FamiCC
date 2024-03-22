using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace famiCCV1.Server.Models
{
    public partial class famiCC_v1Context : DbContext
    {
        public famiCC_v1Context()
        {
        }

        public famiCC_v1Context(DbContextOptions<famiCC_v1Context> options)
            : base(options)
        {
            this.Database.EnsureCreated();

        }

        public virtual DbSet<AdjuntDocument> AdjuntDocuments { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<Proponent> Proponents { get; set; } = null!;
        public virtual DbSet<ProponentDocument> ProponentDocuments { get; set; } = null!;
        public virtual DbSet<ProponentType> ProponentTypes { get; set; } = null!;
        public virtual DbSet<Proposed> Proposeds { get; set; } = null!;
        public virtual DbSet<ProposedValue> ProposedValues { get; set; } = null!;
        public virtual DbSet<Representative> Representatives { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdjuntDocument>(entity =>
            {
                entity.ToTable("AdjuntDocument");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameDocument)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name_document");

                entity.Property(e => e.Urls)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("urls");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocumentType1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("document_type");
            });

            modelBuilder.Entity<Proponent>(entity =>
            {
                entity.ToTable("Proponent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkRepresentativeId).HasColumnName("fk_representative_id");

                entity.Property(e => e.FkTproponentId).HasColumnName("fk_tproponent_id");

                entity.Property(e => e.NProponent)
                    .HasMaxLength(130)
                    .IsUnicode(false)
                    .HasColumnName("n_proponent");

                entity.Property(e => e.Trajectory)
                    .HasMaxLength(230)
                    .IsUnicode(false)
                    .HasColumnName("trajectory");

                entity.HasOne(d => d.FkRepresentative)
                    .WithMany(p => p.Proponents)
                    .HasForeignKey(d => d.FkRepresentativeId)
                    .HasConstraintName("FK__Proponent__fk_re__2B3F6F97");

                entity.HasOne(d => d.FkTproponent)
                    .WithMany(p => p.Proponents)
                    .HasForeignKey(d => d.FkTproponentId)
                    .HasConstraintName("FK__Proponent__fk_tp__2C3393D0");
            });

            modelBuilder.Entity<ProponentDocument>(entity =>
            {
                entity.ToTable("ProponentDocument");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkAdjuntdocumentId).HasColumnName("fk_adjuntdocument_id");

                entity.Property(e => e.FkProposedId).HasColumnName("fk_proposed_id");

                entity.HasOne(d => d.FkAdjuntdocument)
                    .WithMany(p => p.ProponentDocuments)
                    .HasForeignKey(d => d.FkAdjuntdocumentId)
                    .HasConstraintName("FK__Proponent__fk_ad__398D8EEE");

                entity.HasOne(d => d.FkProposed)
                    .WithMany(p => p.ProponentDocuments)
                    .HasForeignKey(d => d.FkProposedId)
                    .HasConstraintName("FK__Proponent__fk_pr__3A81B327");
            });

            modelBuilder.Entity<ProponentType>(entity =>
            {
                entity.ToTable("ProponentType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProponentType1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("proponent_type");
            });

            modelBuilder.Entity<Proposed>(entity =>
            {
                entity.ToTable("Proposed");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlliedCompany)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("allied_company");

                entity.Property(e => e.BenefitedPublic)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("benefited_public");

                entity.Property(e => e.DateStart)
                    .HasColumnType("date")
                    .HasColumnName("date_start");

                entity.Property(e => e.DescripcionProposed)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_proposed");

                entity.Property(e => e.DescriptionActivities)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description_activities");

                entity.Property(e => e.FkProponentId).HasColumnName("fk_proponent_id");

                entity.Property(e => e.FkProposedvalueId).HasColumnName("fk_proposedvalue_id");

                entity.Property(e => e.NameProponen)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name_proponen");

                entity.Property(e => e.PresentationDate)
                    .HasColumnType("date")
                    .HasColumnName("presentation_date");

                entity.Property(e => e.ProposedState)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("proposed_state");

                entity.HasOne(d => d.FkProponent)
                    .WithMany(p => p.Proposeds)
                    .HasForeignKey(d => d.FkProponentId)
                    .HasConstraintName("FK__Proposed__fk_pro__30F848ED");

                entity.HasOne(d => d.FkProposedvalue)
                    .WithMany(p => p.Proposeds)
                    .HasForeignKey(d => d.FkProposedvalueId)
                    .HasConstraintName("FK__Proposed__fk_pro__31EC6D26");
            });

            modelBuilder.Entity<ProposedValue>(entity =>
            {
                entity.ToTable("ProposedValue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContributionConfama)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("contribution_confama");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total_amount");
            });

            modelBuilder.Entity<Representative>(entity =>
            {
                entity.ToTable("representative");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.FkTdocumentId).HasColumnName("fk_tdocument_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.NumDocument)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("num_document");

                entity.Property(e => e.Phone)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.FkTdocument)
                    .WithMany(p => p.Representatives)
                    .HasForeignKey(d => d.FkTdocumentId)
                    .HasConstraintName("FK__represent__fk_td__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
