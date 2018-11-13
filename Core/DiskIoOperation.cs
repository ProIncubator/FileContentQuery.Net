namespace FileContentQuery.Core
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FileContentQuery.Models;

    public class DiskIoOperation
    {
        private int ADD_LENGTH = 10;
        private QueryParameters _parameters;
        public DiskIoOperation(QueryParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            if (String.IsNullOrWhiteSpace(parameters.Directory))
                throw new ArgumentNullException(nameof(parameters.Directory));

            if (String.IsNullOrWhiteSpace(parameters.Match))
                throw new ArgumentNullException(nameof(parameters.Match));

            this._parameters = parameters;
        }

        public void Print()
        {
            this.Print(new DirectoryInfo(this._parameters.Directory));
        }

        private void Print(DirectoryInfo directory)
        {
            if (!directory.Exists) return;

            directory.GetDirectories().ToList().ForEach(this.Print);
            directory.GetFiles().ToList().ForEach(this.Print);
        }

        private void Print(FileInfo file)
        {
            if (!String.IsNullOrWhiteSpace(this._parameters.Include) && !Regex.IsMatch(file.FullName, this._parameters.Include)) return;
            if (!String.IsNullOrWhiteSpace(this._parameters.Exclude) && Regex.IsMatch(file.FullName, this._parameters.Exclude)) return;

            if (file.Length > 10 * 1024 * 1024) return;

            String[] lines = File.ReadAllLines(file.FullName);
            int lineIndex = 1;
            foreach (String line in lines)
            {
                String prefix = $"[{file.FullName}#{lineIndex}]";
                MatchCollection matches = Regex.Matches(line, this._parameters.Match);
                foreach (Match match in matches)
                {
                    if (match.Groups.Count <= 0) continue;
                    Group firstGroup = match.Groups[0];

                    String matchPrefix = line.SafeSubstring(firstGroup.Index - ADD_LENGTH, ADD_LENGTH);
                    String matchSuffix = line.SafeSubstring(firstGroup.Index + firstGroup.Value.Length, ADD_LENGTH);

                    Console.WriteLine($"{prefix}:{firstGroup.Index} {matchPrefix}{firstGroup.Value}{matchSuffix}");
                }
                lineIndex++;
            }
        }
    }
}