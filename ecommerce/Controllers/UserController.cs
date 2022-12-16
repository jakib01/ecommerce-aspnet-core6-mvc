using Microsoft.AspNetCore.Mvc;
using ecommerce.DAL;
using ecommerce.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ecommerce.Controllers
{
    public class UserController : Controller
    {
        EcommerceDotnetCoreDibboContext db = new EcommerceDotnetCoreDibboContext();
        
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                try {

                    var hashsalt = EncryptPassword(user.Password);
                    user.Password = hashsalt.Hash;
                    user.CreatedDate = DateTime.Now;

                    db.Users.Add(user);

                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Login");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }

            }

            return View();
        }


        public HashSalt EncryptPassword(String password)
        {
            byte[] salt = new byte[128 / 8]; // Generate a 128-bit salt using a secure PRNG
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return new HashSalt { Hash = encryptedPassw, Salt = salt };

        }


    }
}
