﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EnglishMasterWebAssembly.Server.Models
{
    public partial class DB : DbContext
    {
        public DB()
        {
        }

        public DB(DbContextOptions<DB> options)
            : base(options)
        {
        }

        public virtual DbSet<ExamResult> ExamResults { get; set; } = null!;
        public virtual DbSet<ExamResultIncorrect> ExamResultIncorrects { get; set; } = null!;
        public virtual DbSet<Level> Levels { get; set; } = null!;
        public virtual DbSet<PartOfSpeech> PartOfSpeeches { get; set; } = null!;
        public virtual DbSet<PracticeResult> PracticeResults { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vocabulary> Vocabularies { get; set; } = null!;
        public virtual DbSet<Word> Words { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamResults)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamResults_Users");
            });

            modelBuilder.Entity<ExamResultIncorrect>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExamResultId).HasColumnName("ExamResultID");

                entity.Property(e => e.VocabularyId).HasColumnName("VocabularyID");

                entity.HasOne(d => d.ExamResult)
                    .WithMany(p => p.ExamResultIncorrects)
                    .HasForeignKey(d => d.ExamResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamResultIncorrects_ExamResults");

                entity.HasOne(d => d.Vocabulary)
                    .WithMany(p => p.ExamResultIncorrects)
                    .HasForeignKey(d => d.VocabularyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamResultIncorrects_Vocabularies");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PartOfSpeech>(entity =>
            {
                entity.ToTable("PartOfSpeech");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InJapanese).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PracticeResult>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VocabularyId).HasColumnName("VocabularyID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PracticeResults)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PracticeResults_Users");

                entity.HasOne(d => d.Vocabulary)
                    .WithMany(p => p.PracticeResults)
                    .HasForeignKey(d => d.VocabularyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PracticeResults_Vocabularies");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ_Users_Email")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vocabulary>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Vocabularies");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.Meaning).HasMaxLength(100);

                entity.Property(e => e.PartOfSpeechId).HasColumnName("PartOfSpeechID");

                entity.Property(e => e.WordId).HasColumnName("WordID");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Vocabularies)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vocabularies_Levels");

                entity.HasOne(d => d.PartOfSpeech)
                    .WithMany(p => p.Vocabularies)
                    .HasForeignKey(d => d.PartOfSpeechId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vocabularies_PartOfSpeech");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.Vocabularies)
                    .HasForeignKey(d => d.WordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vocabularies_Words");
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Word1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Word");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
