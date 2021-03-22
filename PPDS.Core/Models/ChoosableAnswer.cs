namespace PPDS.Core.Models
{
    public class ChoosableAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsRight { get; set; }


        public int QuestionId { get; set; }


    }
}
