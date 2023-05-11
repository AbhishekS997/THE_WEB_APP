using Microsoft.EntityFrameworkCore;

namespace THE_WEB_APP.Models;

public class PhoneNumberListContext : DbContext
{
    public PhoneNumberListContext(DbContextOptions<PhoneNumberListContext> options)
        : base(options)
    {
    }

    public DbSet<PhoneNumberListItem> PhoneNumberListItems { get; set; } = null!;
}