using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : Piece
{
    public void Start()
    {
		gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[color+(LoadLevel.styleSelect * 2)] as Sprite;
    }

    new public void OnMouseDown()
    {
        base.OnMouseDown(); //Allows destroy
        base.DestroyMarkers();
		Movement();
    }

	public override void Movement()
	{
		if (color == 0)
		{
			base.CreateMarker(0, -2, 2);
			base.CreateMarker(0, -1, 2);
			base.CreateMarker(-1, 0, 2);
			base.CreateMarker(-2, 0, 2);
			base.CreateMarker(1, 0, 2);
			base.CreateMarker(2, 0, 2);
			base.CreateMarker(0, 1, 2);
			base.CreateMarker(-1, 1, 2);
			base.CreateMarker(-2, 1, 2);
			base.CreateMarker(1, 1, 2);
			base.CreateMarker(2, 1, 2);
			base.CreateMarker(-1, 2, 2);
			base.CreateMarker(-2, 2, 2);
			base.CreateMarker(0, 2, 2);
			base.CreateMarker(1, 2, 2);
			base.CreateMarker(2, 2, 2);
		}
		if (color == 1)
		{
			base.CreateMarker(0, 2, 2);
			base.CreateMarker(0, 1, 2);
			base.CreateMarker(-1, 0, 2);
			base.CreateMarker(-2, 0, 2);
			base.CreateMarker(1, 0, 2);
			base.CreateMarker(2, 0, 2);
			base.CreateMarker(0, -1, 2);
			base.CreateMarker(-1, -1, 2);
			base.CreateMarker(-2, -1, 2);
			base.CreateMarker(1, -1, 2);
			base.CreateMarker(2, -1, 2);
			base.CreateMarker(-1, -2, 2);
			base.CreateMarker(-2, -2, 2);
			base.CreateMarker(0, -2, 2);
			base.CreateMarker(1, -2, 2);
			base.CreateMarker(2, -2, 2);
		}
	}
}
