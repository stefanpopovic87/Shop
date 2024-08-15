﻿using Shop.Domain.Entities.Base;
using Shop.Domain.Entities.Products;

namespace Shop.Domain.Entities
{
    public class Subcategory : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<Product> Products { get; private set; } = [];

        public Subcategory(string name, int categoryId)
        {
            Create();
            Name = name;
            CategoryId = categoryId;
        }

        public void Update(string name, int categoryId)
        {
            Update();
            Name = name;
            CategoryId = categoryId;
        }
    }
}
