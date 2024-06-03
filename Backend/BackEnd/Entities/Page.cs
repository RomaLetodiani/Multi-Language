namespace BackEnd.Entities
{
    public class Page
    {
        public Page()
        {
            PageTextResource = new HashSet<PageTextResource>();
        }
        public int Id {  get; set; }

        public required string Name { get; set; } // Name of the page

        public required string Pathname { get; set; } // Pathname of the page

        public ICollection<PageTextResource> PageTextResource { get; set; } // Text resources of the page
    }
}
