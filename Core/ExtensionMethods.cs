namespace FileContentQuery.Core
{
    using System;
    public static class ExtensionMethods
    {
        public static String SafeSubstring(this String input, int index, int length)
        {
            if (index == 0) index = 0;
            if (input.Length <= index) return input;
            if (input.Length <= index + length) return input.Substring(index, input.Length - index);
            return input.Substring(index, length);
        }
    }
}