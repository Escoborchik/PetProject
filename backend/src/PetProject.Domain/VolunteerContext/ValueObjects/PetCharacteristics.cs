namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record PetCharacteristics
    {
        public PetCharacteristics(PetColor color, Weight weight, Height height)
        {
            Color = color;
            Weight = weight;
            Height = height;
        }

        public PetColor Color { get; }

        public Weight Weight { get; }

        public Height Height { get; }
    }
}
