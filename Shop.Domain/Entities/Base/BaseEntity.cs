namespace Shop.Domain.Entities.Base
{
    public class BaseEntity
    {
        public bool Inactive { get; private set; }
        public DateTimeOffset DateCreated { get; private set; } = DateTimeOffset.Now;
        public DateTimeOffset? DateModified { get; private set; }
        public DateTimeOffset? DateDeleted { get; private set; }
        public int CreatedBy { get; private set; }
        public int? ModifiedBy { get; private set; }
        public int? DeletedBy { get; private set; }

        public void Delete()
        {
            Inactive = true;
            DateDeleted = DateTimeOffset.Now;
            DeletedBy = 1;
        }
    }
}
