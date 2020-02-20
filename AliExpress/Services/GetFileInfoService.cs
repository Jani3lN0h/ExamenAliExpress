using AliExpress.Services.Interfaces;
using System;
using System.IO;

namespace AliExpress.Services
{
    public class GetFileInfoService : IGetFileInfoServices
    {
        public Func<string, string[]> ReaderFiles { get; set; }

        public GetFileInfoService()
        {
            ReaderFiles = (path) => File.ReadAllLines(path);
        }

        public string[] ReadFile(string path)
        {
            string[] arrPackages = ReaderFiles(path);
            return arrPackages;
        }
    }
}
