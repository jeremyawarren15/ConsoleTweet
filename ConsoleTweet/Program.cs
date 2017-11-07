using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace ConsoleTweet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make a list to store the credentials
            List<string> credentials = new List<string>();

            // See if there is a credentials file
            if (File.Exists("creds.txt"))
            {
                credentials.AddRange(ReadCredentials());
            }
            else
            {
                credentials.AddRange(GetCredentials());
                SaveCredentials(credentials);
            }

            // Authenticate the user
            Auth.SetUserCredentials(credentials[0], credentials[1], credentials[2], credentials[3]);
            var user = User.GetAuthenticatedUser();

            Console.WriteLine(user.Name);
        }

        public static List<string> GetCredentials()
        {
            List<string> creds = new List<string>();

            Console.Write("Consumer Key: ");
            creds.Add(Console.ReadLine());
            Console.Write("Consumer Secret: ");
            creds.Add(Console.ReadLine());
            Console.Write("Access Token: ");
            creds.Add(Console.ReadLine());
            Console.Write("Access Token Secret: ");
            creds.Add(Console.ReadLine());
            return creds;
        }

        public static void SaveCredentials(List<string> creds)
        {
            TextWriter tw = new StreamWriter("creds.txt");

            foreach (String s in creds)
                tw.WriteLine(s);

            tw.Close();
        }

        public static List<string> ReadCredentials()
        {
            string line;
            List<string> creds = new List<string>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader("creds.txt");
            while ((line = file.ReadLine()) != null)
            {
                creds.Add(line);
            }

            file.Close();
            return creds;
        }
    }
}
