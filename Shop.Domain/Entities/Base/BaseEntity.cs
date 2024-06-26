namespace Shop.Domain.Entities.Base
{
    public class BaseEntity
    {
        public bool Deleted { get; private set; }
        public DateTimeOffset DateCreated { get; private set; } = DateTimeOffset.Now;
        public DateTimeOffset? DateModified { get; private set; }
        public DateTimeOffset? DateDeleted { get; private set; }
        public int CreatedBy { get; private set; }
        public int? ModifiedBy { get; private set; }
        public int? DeletedBy { get; private set; }

        public void Delete()
        {
            Deleted = true;
            DateDeleted = DateTimeOffset.Now;
            DeletedBy = 1;
        }

        public void Update() 
        {
            DateModified = DateTimeOffset.Now;
            ModifiedBy = 1;
        }

        public void Create()
        {
            DateCreated = DateTimeOffset.Now;
            CreatedBy = 1;
        }

        public void Activate()
        {
            Deleted = false;
            DateDeleted = null;
            DeletedBy = null;
            DateModified = DateTimeOffset.Now;
            ModifiedBy = 1;
        }

    }
}
