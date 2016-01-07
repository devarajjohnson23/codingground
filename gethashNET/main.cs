using System.IO;
using System;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
         const string Param5 = "1f80e5afba29f966420a976d6071038d";
         const string Separator = "|";
       // string param1 = GetTimeAsString();
        string param1 = "1452165450131.76";
        string param2 = "20068";
        string param3 = "1";
        string param4 = "999999";

        string[] prmsList = new string[]
        {
            param1, param2, param3, param4
        };
        string str = string.Join(Separator, prmsList);
       
       // Where is the fifth option - always the same .
        str = str + Param5;
        Console.WriteLine("Param1 time stamp : "+param1);
        Console.WriteLine("External ID : "+param2);
        Console.WriteLine("Role code : "+param3);
        Console.WriteLine("Next higher id : "+param4);
        Console.WriteLine("Static value : "+Param5);
        
        Console.WriteLine("Input to hash : "+str);
        string hash = GetHash(str);
        string strResponse = string.Format("{0}{1}{2}", param1, Separator, hash);
        Console.Write("Output from hash : "+strResponse);
    }
    public static string GetHash(string str)
    {
        //SHA-1 hashed with key
        // After that, a standard SHA hashing algorithm is applied and the output is base-64 encoded.
        // System uses SHA 1 hashing algorithm, as described in "Hartford Carrier Integration" document.
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        SHA1 sha = new SHA1Managed();

        byte[] data = encoding.GetBytes(str);
        byte[] digest = sha.ComputeHash(data);
        string genHash = Convert.ToBase64String(digest);
        return genHash;
    }
    public static string GetTimeAsString()
    {
        string str = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString();
        str = str.Replace(',', '.');
        return str;
    }
}
