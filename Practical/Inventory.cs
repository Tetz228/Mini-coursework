//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        public int id_inventory { get; set; }
        public int fk_inv_prod { get; set; }
        public int fk_user { get; set; }
        public int fk_shop { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual Inventory_products Inventory_products { get; set; }
        public virtual Shops Shops { get; set; }
        public virtual Users Users { get; set; }
    }
}
