using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reti.NewCondeco
{

    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }

    public static class GlobalUnitOfWork
    {
        private static string CONTEXTKEY = "UnitOfWorkContext";
        private static readonly Hashtable _threads = new Hashtable();

        public static void Commit()
        {
            IUnitOfWork unitOfWork = GetUnitOfWork();

            if (unitOfWork != null)
            {
                unitOfWork.Commit();
            }
        }

        public static IUnitOfWork Current
        {
            get
            {
                IUnitOfWork unitOfWork = GetUnitOfWork();

                if (unitOfWork == null)
                {
                    unitOfWork = new EFUnitOfWork(new NewCondecoEntities());
                    SaveUnitOfWork(unitOfWork);
                }

                return unitOfWork;
            }
        }

        private static IUnitOfWork GetUnitOfWork()
        {
            if (OperationContext.Current != null && OperationContext.Current.RequestContext != null)
            {
                if (OperationContext.Current.RequestContext.RequestMessage.Properties.ContainsKey(CONTEXTKEY))
                {
                    return (IUnitOfWork)OperationContext.Current.RequestContext.RequestMessage.Properties[CONTEXTKEY];
                }
                return null;
            }
            else
            {
                Thread thread = Thread.CurrentThread;
                if (string.IsNullOrEmpty(thread.Name))
                {
                    thread.Name = Guid.NewGuid().ToString();
                    return null;
                }
                else
                {
                    lock (_threads.SyncRoot)
                    {
                        return (IUnitOfWork)_threads[Thread.CurrentThread.Name];
                    }
                }
            }
        }

        private static void SaveUnitOfWork(IUnitOfWork unitOfWork)
        {
            if (OperationContext.Current != null && OperationContext.Current.RequestContext != null)
            {
                OperationContext.Current.RequestContext.RequestMessage.Properties.Add(CONTEXTKEY, unitOfWork);
            }
            else
            {
                lock (_threads.SyncRoot)
                {
                    _threads[Thread.CurrentThread.Name] = unitOfWork;
                }
            }
        }
    }

    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        public DbContext Context { get; private set; }
        private volatile Type _dependency;

        public EFUnitOfWork(DbContext context)
        {
            // Thanks to this (useless) initialization System.Data.SqlClient will be included in published package
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            Context = context;
            context.Configuration.LazyLoadingEnabled = true;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}

