namespace ImmerseDnD.Back.Interfaces
{
    public interface IInventoryItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type{ get; set; }
        public string Description { get; set; }
    }
}
