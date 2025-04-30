namespace AdessoWorldLeague.Domain.Entities;

public class Group
{
    public Group() {}
    public Group(string groupName) { GroupName = groupName; }

    public int Id { get; set; }
    public string GroupName { get; set; } = null!; 

    public List<Team> Teams { get; set; } = new();
    public Guid DrawId { get; set; }
    public Draw Draw { get; set; } = null!;
} 