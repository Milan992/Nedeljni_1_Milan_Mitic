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
    
    public partial class tblAdministrator
    {
        public int AdministratorID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<System.DateTime> DateOfExpiry { get; set; }
        public Nullable<int> AdministratorTypeID { get; set; }
    
        public virtual tblAccount tblAccount { get; set; }
        public virtual tblAdministratorType tblAdministratorType { get; set; }
    }
}