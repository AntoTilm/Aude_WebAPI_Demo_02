using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.DAL.Interfaces
{
    // Interface implémentant les méthodes indispensables à un Crud : Sera pratique pour créer nos Repositories
    // On pourrait aussi, dans un gros projet, pour aller plus loin, faire des interfaces pour IRead (avec juste les Get), ICreate (pour Creation), IUpdate (pour Update), IDelete (pour Delete). Notre ICrud implémenterait toutes ces interfaces.
    // Ainsi, un Repository qui n'aurait besoin que des Get, n'implémenterait que IRead
    public interface ICrud<TId, TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(TId id);
        TEntity Create(TEntity entity);
        bool Update(TId id, TEntity entity);
        bool Delete(TId id);
    }
}
