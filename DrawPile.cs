using Godot;
using System;
using System.Collections.Generic;
using static Card.Face;

public partial class DrawPile : Node2D
{
	private Stack<Card.Face> deck = new Stack<Card.Face>();

	private void AddCardsToDeck(Card.Face face, int count) 
	{
		for (int i = 0; i < count; i++)
		{
			deck.Push(face);
		}
	}
	public void ShuffleDeck() 
	{
		Stack<Card.Face> newDeck = new Stack<Card.Face>();
		Card.Face[] oldDeck = new Card.Face[deck.Count];
		deck.CopyTo(oldDeck, 0);
		while(newDeck.Count != deck.Count) 
		{
			
		}
	}

	public void Reset()
	{
		deck.Clear();
		AddCardsToDeck(SunScreen, 8);
		AddCardsToDeck(StandUp, 4);
		AddCardsToDeck(SunnyDay, 16);
		AddCardsToDeck(SunUmbrella, 2);
		AddCardsToDeck(Steel, 4);
		AddCardsToDeck(Shuffle, 1);
		AddCardsToDeck(Loss, 5);
		AddCardsToDeck(FriendShipOver, 4);
		AddCardsToDeck(FriendShip, 6);
		AddCardsToDeck(StayHome, 4);
	}
}
