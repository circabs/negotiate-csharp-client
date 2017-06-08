using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Security.Principal;


class Program
{

    static void Main(string[] args)
    {

        if (args.Length < 1) 
        {
            Console.WriteLine("Please specify url as first argument to app");
            Environment.Exit(1);
        }

        string url = args[0];
        try 
        {
            
            Uri uri = new Uri(url);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "GET";
            string hostname = Dns.GetHostEntry(uri.Host).HostName;
            req.Credentials = CredentialCache.DefaultCredentials;
            AuthenticationManager.CustomTargetNameDictionary[url] = "HTTP/" + hostname;
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            Encoding encoding = System.Text.Encoding.UTF8;
            StreamReader responseStream = new StreamReader(response.GetResponseStream(), encoding);
            string payload = responseStream.ReadToEnd();
            responseStream.Close();
            response.Close();
            Console.WriteLine(payload);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}
