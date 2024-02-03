using AspNetCoreHero.Abstractions.Domain;
using System.Collections.Generic;

namespace ProductManagement.Domain.Entities.Catalog
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public virtual ICollection<ProductCategory> Categories { get; set; }

    }
}