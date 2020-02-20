using System;

namespace AliExpress.Services.Interfaces
{
    public interface IGetPackagesMessages
    {
        void GetMessage(string path, DateTime dtToday);
    }
}
