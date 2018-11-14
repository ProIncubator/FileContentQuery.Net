using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FileContentQuery.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileInfo reader = new FileInfo(@"E:\Windows10-64.iso");
            FileInfo writer = new FileInfo(@"E:\temp.iso");
            byte[] buffer = new byte[1024];
            int seek = 0;
            int readLength = 0;
            using (FileStream fs = reader.OpenRead())
            {
                while ((readLength = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    using (FileStream write = writer.OpenWrite())
                    {
                        write.Seek(seek, SeekOrigin.Current);
                        write.Write(buffer, 0, readLength);
                    }
                    seek += readLength;
                }
            }
        }
    }
}
