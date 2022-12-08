#region License Information

// **********************************************************************************************************************************
// StringConstants.cs
// Last Modified: 2022/12/08 10:00 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

namespace AdventOfCode2022.Challenges.Day07
{
    public static class StringConstants
    {
        #region Static Fields and Constants

        public const string CommandPrefix = "$";
        public static string ParentDirectoryKey = "..";
        public static string RootDirectoryPath = "/";
        public static string CommandChangeDirectory = "cd";
        public static string CommandListDirectory = "ls";
        public static string DirectoryListIdentity = "dir";

        #endregion
    }
}