using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        // public List<string> CreativeSmack { get; set; }

        public List<string> CreativeSmackList { get; } = new List<string>
        {
            "I’m not too worried.",
            "That's all you got?",
            "I remember my first time playing",
            "I could do better than that.",
            "Not looking good for you"
        };

        public override void Play(Player other)
        {
            int r = new Random().Next(5);
            Console.WriteLine(CreativeSmackList[r]);
            base.Play(other);
        }
    }
}