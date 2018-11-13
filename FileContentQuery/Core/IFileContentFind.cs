using System;
using System.Collections.Generic;
using FileContentQuery.Models;

namespace FileContentQuery.Core
{
    public interface IFileContentFind
    {
        IEnumerable<FileContentFindResult> Find(String fileFullPath);
    }
}