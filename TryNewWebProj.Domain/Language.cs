using System.ComponentModel.DataAnnotations;

namespace TryNewWebProj.Domain
{
    public class Language
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual List<Word> Word { get; set; }
    }

    public class Word
    {
        public Guid LanguageId { get; set; }
        public Guid Id { get; set; }
        public string WordValue { get; set; }
        public string Translate { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual SettingsWord SettingsWord { get; set; }
        public virtual Language Language { get; set; }
    }

    public class SettingsWord
    {
        public Guid WordId { set; get; }
        public Guid Id { get; set; }
        [Range(0, 100, ErrorMessage = "")]
        public int? ProcentLearning { get; set; }

        [Range(1, 5)]
        public int? Stage { get; set; }
        //0-6 point   - 1 Stage
        //6-12 point  - 2 Stage
        //12-18 point - 3 Stage
        //18-24 point - 4 Stage
        public int? StagePoint { get; set; }
        public int? StagePointBall { get; set; }
        public DateTime? LastTreaning { get; set; }
        public DateTime CreationDate { get; set; }
        public int Difficult { get; set; }

        public virtual Word Word { get; set; }
    }
}