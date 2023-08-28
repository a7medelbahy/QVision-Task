using QVision_Task.Models;

namespace QVision_Task.Repository
{
    public interface IAccountRepository
    {
        void Create(Account account);

        bool Find(string Name, string Password);

        void Save();

        Account GetAccount(string Name, string Password);
    }
}
