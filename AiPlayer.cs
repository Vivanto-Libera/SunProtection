using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace SunProtection
{
    public class AiPlayer
    {
        public Player player;
        public List<HateValue> oppsites = new List<HateValue>();
        public AiPlayer(Player player) 
        {
            this.player = player;
            for (int i = player.PlayerNum + 1; i <= player.PlayerNum + 3; i++) 
            {
                oppsites.Add(new HateValue(i % 4));
            }
        }


    }
    
    public class HateValue 
    {
        public int who 
        {
            get;
        }
        private int hateValue = 0;

        public int GetHateValue() 
        {
            return hateValue;
        }
        public void LostSunscreen(bool isYou) 
        {
            int value = isYou ? 10 : -10;
            ChangeHateValue(value);
        }
        public void MakeFriendShip(bool isYou)
        {
            int value = isYou ? 5 : -5;
            ChangeHateValue(value);
        }
        public void LostUmbrella(bool isYou) 
        {
            int value = isYou ? 30 : -30;
            ChangeHateValue(value);
        }
        private void ChangeHateValue(int value) 
        {
            hateValue += value;
        }

        public HateValue(int who) 
        {
            this.who = who;
        }
    }
}
