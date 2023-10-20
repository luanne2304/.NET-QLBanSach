using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace bansach.Utils
{
    public class Utils
    {
        public static string HashPassword(string password)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
        public static string GenerateActivationToken()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static bool Sendmail(string to, string subject,string body )
        {
            try
            { 
                MailMessage msg = new MailMessage("mail@gmail.com", to,subject,body);
                using(var client=new SmtpClient("smtp.gmail.com",587)) 
                {
                    client.EnableSsl = true;
                    NetworkCredential credential = new NetworkCredential("mail@gmail.com", "qnjzqtossatjdvlh");
                    client.UseDefaultCredentials = false;
                    client.Credentials = credential;
                    client.Send(msg);

                }
            }
            catch(Exception) 
            {
                return false;
            }
            return true;
        }
    }
}