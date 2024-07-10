﻿using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product
{
    public class Size : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<ProductQuantity> ProductQuantities { get; private set; } = new List<ProductQuantity>();



        public Size(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
