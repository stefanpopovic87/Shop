namespace Shop.Domain.Entities.Base
{
    public class BaseEntity
    {
        public bool Deleted { get; private set; } = false;
        public DateTime DateCreated { get; private set; } = DateTime.UtcNow;
        public DateTime? DateModified { get; private set; }
        public DateTime? DateDeleted { get; private set; }
        public int CreatedBy { get; private set; }
        public int? ModifiedBy { get; private set; }
        public int? DeletedBy { get; private set; }

        public void Delete()
        {
            Deleted = true;
            DateDeleted = DateTime.UtcNow;
            DeletedBy = 1; // TODO - change to current user ID
        }

        public void Update() 
        {
            DateModified = DateTime.UtcNow;
            ModifiedBy = 1; // TODO - change to current user ID
        }

        public void Create()
        {
            DateCreated = DateTime.UtcNow;
            CreatedBy = 1; // TODO - change to current user ID
        }

        public void Activate()
        {
            Deleted = false;
            DateDeleted = null;
            DeletedBy = null;
            DateModified = DateTime.UtcNow;
            ModifiedBy = 1; // TODO - change to current user ID
        }

    }
}
