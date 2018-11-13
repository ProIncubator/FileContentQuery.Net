using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using FileContentQuery.Core;
using FileContentQuery.Models;

namespace FileContentQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new ParameterHandler();
            var parameters = handler.ToModel<QueryParameters>(@"--include (cs|json)$ --exclude obj  --verbose --match (\d+\.){2,3}\d+ -dir ./");
            DiskIoOperation operate = new DiskIoOperation(parameters);
            operate.Print();
            // Directory.GetFiles("./").Select(f => new FileInfo(f)).Select(f => f.FullName).ToList().ForEach(Console.WriteLine);
        }

    }
}
