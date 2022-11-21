using Microsoft.EntityFrameworkCore;
using MonitorBackend.Data.Repositories.Abstract;
using Object = MonitorBackend.Data.Entity.Object;

namespace MonitorBackend.Data.Repositories;

public class ObjectRepository : DbRepository<Object>
{
    public ObjectRepository(MonitorDbContext context) : base(context)
    {
    }

    public override IQueryable<Object> Items => base.Items.Include(i => i.Loads);
}