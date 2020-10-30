using System;
using System.IO;

namespace WebClient_Anbar_e_Sazemanha.Utilities
{
    public static class TokenTools
    {
        public static string GetAuthToken(string authTokenFilePath)
        {
            try
            {
                StreamReader authTokenFile = new StreamReader(authTokenFilePath);
                string curAuthToken = authTokenFile.ReadToEnd();
                authTokenFile.Close();
                return curAuthToken;
            }
            catch (FileNotFoundException ex)
            {
                throw new ApplicationException("Create a file name \"" + authTokenFilePath +
                                               "\" and put your AuthToken in it");
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Please check your path Directory");
            }
        }
    }
}
