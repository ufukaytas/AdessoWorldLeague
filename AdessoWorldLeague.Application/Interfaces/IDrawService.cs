using AdessoWorldLeague.Application.DTOs;


namespace AdessoWorldLeague.Application.Interfaces;

public interface IDrawService
{
    Task<DrawResultDto> DrawGroupsAsync(int groupCount, string drawnBy);
    Task<List<DrawResultDto>> GetAllDrawsAsync();
} 