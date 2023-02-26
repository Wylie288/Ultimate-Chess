using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public void Start()
    {
		gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[color+(LoadLevel.styleSelect * 2)] as Sprite;
    }

    new public void OnMouseDown()
    {
        base.OnMouseDown(); //Allows destroy
        base.DestroyMarkers();
		Movement ();
    }

	public override void Movement()
	{
		base.CreateMarker(-1, 2, 2);
		base.CreateMarker(-2, 1, 2);
		base.CreateMarker(-2, -1, 2);
		base.CreateMarker(-1, -2, 2);
		base.CreateMarker(1, -2, 2);
		base.CreateMarker(2, -1, 2);
		base.CreateMarker(2, 1, 2);
		base.CreateMarker(1, 2, 2);
	}
}
