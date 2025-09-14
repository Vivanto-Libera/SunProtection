using Godot;
using SunProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Card.Face;

public partial class Main : Node2D
{
	public Player humanplayer;
    public DrawPile drawPile;
    public TurnIndicator turnIndicator;
    public Stack<Card.Face> discardPile = new Stack<Card.Face>();
	public FriendShipBar.FriendShip usedFriendShip;
	public SelectPlayer selectPlayer;
	public int aliveNum;
	public AiPlayer[] aiPlayers = new AiPlayer[3];
	public void GameStart() 
	{
		ResetAll();
		drawPile.ShuffleDeck();
	}

	public void OnDrawedCard(int face) 
	{
		Acted(humanplayer, face);
	}
	public async void Acted(Player player, int face) 
	{
		switch ((Card.Face)face)
		{
			case SunScreen:
			case Steel:
			case StandUp:
				player.deck.IncreaseCardsNum((Card.Face)face);
				break;
			case SunUmbrella:
				if (player.deck.GetCardsNum()[3] != 1) 
				{
                    player.deck.IncreaseCardsNum((Card.Face)face);
                }
				break;
			case Shuffle:
				ShuffleDeck();
				break;
			case FriendShip:
				await AddFriendShip(player.PlayerNum);
				break;
		}
	}
	public void ShuffleDeck() 
	{
		drawPile.AddCardsFromDiscardPile(discardPile);
		drawPile.ShuffleDeck();
	}
	public async Task AddFriendShip(int player) 
	{
		int playerA;
		int playerB;
		if (GetUsedFriendShipNum() != (1 << (aliveNum - 2)) + 2)
		{
			if (player == 0)
			{
				selectPlayer.ShowButtons();
				for (int i = 0; i < 4; i++)
				{
					Player playeri = GetNode<Player>("Player" + i.ToString());

					if (playeri.friendShip.Count - 1 == aliveNum || playeri.IsDie())
					{
						selectPlayer.GetNode<Button>("Player" + i.ToString()).Hide();
					}
				}
				var signalArgs = await ToSignal(selectPlayer, SelectPlayer.SignalName.SelectedPlayer);
				playerA = (int)signalArgs[0];
				selectPlayer.GetNode<Button>("Player" + playerA.ToString()).Hide();
				foreach (int i in GetNode<Player>("Player" + playerA.ToString()).friendShip)
				{
					selectPlayer.GetNode<Button>("Player" + i.ToString()).Hide();
				}
				signalArgs = await ToSignal(selectPlayer, SelectPlayer.SignalName.SelectedPlayer);
				playerB = (int)signalArgs[0];
				selectPlayer.HideButtons();
			}
			else
			{
				int[] twoPlayer = aiPlayers[player - 1].AddFriendShip();
				playerA = twoPlayer[0];
				playerB = twoPlayer[1];
				if(playerA != player) 
				{
					aiPlayers[player - 1].PlayerNumToIndex(playerA).MakeFriendShip(true);
				}
                if (playerB != player)
                {
                    aiPlayers[player - 1].PlayerNumToIndex(playerB).MakeFriendShip(true);
                }
            }
			if(playerA != player && playerA != 0) 
			{
				aiPlayers[playerA - 1].PlayerNumToIndex(player).MakeFriendShip(false);
			}
            if (playerB != player && playerB != 0)
            {
                aiPlayers[playerB - 1].PlayerNumToIndex(player).MakeFriendShip(false);
            }
			Player player1 = GetNode<Player>("Player" + playerA.ToString());
			Player player2 = GetNode<Player>("Player" + playerB.ToString());
			FriendShipBar.FriendShip color = GetUnusedFriendShipColor();
			player1.friendShip.Add(playerB);
			player1.friendShipBar.AddFriendShip(color);
            player2.friendShip.Add(playerA);
            player2.friendShipBar.AddFriendShip(color);
        }
		discardPile.Push(FriendShip);
	}
	public int GetUsedFriendShipNum() 
	{
		int num = 0;
		for(int i = 0; i <= 5; i++) 
		{
			if ((usedFriendShip & (FriendShipBar.FriendShip)(1 << i)) != 0) 
			{
				num++;
			}
		}
		return num;
	}
	public FriendShipBar.FriendShip GetUnusedFriendShipColor() 
	{
		FriendShipBar.FriendShip color = 0;
        for (int i = 0; i <= 5; i++)
        {
            if ((usedFriendShip & (FriendShipBar.FriendShip)(1 << i)) == 0)
            {
				color = (FriendShipBar.FriendShip)(1 << i);
				break;
            }
        }
		return color;
    }
	private void ResetAll() 
	{
		for(int i = 0; i < 4; i++) 
		{
			string playerName = "Player" + i.ToString();
			GetNode<Player>(playerName).Reset();
		}
		foreach(AiPlayer aiplayer in aiPlayers) 
		{
			aiplayer.Reset();
		}
		drawPile.Reset();
		turnIndicator.Reset();
		discardPile.Clear();
		usedFriendShip = 0;
		selectPlayer.HideButtons();
		aliveNum = 4;
	}
	public override void _Ready()
	{
		humanplayer = GetNode<Player>("Player0");
		drawPile = GetNode<DrawPile>("DrawPile");
		turnIndicator = GetNode<TurnIndicator>("TurnIndicator");
		selectPlayer = GetNode<SelectPlayer>("SelectPlayer");
		for(int i = 1; i <= 3; i++) 
		{
			aiPlayers[i - 1] = new AiPlayer(GetNode<Player>("Player" + i.ToString()));
			for (int j = i + 1; j <= i + 3; j++) 
			{
				aiPlayers[i - 1].AddHateValue(GetNode<Player>("Player" + (j % 4).ToString()));
			}
		}
        GameStart();
	}
}
