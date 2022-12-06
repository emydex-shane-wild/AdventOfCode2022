#region License Information

// **********************************************************************************************************************************
// Crate.cs
// Last Modified: 2022/12/06 11:57 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

namespace AdventOfCode2022.Challenges.DayFive
{
    public interface ICrate
    {
        char SuppliesCode { get; }
    }

    public class Crate : ICrate
    {
        public Crate(char suppliesCode)
        {
            SuppliesCode = suppliesCode;
        }

        #region Implementation of ICrate

        public char SuppliesCode { get; }

        #endregion
    }
}