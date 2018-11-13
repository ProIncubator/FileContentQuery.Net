using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FileContentQuery.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileInfo fi = new FileInfo(@"D:\Software\CentOS-7-x86_64-Everything-1611.iso");
            using (FileStream fs = fi.OpenRead())
            {
                //fs.Seek
            }
        }
    }
}
