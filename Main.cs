using Godot;
using System;
using System.Collections.Generic;
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
	public void GameStart() 
	{
		ResetAll();
		drawPile.ShuffleDeck();
	}

	public void OnDrawedCard(int face) 
	{
		Acted(humanplayer, face);
	}
	public void Acted(Player player, int face) 
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

			}
		}
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
	private void ResetAll() 
	{
		for(int i = 0; i < 4; i++) 
		{
			string playerName = "Player" + i.ToString();
			GetNode<Player>(playerName).Reset();
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
        GameStart();
	}
}
