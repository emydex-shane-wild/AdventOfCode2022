#region License Information

// **********************************************************************************************************************************
// ApplicationStart.cs
// Last Modified: 2022/12/01 11:19 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Linq;
using AdventOfCode2022.Providers;

namespace AdventOfCode2022.Architecture
{
    public interface IAppStart
    {
        void Start();
    }

    public class ApplicationStart :IAppStart
    {
        private readonly IAdventChallengeProvider _challengeProvider;

        public ApplicationStart(IAdventChallengeProvider challengeProvider)
        {
            _challengeProvider = challengeProvider;
        }

        #region Implementation of IAppStart

        public void Start()
        {
            Console.WriteLine("Welcome to the 2022 Advent Challenge!");
            Console.Write("Enter a challenge number to execute: ");
            var inputChallenge  = Console.ReadLine();
            if(int.TryParse(inputChallenge, out var challengeNumber))
            {
                var challenge = _challengeProvider.AdventDates.FirstOrDefault(d => d.DayNumber == challengeNumber);
                if(challenge != null)
                {
                    Console.WriteLine(challenge.ChallengeOne);
                    Console.WriteLine("Would you like to execute the challenge? (Y or N)");
                    var inputExecute  = Console.ReadKey();
                    if(inputExecute.Key == ConsoleKey.K)
                    {
                        Console.WriteLine();
                        challenge.ExecuteChallengeOne();
                    }
                }
                else Console.WriteLine($"A suitable challenge was not found for challenge number {challengeNumber}");
            }
            else
            {
                Console.WriteLine("Sorry, the input provided was not a suitable integer value.");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        #endregion
    }
}