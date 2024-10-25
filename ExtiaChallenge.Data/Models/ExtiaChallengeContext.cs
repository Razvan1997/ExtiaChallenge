﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ExtiaChallenge.Data.Models;

public partial class ExtiaChallengeContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ExtiaChallengeContext(DbContextOptions<ExtiaChallengeContext> options)
        : base(options)
    {
    }

    public virtual Microsoft.EntityFrameworkCore.DbSet<TSoldier> TSoldiers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TSoldier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tSoldier__3213E83FCBC1EE9C");

            entity.ToTable("tSoldier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SoldierName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}