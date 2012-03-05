using System.Data;
using System.Web.Mvc;
using NHibernate;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace webapi.Infrastructure
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            DependencyResolver.Current.GetService<ISession>().BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            ITransaction currentTransaction = DependencyResolver.Current.GetService<ISession>().Transaction;

            try
            {
                if (currentTransaction.IsActive)
                    if (actionExecutedContext.Exception != null)
                        currentTransaction.Rollback();
                    else
                        currentTransaction.Commit();
            }
            finally
            {
                currentTransaction.Dispose();
            }
        }
    }
}