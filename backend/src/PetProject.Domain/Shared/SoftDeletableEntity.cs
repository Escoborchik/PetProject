using CSharpFunctionalExtensions;

namespace PetProject.Domain.Shared
{
    public abstract class SoftDeletableEntity<TId> : Entity<TId> where TId : IComparable<TId>
    {
        protected bool IsDeleted { get; private set; }
        protected DateTime? DeletionDate { get; private set; }

        protected SoftDeletableEntity(TId id) : base(id) { }

        public virtual void Delete()
        {
            if (IsDeleted) return;

            IsDeleted = true;
            DeletionDate = DateTime.UtcNow;
        }

        public virtual void Restore()
        {
            if (!IsDeleted) return;

            IsDeleted = false;
            DeletionDate = null;
        }
    }
}
