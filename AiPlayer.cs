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

        public int[] AddFriendShip() 
        {
            int[] players = new int[2];
            foreach (HateValue oppsite in oppsites) 
            {
                if (oppsite.who.deck.GetCardsNum()[3]== 1
                    && player.friendShip.Contains(oppsite.who.PlayerNum) == false) 
                {
                    players[0] = player.PlayerNum;
                    players[1] = oppsite.who.PlayerNum;
                    return players;
                }
            }

        }

        public void AddHateValue(Player player) 
        {
            oppsites.Add(new HateValue(player));
        }
        public AiPlayer(Player player) 
        {
            this.player = player;
        }
    }
    
    public class HateValue 
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
