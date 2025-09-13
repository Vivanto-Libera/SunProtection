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
			Show();
		}
		else
		{
			Hide();
		}
	}
	
	public void Reset() 
	{
		SetStay(false);
	}
}
