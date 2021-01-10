using ApiService.Data;
using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
namespace ApiService.Repositories {
    
    public interface IAuthRepo {
        Task<User> RegisterAsync(RegistrationCredentials newUser);
        Task<User> LoginAsync(AuthenticationCredentials creds);
        Task<bool> UserExists(string username);
    }

    public class AuthRepo : IAuthRepo {

        private readonly DataContext _context;
        private IConfiguration _config;

        public AuthRepo(IConfiguration config, DataContext context) {
            _config = config;
            _context = context;
        }

        public async Task<User> RegisterAsync(RegistrationCredentials newUser) {
            Contract.Requires(newUser != null);
            var encryptedUser = await CreateEncryptedUser(newUser);
            var userExists = await UserExists(encryptedUser.UserName);
            if (userExists) {
                return null;
            } else {
                await AddNewUserAsync(encryptedUser);
                return encryptedUser;
            }

        }

        public async Task<bool> UserExists(string username) {
            var user = await GetUser(username);
            if (user != null)
                return true;

            return false;
        }

        public async Task<User> LoginAsync(AuthenticationCredentials creds) {
            Contract.Requires(creds != null);
            var user = await GetUser(creds.username);
            if (user == null || !CredentialsMatch(creds.password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }


        private async Task<User> GetUser(string username) {
            return await _context.User.Include(p => p.Photos).FirstOrDefaultAsync(u => u.UserName == username);
        }

        private bool CredentialsMatch(string password, byte[] passwordHash, byte[] passwordSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) {
                    if (computedHash[i] != passwordHash[i]) {
                        return false;
                    }
                }
            }
            return true;
        }

        private async Task AddNewUserAsync(User user) {
            //_conn.Open();
            //var sql = GetType().Assembly.GetEmbeddedSqlQuery(_INSERT_SQL_FILE);
            //await _conn.QueryFirstOrDefaultAsync<User>(sql, new {
            //    @Username = user.UserName,
            //    @PasswordHash = user.PasswordHash,
            //    @PasswordSalt = user.PasswordSalt,
            //    @Email = user.Email,
            //    @FirstName = user.FirstName,
            //    @LastName = user.LastName
            //}).ConfigureAwait(false);
            //_conn.Close();
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        private async Task<User> CreateEncryptedUser(RegistrationCredentials newUser) {
            User encryptedUser = new User() {
                UserName = newUser.UserName,
                Email = newUser.Email,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
            };
            await encryptedUser.CreatePasswordHashAsync(newUser.PassWord);
            return encryptedUser;
        }

    }
}
