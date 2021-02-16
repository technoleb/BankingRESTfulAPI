using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankingRESTfulService.Web.Controller
{
    [ApiController]
    public class BankController : API.IInternetBankingApi
    {
        [Route("[controller]/api/version")]
        [Route("[controller]/api-version")]
        public string GetApiVersion()
        {
            return DateTime.UtcNow.ToString("yyyy.MM.dd") + ".1.0";
        }

        [Route("[controller]/api/calc/MD5/{value}")]
        [Route("[controller]/api/calc/{value}/MD5")]
        public string CalculateMD5(string value)
        {
            if (value != null && value != string.Empty)
            {
                StringBuilder hash = new StringBuilder();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] bytes = md5.ComputeHash(new UTF8Encoding().GetBytes(value));

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }
                return hash.ToString().ToUpper();
            }
            else
            {
                return "Enter Valid value";
            }
        }

        [Route("[controller]/api/password/strong/{password}"),]
        [Route("[controller]/api/is-password-strong/{password}")]
        public bool IsPasswordStrong(string password)
        {
            if (password != null && password != string.Empty && !password.Contains(' '))
            {
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperCase = new Regex(@"[A-Z]+");
                var hasLowerCase = new Regex(@"[a-z]+");
                var hasMinChar = new Regex(@".{8,16}");
                var hasSymbols = new Regex(@".[\W_]");
                var hasWhiteSpace = new Regex(@"[\s]");

                var isvalid = hasNumber.IsMatch(password)
                        && hasUpperCase.IsMatch(password)
                        && hasLowerCase.IsMatch(password)
                        && hasMinChar.IsMatch(password)
                        && hasSymbols.IsMatch(password)
                        && !hasWhiteSpace.IsMatch(password);

                return isvalid;
            }
            else
            {
                return false;
            }
        }
    }
}
