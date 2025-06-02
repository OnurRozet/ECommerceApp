using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Context;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options);