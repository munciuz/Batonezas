//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Batonezas.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            this.DishReview = new HashSet<DishReview>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int DishTypeId { get; set; }
        public bool IsValid { get; set; }
        public bool IsConfirmed { get; set; }
        public int CreatedByUserId { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
    
        public virtual DishType DishType { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DishReview> DishReview { get; set; }
    }
}