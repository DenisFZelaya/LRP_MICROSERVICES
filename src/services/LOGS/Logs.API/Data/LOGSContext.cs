﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Logs.API.Models;

namespace Logs.API.Data
{
    public partial class LOGSContext : DbContext
    {
        public LOGSContext()
        {
        }

        public LOGSContext(DbContextOptions<LOGSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogsAcceso> LogsAcceso { get; set; }
        public virtual DbSet<LogsAplicacion> LogsAplicacion { get; set; }
        public virtual DbSet<LogsSeguridad> LogsSeguridad { get; set; }
        public virtual DbSet<LogsSistema> LogsSistema { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=desktop-csf7eun\\sqlexpress;Initial Catalog=LRP_LOGS_MS_DEV;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}