namespace PPDS.Core.Models
{
    public class QuestionType
    {
        public static QuestionType Choosable = new QuestionType() { Id = 1, Description = nameof(Choosable) };
        public static QuestionType RightOrder = new QuestionType() { Id = 2, Description = nameof(RightOrder) };
        public static QuestionType Matching = new QuestionType() { Id = 3, Description = nameof(Matching) };

        public int Id { get; set; }
        public string Description { get; set; }

    }
}
