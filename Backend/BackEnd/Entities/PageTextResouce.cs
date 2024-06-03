namespace BackEnd.Entities
{
    public class PageTextResource
    {
        public int PageId { get; set; }
        public int TextResourceId { get; set; }

        public Page Page { get; set; }
        public TextResource TextResource { get; set; }
    }
}
