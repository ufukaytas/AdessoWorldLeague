namespace AdessoWorldLeague.Application.DTOs;

public class GroupDto
{
    public string GroupName { get; set; } = null!;
    public List<TeamDto> Teams { get; set; } = new();
} 