using System.Linq;
using CrudEmployee.Domain.Abstract;
using NHibernate;
using NHibernate.Linq;

namespace CrudEmployee.Domain.Concrete
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private UnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public TEntity GetOne(int id)
        {
            return Session.Get<TEntity>(id);
        }

        public void Create(TEntity entity)
        {
            Session.Save(entity);
        }

        public void Update(TEntity entity)
        {
            Session.Update(entity);
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<TEntity>(id));
        }
    }
}
