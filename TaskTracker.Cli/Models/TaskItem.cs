namespace TaskTracker.Cli.Models // organizational purposes, just keeps things tidy
{
    public class TaskItem 
    {
        // setting attributes for items that belong to this class
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}