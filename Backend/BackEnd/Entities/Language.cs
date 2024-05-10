namespace BackEnd.Entities
{
    public class Language
    {
        public int Id {  get; set; }

        public required string Name { get; set; } // Language Name, e.g., "English", "Georgian", etc.

        public required string Code { get; set; } // language Code, e.g., "EN", "GE", etc.
    }
}
