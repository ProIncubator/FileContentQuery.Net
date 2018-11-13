using System.Collections.Generic;
using FileContentQuery.Core;
using FileContentQuery.Models;

namespace FileContentQuery.Implements
{
    public class LargeFileContentFind : IFileContentFind
    {
        public IEnumerable<FileContentFindResult> Find(string fileFullPath)
        {
            throw new System.NotImplementedException();
        }

        private class LargeFileImpl{

        }
    }
}