namespace PizzaStore.Models
{
    public class DatabaseConnectionOptions
    {
        public const string SectionName = "ConnectionString";
        public string? DefaultConnection { get; set; } = string.Empty;
    }
}
