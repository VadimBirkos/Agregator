using System.IO;

namespace Agregator.Infrastructure
{
    public class FileReader:IFileReader
    {
        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}