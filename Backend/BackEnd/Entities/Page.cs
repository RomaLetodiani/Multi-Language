namespace BackEnd.Entities
{
    public class Page
    {
        public int Id {  get; set; }

        public required string Name { get; set; } // Name of the page

        public required string Pathname { get; set; } // Pathname of the page
    }
}
