namespace EducationApplication.DAL.Data.Model
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }

        // Foreign Key

        // for Question
        public int QuestionsId { get; set; }
        public virtual Questions Questions { get; set; }
    }
}
