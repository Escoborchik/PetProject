namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class VolunteerId : IComparable<VolunteerId>
    {
        private VolunteerId(Guid value)
        {
            Value = value;
        }
        public Guid Value { get; }

        public static VolunteerId NewPetId() => new(Guid.NewGuid());

        public static VolunteerId Empty() => new(Guid.Empty);

        public static VolunteerId Create(Guid id) => new(id);

        public int CompareTo(VolunteerId? other)
        {
            if (other == null)
                return 1;

            return Value.CompareTo(other.Value);
        }
    }
}