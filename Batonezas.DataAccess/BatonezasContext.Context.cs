﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNet.Identity.EntityFramework;

namespace Batonezas.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BatonezasContext : IdentityDbContext<User>
    {
        public BatonezasContext()
            : base("name=BatonezasContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<DishType> DishType { get; set; }
        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<DishReview> DishReview { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<PlaceReview> PlaceReview { get; set; }
        public virtual DbSet<Review> Review { get; set; }
    }
}
