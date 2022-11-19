using Microsoft.EntityFrameworkCore;
using MonitorBackend.Data.Entity;
using MonitorBackend.Data.Repositories.Abstract;

namespace MonitorBackend.Data.Repositories;

public class LoadRepository : DbRepository<Load>
{
    public LoadRepository(MonitorDbContext context) : base(context)
    {
    }

    public override IQueryable<Load> Items => base.Items.Include(items => items.IdDeviceNavigation);
}