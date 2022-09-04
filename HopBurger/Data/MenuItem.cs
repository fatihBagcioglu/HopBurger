namespace HopBurger.Data
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string MenuId { get; set; }
        public string ItemId { get; set; }
        public Menu Menu { get; set; }
        public Item Item { get; set; }
    }
}
