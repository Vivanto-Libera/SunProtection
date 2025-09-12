using Godot;
using System;

public partial class Stay : TextureRect
{
	private bool isStay;

	public bool IsStay()
	{
		return isStay;
	}
	public void SetStay(bool isStay)
	{
		this.isStay = isStay;
		if (isStay)
		{
			GetNode<TextureRect>("Stay").Show();
		}
		else
		{
			GetNode<TextureRect>("Stay").Hide();
		}
	}
	
	public void Reset() 
	{
		SetStay(false);
	}
}
