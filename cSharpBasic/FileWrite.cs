namespace cSharpBasic
{
    using System;
    using System.IO;
    using System.Text;

    internal class FileWrite
    {
        public static string ReadFile(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                StreamReader reader = new StreamReader(FilePath, Encoding.GetEncoding("gb2312"));
                string str = reader.ReadToEnd().ToString();
                reader.Close();
                return str;
            }
            return "";
        }

        public static bool WriteFile(string Content, string FileSavePath)
        {
            if (File.Exists(FileSavePath))
            {
                File.Delete(FileSavePath);
            }
            FileStream stream = File.Create(FileSavePath);
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(Content);
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            stream = null;
            return true;
        }
    }
}

