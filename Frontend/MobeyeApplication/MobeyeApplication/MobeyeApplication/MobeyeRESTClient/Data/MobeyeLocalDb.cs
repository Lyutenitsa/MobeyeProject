using MobeyeApplication.MobeyeRESTClient.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeyeApplication.MobeyeRESTClient.Data
{
    public class MobeyeLocalDb
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public MobeyeLocalDb()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(User).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
        //get user by role
        public Task<User> GetUserByRole(string role)
        {
            return Database.Table<User>().Where(i => i.Role == role).FirstOrDefaultAsync();
        }
        //get user by id
        public Task<User> GetUserById(int id)
        {
            return Database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        //get user by phoneIMEi and authPrivateKey -> for open door and message status
        public Task<User> GetUserByIMEIAndAuthPrivateKey(string phoneIMEI, string authPrivateKey)
        {
            return Database.Table<User>().Where(i => i.PhoneIMEI == phoneIMEI && i.AuthPrivateKey == authPrivateKey).FirstOrDefaultAsync();
        }
        //get user by phoneIMEI and registrationPrivateKey -> for check Authorization
        public Task<User> GetUserByIMEIAndRegistrationPrivateKey(string phoneIMEI, string registrationPrivateKey)
        {
            return Database.Table<User>().Where(i => i.PhoneIMEI == phoneIMEI && i.RegistrationPrivateKey == registrationPrivateKey).FirstOrDefaultAsync();
        }
        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return Database.UpdateAsync(user);
            }
            else
            {
                return Database.InsertAsync(user);
            }
        }
    }
}
