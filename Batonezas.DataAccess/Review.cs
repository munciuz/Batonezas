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
    
    public partial class Review
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Review()
        {
            this.DishReview = new HashSet<DishReview>();
            this.PlaceReview = new HashSet<PlaceReview>();
        }
    
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public Nullable<int> ImageId { get; set; }
        public int PlaceId { get; set; }
        public bool IsValid { get; set; }
        public int CreatedByUserId { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DishReview> DishReview { get; set; }
        public virtual Image Image { get; set; }
        public virtual Place Place { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaceReview> PlaceReview { get; set; }
        public virtual User User { get; set; }
    }
}
