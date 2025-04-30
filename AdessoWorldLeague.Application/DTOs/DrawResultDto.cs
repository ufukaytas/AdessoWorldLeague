namespace AdessoWorldLeague.Application.DTOs;

public class DrawResultDto
{
    public string DrawnBy { get; set; } = null!;
    public DateTime Date { get; set; }
    public List<GroupDto> Groups { get; set; } = new();
} 