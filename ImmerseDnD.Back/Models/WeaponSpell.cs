using ImmerseDnD.Back.Interfaces;

namespace ImmerseDnD.Back.Models
{
    public class WeaponSpell : IInventoryItem
    {
        Guid IInventoryItem.Id { get; set; }
        string IInventoryItem.Name { get; set; }
        string IInventoryItem.Type { get; set; } //weapon or spell
        string IInventoryItem.Description { get; set; }

        string? AttackBonus { get; set; }
        short Damage { get; set; }
    }
}
