﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UNBK_Client
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class unbk_clientEntities : DbContext
    {
        public unbk_clientEntities()
            : base("name=unbk_clientEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<group> groups { get; set; }
        public virtual DbSet<jadwal> jadwals { get; set; }
        public virtual DbSet<jawaban> jawabans { get; set; }
        public virtual DbSet<kota> kotas { get; set; }
        public virtual DbSet<mata_pelajaran> mata_pelajaran { get; set; }
        public virtual DbSet<page> pages { get; set; }
        public virtual DbSet<paket> pakets { get; set; }
        public virtual DbSet<paket_soal> paket_soal { get; set; }
        public virtual DbSet<privilege> privileges { get; set; }
        public virtual DbSet<provinsi> provinsis { get; set; }
        public virtual DbSet<reg_info> reg_info { get; set; }
        public virtual DbSet<sekolah> sekolahs { get; set; }
        public virtual DbSet<soal> soals { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<user_group> user_group { get; set; }
        public virtual DbSet<siswa> siswas { get; set; }
    }
}