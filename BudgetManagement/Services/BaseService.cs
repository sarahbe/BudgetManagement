using BudgetManagement.DAL;

namespace BudgetManagement.Services
{
    public class BaseService
    {
        public BudgetContext bctx; 
        public BaseService()
        {
            bctx = new BudgetContext();
        }
    }
}