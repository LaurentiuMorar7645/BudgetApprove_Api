namespace BudgetApprovedApi.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Day { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public float Price { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
