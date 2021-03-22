namespace PPDS.Core.Models
{
    public class QuestionType
    {
        public static QuestionType Choosable = new QuestionType() { Id = 1, Description = nameof(Choosable) };

        public int Id { get; set; }
        public string Description { get; set; }

    }
}
