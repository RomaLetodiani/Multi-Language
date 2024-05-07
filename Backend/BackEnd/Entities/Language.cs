namespace BackEnd.Entities
{
    public class Language
    {
        public int Id {  get; set; }

        public required string Title { get; set; }

        public required string ShortName { get; set; }
    }
}
