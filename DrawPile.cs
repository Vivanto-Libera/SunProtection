using Godot;
using System;
using System.Collections.Generic;
using static Card.Face;

public partial class DrawPile : Node2D
{
	[Signal]
	public delegate void DrawedCardEventHandler(int face);
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
		List<Card.Face> oldDeck = [.. deck];
		while(oldDeck.Count != 0) 
		{
			int index = GD.RandRange(0, oldDeck.Count - 1);
			newDeck.Push(oldDeck[index]);
			oldDeck.RemoveAt(index);
		}
		deck = new Stack<Card.Face>(newDeck);
	}

	public void OnButtonPressed() 
	{
		DrawCard();
	}

	public void DrawCard() 
	{
		Card.Face face = deck.Pop();
		GetNode<Card>("Card").SetFace(face);
		EmitSignal(SignalName.DrawedCard, (int)face);
	}
	public void SetBack() 
	{
		GetNode<Card>("Card").SetFace(Back);
	}

	public void setButtonDisable(bool isDisable) 
	{
		GetNode<Button>("Button").SetDeferred(Button.PropertyName.Disabled, isDisable);
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
		SetBack();
		setButtonDisable(false);
	}
}
