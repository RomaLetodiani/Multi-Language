using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public class TextResource
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public required int LanguageId { get; set; } = 1;
        public required string PageName { get; set; }
        public required string Key { get; set;}
    }
}