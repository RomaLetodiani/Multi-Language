using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public class TextResource
    {
        public int Id { get; set; }
        public required string Key { get; set; }
        public required string Text { get; set; }
        public required string PageUrl { get; set; } // e.g., "/", "/about", etc.
        public required string LanguageCode { get; set; } // e.g., "EN", "GE", etc.
    }
}