using System.Text.Json.Serialization;

namespace POCLoggingEFSerilog.Entity
{
    public class Grade
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public float Value { get; set; }
    }
}