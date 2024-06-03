namespace BackEnd.Entities
{
    public class TextResource
    {
        public TextResource()
        {
            PageTextResource = new HashSet<PageTextResource>();
        }
        public int Id { get; set; }
        public required string Key { get; set; }
        public required string Text { get; set; }
        public required int LanguageId { get; set; } // Foreign Key to Language

        public ICollection<PageTextResource> PageTextResource { get; set; }

        public Language Language { get; set; } // Navigation property to Language
    }
}