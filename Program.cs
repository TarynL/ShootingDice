using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            SmackTalkingPlayer smackTalker = new SmackTalkingPlayer();
            smackTalker.Name = "Bob";

            OneHigherPlayer higherPlayer = new OneHigherPlayer();
            higherPlayer.Name = "Sue";


            // higherPlayer.Play(smackTalker);


            // Console.WriteLine("-------------------");

            HumanPlayer human = new HumanPlayer();
            human.Name = "Wilma";

            // human.Play(higherPlayer);

            // Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            // smackTalker.Play(large);

            // Console.WriteLine("-------------------");

            CreativeSmackTalkingPlayer creativePlayer = new CreativeSmackTalkingPlayer();
            creativePlayer.Name = "Frank";
            SoreLoserPlayer loser = new SoreLoserPlayer();
            loser.Name = "Donny";

            // creativePlayer.Play(loser);

            Console.WriteLine("-------------------");

            UpperHalfPlayer topPlayer = new UpperHalfPlayer();
            topPlayer.Name = "Gussy";

            // topPlayer.Play(loser);

            SoreLoserUpperHalfPlayer topLoser = new SoreLoserUpperHalfPlayer();
            topLoser.Name = "Karen";



            List<Player> players = new List<Player>() {
                smackTalker, higherPlayer, human, large, creativePlayer, loser,
                topPlayer, topLoser
            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                try
                {
                    player1.Play(player2);
                }
                catch (Exception ex)
                {

                    if (ex.Message == "Ugh. I never get to win.")
                    {
                        Console.WriteLine("Get over it");
                        continue;
                    }

                    if (ex.Message == "That is impossible.")
                    {
                        Console.WriteLine("All done.");

                    }
                }
            }
        }
    }
}