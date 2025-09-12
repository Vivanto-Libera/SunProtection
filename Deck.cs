using Godot;
using System;
using static Card.Face;

public partial class Deck : Node2D
{
	private int[] CardsNum = new int[4];

	private int FaceToIndex(Card.Face face) 
	{
		if((face & SunScreen) != 0) 
		{
			return 0;
		}
		else if ((face & Steel) != 0)
		{
			return 1;
		}
		else if ((face & StandUp) != 0)
		{
			return 2;
		}
		else 
		{
			return 3;
		}
	}

	public int[] GetCardsNum() 
	{
		return CardsNum;
	}
	public void IncreaseCardsNum(Card.Face face) 
	{
		CardsNum[FaceToIndex(face)]++;
		string labName = "Lab" + face.ToString();
		GetNode<Label>(labName).Text = "x" + CardsNum[FaceToIndex(face)];
	}
	public void DecreaseCardsNum(Card.Face face) 
	{
		CardsNum[FaceToIndex(face)]--;
		string labName = "Lab" + face.ToString();
		GetNode<Label>(labName).Text = "x" + CardsNum[FaceToIndex(face)];
	}
}
