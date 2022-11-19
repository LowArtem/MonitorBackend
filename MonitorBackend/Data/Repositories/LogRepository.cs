using Microsoft.EntityFrameworkCore;
using MonitorBackend.Data.Entity;
using MonitorBackend.Data.Repositories.Abstract;

namespace MonitorBackend.Data.Repositories;

public class LogRepository : DbRepository<Log>
{
    public LogRepository(MonitorDbContext context) : base(context)
    {
    }

    public override IQueryable<Log> Items => base.Items
        .Include(item => item.IdAlertlevelNavigation)
        .Include(item => item.IdTypeoflogNavigation);
}