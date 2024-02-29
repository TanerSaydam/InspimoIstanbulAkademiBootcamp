using PersonelServer.Context;

namespace PersonelServer.Repositories;

public interface IUnitOfWork
{
    int SaveChanges();    
}
