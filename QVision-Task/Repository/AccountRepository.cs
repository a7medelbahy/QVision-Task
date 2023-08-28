using QVision_Task.Models;

namespace QVision_Task.Repository
{
    public class AccountRepository:IAccountRepository
    {
        QvisionContext context;
        public AccountRepository(QvisionContext _context)
        {
            this.context = _context;
        }

        public void Create(Account account)
        {
            context.accounts.Add(account);
        }

        public bool Find(string Name, string Password)
        {
            Account account = context.accounts.FirstOrDefault(a => a.Name == Name && a.Password == Password);
            if (account != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Account GetAccount(string Name, string Password)
        {
            return context.accounts.FirstOrDefault(a => a.Name == Name && a.Password == Password);
        }
    }
}
