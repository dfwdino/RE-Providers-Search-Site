//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RE
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListOfInsuranceCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListOfInsuranceCompany()
        {
            this.Insurances = new HashSet<Insurance>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Hide { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Insurance> Insurances { get; set; }
    }
}
