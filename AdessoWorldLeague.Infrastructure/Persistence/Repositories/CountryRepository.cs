using AdessoWorldLeague.Application.Interfaces;
using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Infrastructure.Persistence.Context;

namespace AdessoWorldLeague.Infrastructure.Persistence.Repositories;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(AdessoDbContext context) : base(context) { }
} 