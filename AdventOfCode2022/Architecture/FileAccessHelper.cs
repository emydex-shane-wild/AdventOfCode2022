#region License Information

// **********************************************************************************************************************************
// FileAccessHelper.cs
// Last Modified: 2022/12/02 12:20 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System.Linq;
using System.Reflection;

namespace AdventOfCode2022.Challenges.DayOne
{
    public static class FileAccessHelper
    {
        public static byte[] GetResourceData(string resourceName)
        {
            var embeddedResource = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(s => s.Contains(resourceName));

            if (string.IsNullOrWhiteSpace(embeddedResource)) return null;

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResource))
            {
                var data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }
    }
}