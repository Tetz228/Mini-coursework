﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practical
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbEntities : DbContext
    {
        public dbEntities()
            : base("name=dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Inventory_products> Inventory_products { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Posts_employees> Posts_employees { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Roles_users> Roles_users { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Types_product> Types_product { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
