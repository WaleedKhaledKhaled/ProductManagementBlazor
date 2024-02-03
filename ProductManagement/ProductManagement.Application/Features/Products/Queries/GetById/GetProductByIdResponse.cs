using ProductManagement.Application.DTOs;
using System.Collections.Generic;

namespace ProductManagement.Application.Features.Products.Queries.GetById
{
    public class GetProductByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}