using CrudEmployee.Domain.Abstract;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using CrudEmployee.Domain.Entities;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Automapping;
using CrudEmployee.Domain.Helpers;
using CrudEmployee.Domain.MappingOverrides;

namespace CrudEmployee.Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static UnitOfWork()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Server=(local)\SQLEXPRESS; database=CrudEmployee; Integrated Security=SSPI;").ShowSql())
                .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<Employee>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<EmployeeOverrides>()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
