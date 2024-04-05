namespace ImmerseDnD.Back.Models
{
    public class CharacterPreview
    {
        public Guid CharacterID { get; }
        //general
        public string? Name { get; }
        public string? Race { get; }
        public string? Class { get; }
        public byte Level { get; }

        //abilities

        public byte Strength { get; }
        public byte Dexterity { get; }
        public byte Constitution { get; }
        public byte Intelligence { get; }
        public byte Wisdom { get; }
        public byte Charisma { get; }
    }
}
