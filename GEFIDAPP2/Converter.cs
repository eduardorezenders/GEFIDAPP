using System;


namespace GEFIDAPP2
{
    public static class ConvertImage
    {
        public static string ImageToBase64(string path)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(path));
        }
        public static string ImageToBase64(byte[] array)
        {
            return Convert.ToBase64String(array);
        }
        public static byte[] Base64ToByte(string base64)
        {
            return Convert.FromBase64String(base64);
        }
    }
}