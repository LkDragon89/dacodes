namespace dacodes.Query
{
    public class AnswerQ
    {
        public int? Id { get; set; }

        public string Description { get; set; }

        public bool IsCorrect { get; set; }

        public int IdQuestion { get; set; }
    }
}
