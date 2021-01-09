using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models {
    public class UserPostModel {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class User {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public User() {

        }

        public User(string username, string passWord) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
                this.PasswordHash = hmac.Key;
                this.PasswordSalt = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passWord));
            }
        }

        public async Task CreatePasswordHashAsync(string passWord) {
            await Task.Run(() => {
                using (System.Security.Cryptography.HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512()) {
                    this.PasswordSalt = hmac.Key;
                    this.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passWord));
                }
                //return Task.FromResult(2);
            });
        }

    }
}
