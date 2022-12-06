#region License Information

// **********************************************************************************************************************************
// Movement.cs
// Last Modified: 2022/12/06 11:56 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

namespace AdventOfCode2022.Challenges.DayFive
{
    public interface IDirective
    {
        int AmountToMove { get; }
        int SourceStack { get; }
        int TargetStack { get; }
    }

    public class Movement : IDirective
    {
        public Movement(string directive)
        {
            var values = directive.Replace("move ", "")
                                  .Replace(" from ", ",")
                                  .Replace(" to ", ",");
            var valArr = values.Split(',');
            if(valArr.Length == 3)
            {
                AmountToMove = int.Parse(valArr[0]);
                SourceStack = int.Parse(valArr[1]);
                TargetStack = int.Parse(valArr[2]);
            }
        }

        #region Implementation of IDirective

        public int AmountToMove { get; }
        public int SourceStack { get; }
        public int TargetStack { get; }

        #endregion
    }
}