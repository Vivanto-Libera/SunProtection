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
            var choises = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            for (int i = 0; i < 4; i++)
            {
                HateValue oppsite = oppsites[i];
                if (oppsite.who.IsDie()) 
                {
                    continue;
                }
                int prioprityValue = oppsite.GetHateValue();
                prioprityValue += oppsite.who.deck.GetCardsNum()[3] == 1 ? -100 : 0;
                for(int j = i + 1; j < 4; j++) 
                {
                    HateValue otherOppsite = oppsites[j];
                    if (otherOppsite.who.IsDie() || oppsite.who.friendShip.Contains(otherOppsite.who.PlayerNum)) 
                    {
                        continue;
                    }
                    prioprityValue = otherOppsite.GetHateValue();
                    prioprityValue += otherOppsite.who.deck.GetCardsNum()[3] == 1 ? -100 : 0;
                    int[] twoPlayer = new int[2]{oppsite.who.PlayerNum, otherOppsite.who.PlayerNum};
                    choises.Enqueue(twoPlayer, prioprityValue);
                }
                choises.Enqueue([oppsite.who.PlayerNum, player.PlayerNum], -400);
            }
            return choises.Dequeue();
        }

        public void AddHateValue(Player player) 
        {
            oppsites.Add(new HateValue(player));
        }
        public HateValue PlayerNumToIndex(int playerNum) 
        {
            int index = -1;
            for(int i = 0; i <= 3; i++) 
            {
                if (oppsites[i].who.PlayerNum == playerNum)
                {
                    index = i;
                    break;
                }
            }
            return oppsites[index];
        }
        public void Reset() 
        {
            foreach(HateValue oppsite in oppsites) 
            {
                oppsite.Reset();
            }
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
        public void Reset() 
        {
            hateValue = 0;
        }
        public HateValue(Player who) 
        {
            this.who = who;
        }
    }
}
