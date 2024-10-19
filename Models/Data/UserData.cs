using AppBank.App.Utils;
using AppBank.Models.DBContext;
using AppBank.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppBank.Models.Data
{
    public interface IUserData
    {
        ListDataModel List();
        UserAccount Get(int id);
        Boolean Insert(UserAccount userAccount);
        Boolean Edit(UserAccount userAccount);
        Boolean Delete(UserAccount userAccount);
        UserAccount GetByAccount(string account);
    }
    public class UserData: IUserData
    {
        private readonly ILogger<UserData> logger;
        private readonly AppDBContext appDBContext;

        public UserData(ILogger<UserData> logger, AppDBContext appDBContext)
        {
            this.logger = logger;
            this.appDBContext = appDBContext;
        }

        public ListDataModel List()
        {
            var result = appDBContext.UserAccounts
                                    .ToList();
            int totalrows = result.Count;
            int totalrowsafterfiltering = result.Count;
            return new ListDataModel(result, totalrows, totalrowsafterfiltering);
        }
        public UserAccount Get(int id)
        {
            UserAccount userAccount = new UserAccount();
            userAccount = appDBContext.UserAccounts
                        .Where(u => u.UserID == id)
                        .FirstOrDefault<UserAccount>();

            return userAccount;
        }
        public UserAccount GetByAccount(string account)
        {
            UserAccount userAccount = new UserAccount();
            userAccount = appDBContext.UserAccounts
                        .Where(u => u.Account == account)
                        .FirstOrDefault<UserAccount>();

            return userAccount;
        }
        public Boolean Insert(UserAccount userAccount)
        {
            Boolean isInserted = false;
            try
            {
                appDBContext.UserAccounts.Add(userAccount);
                appDBContext.SaveChanges();
                isInserted = true;
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }

        public Boolean Edit(UserAccount userAccount)
        {
            Boolean isEdited = false;
            try
            {
                appDBContext.Entry(userAccount).State = EntityState.Modified;
                appDBContext.SaveChanges();
                isEdited = true;
            }
            catch (Exception ex)
            {
            }
            return isEdited;
        }

        public Boolean Delete(UserAccount userAccount)
        {
            Boolean isDeleted = false;
            try
            {
                appDBContext.UserAccounts.Remove(userAccount);
                appDBContext.SaveChanges();
                isDeleted = true;
            }

            catch (Exception ex)
            {
                isDeleted = false;
            }
            return isDeleted;
        }
    }
}
