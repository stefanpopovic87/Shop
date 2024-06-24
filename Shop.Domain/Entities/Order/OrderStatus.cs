﻿namespace Shop.Domain.Entities.Order
{
    public class OrderStatus
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public OrderStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
