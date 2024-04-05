using ImmerseDnD.Back.Interfaces;

namespace ImmerseDnD.Back.Models
{
    public class CharacterInit
    {
        //general
        public string? Name { get; set; }
        public string? Race { get; set; }
        public string? Class { get; set; }
        public byte Level { get; set; }

        //abilities

        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }

        //Others
        public byte ProficiencyBonus { get; set; }
        public byte Speed { get; set; }
        public bool Inspiration { get; set; }
        public byte ArmorClass { get; set; }

        //health
        public ushort CurrentHP { get; set; }
        public ushort MaxHP { get; set; }
        public ushort TempHP { get; set; }

        //death saves
        public byte Successes { get; set; }
        public byte Failures { get; set; }

        //Proficiencies
        public bool StrengthProf { get; set; }
        public bool DexterityProf { get; set; }
        public bool ConstitutionProf { get; set; }
        public bool IntelligenceProf { get; set; }
        public bool WisdomProf { get; set; }
        public bool CharismaProf { get; set; }


        //money
        public int Copper { get; set; }
        public int Silver { get; set; }
        public int Gold { get; set; }
        public int Platinum { get; set; }
        //public byte Electrum { get; set; }



        //inventory
        public LinkedList<IInventoryItem>? Inventory { get; set; }
    }

    public enum Bonus {
        None,
        Half,
        Full
    }
}
