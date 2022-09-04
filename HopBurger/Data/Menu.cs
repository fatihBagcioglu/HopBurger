namespace HopBurger.Data
{
    public class Menu
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descripton { get; set; }
        [ForeignKey("MenuItemId")]
        public List<MenuItem> MenuItem { get; set; }

    }
}
