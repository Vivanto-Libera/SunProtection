using Godot;
using System;

public partial class Card : TextureRect
{
	public enum Face 
	{
		Back,
		SunnyDay,
		FriendShip,
		FriendShipOver,
		Loss,
		Shuffle,
		StandUp,
		Stay,
		Steel,
		SunScreen,
		SunUmbrella,
	}
	private Face face = Face.Back;
	
	public Face GetFace() 
	{
		return face;
	}
	public void SetFace(Face value) 
	{
		face = value;
		string path = "res://Image/" + face.ToString() + ".png";
        Texture = GD.Load<Texture2D>(path);
    }
}
