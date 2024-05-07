using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public class TextResource
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]  // Define foreign key relationship
        public Language Language { get; set; }  // Navigation property
    }
}
