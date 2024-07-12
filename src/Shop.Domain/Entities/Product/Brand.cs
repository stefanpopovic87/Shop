﻿using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product
{
    public class Brand : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public ICollection<Product> Products { get; private set; } = new List<Product>();

        public Brand(string name)
        {
            base.Create();
            Name = name;
        }

        public void Update(string name) 
        {
            base.Update();
            Name = name; 
        }

    }
}
