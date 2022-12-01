#region License Information

// **********************************************************************************************************************************
// AdventDateChallenge.cs
// Last Modified: 2022/12/01 11:19 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;

namespace AdventOfCode2022.Challenges
{
    public interface IAdventChallenge
    {
        int DayNumber { get; }
        string ChallengeOne { get; }
        string ChallengeTwo { get; }
        void ExecuteChallengeOne();
        void ExecuteChallengeTwo();
        bool IsChallengeOneReady {get;}
        bool IsChallengeTwoReady {get;}

    }

    public abstract class AdventChallengeBase : IAdventChallenge{
        #region Implementation of IAdventDateChallenge

        private static string _undefinedChallenge = "Challenge One has not yet been defined.";

        public int DayNumber => GetDayNumber();
        public string ChallengeOne => GetChallengeOneText();
        public string ChallengeTwo => GetChallengeTwoText();
        
        public bool IsChallengeOneReady => GetChallengeOneText() != _undefinedChallenge;
        public bool IsChallengeTwoReady => GetChallengeTwoText() != _undefinedChallenge;

        public void ExecuteChallengeOne() => ExecuteChallengeOneInternal();
        public void ExecuteChallengeTwo() => ExecuteChallengeTwoInternal();
        
        protected abstract int GetDayNumber();
        protected virtual string GetChallengeOneText() => _undefinedChallenge;
        protected virtual string GetChallengeTwoText() => _undefinedChallenge;
        protected virtual void ExecuteChallengeOneInternal() { Console.WriteLine("Not yet defined."); }
        protected virtual void ExecuteChallengeTwoInternal() { Console.WriteLine("Not yet defined."); }
        
        #endregion
    }
}