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


            higherPlayer.Play(smackTalker);


            Console.WriteLine("-------------------");

            HumanPlayer human = new HumanPlayer();
            human.Name = "Wilma";

            human.Play(higherPlayer);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            smackTalker.Play(large);

            Console.WriteLine("-------------------");

            CreativeSmackTalkingPlayer creativePlayer = new CreativeSmackTalkingPlayer();
            creativePlayer.Name = "Frank";

            creativePlayer.Play(human);

            List<Player> players = new List<Player>() {
                smackTalker, higherPlayer, human, large
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
                player1.Play(player2);
            }
        }
    }
}