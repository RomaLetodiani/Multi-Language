namespace BackEnd.Entities
{
    public class Language
    {
        public int Id {  get; set; }

        public required string Title { get; set; } // Language title, e.g., "English", "Georgian", etc.

        public required string Code { get; set; } // language Code, e.g., "EN", "GE", etc.
    }
}
