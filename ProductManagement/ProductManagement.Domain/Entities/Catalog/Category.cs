using AspNetCoreHero.Abstractions.Domain;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductManagement.Domain.Entities.Catalog
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductCategory> Products{ get; set; }
    }

    public class ProductCategory : IBaseEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }


}