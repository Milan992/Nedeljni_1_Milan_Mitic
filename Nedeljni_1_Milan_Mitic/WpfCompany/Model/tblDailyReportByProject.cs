//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tblDailyReportByProject
    {
        public int DailyReportID { get; set; }
        public int ProjectID { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public string ReportDescription { get; set; }
        public Nullable<int> HoursWorking { get; set; }
    
        public virtual tblDailyReport tblDailyReport { get; set; }
        public virtual tblProject tblProject { get; set; }
    }
}
