using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities;

public class Address : BaseEntity
{
    public int Id { get; private set; }
    public string Street { get; private set; } = string.Empty;
    public string BuildingNumber { get; private set; } = string.Empty;
    public string? UnitNumber { get; private set; }
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;
    public string Zip { get; private set; } = string.Empty;

}
