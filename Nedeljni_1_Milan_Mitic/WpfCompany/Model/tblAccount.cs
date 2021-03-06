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
    
    public partial class tblAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccount()
        {
            this.tblAdministrators = new HashSet<tblAdministrator>();
            this.tblEmployees = new HashSet<tblEmployee>();
            this.tblEmployeeEdits = new HashSet<tblEmployeeEdit>();
            this.tblManagers = new HashSet<tblManager>();
            this.tblRequests = new HashSet<tblRequest>();
            this.tblProjects = new HashSet<tblProject>();
        }
    
        public int AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int MarrigeStatusID { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
    
        public virtual tblMarrigeStatu tblMarrigeStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAdministrator> tblAdministrators { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmployee> tblEmployees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmployeeEdit> tblEmployeeEdits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblManager> tblManagers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRequest> tblRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProject> tblProjects { get; set; }
    }
}
