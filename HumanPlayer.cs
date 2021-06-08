using System;

namespace ShootingDice
{
    // TODO: Complete this class

    // A player the prompts the user to enter a number for a roll
    public class HumanPlayer : Player
    {
        public override void Play(Player other)
        {
            Console.Write("What number would you like to roll?");
            int rollSelect = Int32.Parse(Console.ReadLine());
            int otherRoll = other.Roll();

            // while (rollSelect >= 1 || rollSelect <= 6)
            // {
            if (rollSelect > otherRoll)
            {
                Console.WriteLine($"{Name} Wins!");
            }
            else if (rollSelect < otherRoll)
            {
                Console.WriteLine($"{other.Name} Wins!");
            }
            else
            {
                // if the rolls are equal it's a tie
                Console.WriteLine("It's a tie");
            }
            // }
        }

    }
}