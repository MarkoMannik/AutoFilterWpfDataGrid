namespace AutoFilterWpfDataGridDemo.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? IsMarried { get; set; }

        public DateTime? MarriedDate { get; set; }

        public Nationality? Nationality { get; set; }

        public double? Height { get; set; }

        public int? ShoeSize { get; set; }

        public decimal? NetIncome { get; set; }

        public TimeSpan? WakeUpTime { get; set; }

        public Guid? UniqueGuidId { get; set; }
    }

    public enum Nationality
    {
        American, Mexican, Estonian, Spanish, Other
    }
}
