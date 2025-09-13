using System;
using Godot;

namespace SunProtection
{
    public class AiPlayer
    {
        public Player player;

        public AiPlayer(Player player) 
        {
            this.player = player;
        }


    }
    
    internal class HateValue 
    {
        public Player who 
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

        public HateValue(Player who) 
        {
            this.who = who;
        }
    }
}
