﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfCompany.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CompanyEntities : DbContext
    {
        public CompanyEntities()
            : base("name=CompanyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAccount> tblAccounts { get; set; }
        public virtual DbSet<tblAdministrator> tblAdministrators { get; set; }
        public virtual DbSet<tblAdministratorType> tblAdministratorTypes { get; set; }
        public virtual DbSet<tblClient> tblClients { get; set; }
        public virtual DbSet<tblDailyReport> tblDailyReports { get; set; }
        public virtual DbSet<tblEmployee> tblEmployees { get; set; }
        public virtual DbSet<tblEmployeeEdit> tblEmployeeEdits { get; set; }
        public virtual DbSet<tblManager> tblManagers { get; set; }
        public virtual DbSet<tblMarrigeStatu> tblMarrigeStatus { get; set; }
        public virtual DbSet<tblPosition> tblPositions { get; set; }
        public virtual DbSet<tblProject> tblProjects { get; set; }
        public virtual DbSet<tblRequest> tblRequests { get; set; }
        public virtual DbSet<tblSector> tblSectors { get; set; }
        public virtual DbSet<tblDailyReportByProject> tblDailyReportByProjects { get; set; }
        public virtual DbSet<vwManager> vwManagers { get; set; }
    }
}
