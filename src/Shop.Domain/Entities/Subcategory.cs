﻿using Shop.Domain.Entities.Products;

namespace Shop.Domain.Entities
{
    public class Subcategory
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<Product> Products { get; private set; } = [];

        public static Subcategory Create(string name, int categoryId)
        {
            return new Subcategory(name, categoryId);
        }

        public void Update(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        private Subcategory(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
