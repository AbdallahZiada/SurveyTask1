using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
