using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece 
{
    public void Start()
    {
		gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[color+(LoadLevel.styleSelect * 2)] as Sprite;
    }

	new public void OnMouseDown()
	{
		base.OnMouseDown(); //Allows destroy
		base.DestroyMarkers ();
		Movement ();
        
	}

	public override void Movement()
	{
		if(color == 0)
		{
			base.CreateMarker(0, 1, 0);
			if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x, y + 1, 0] == 0)
				base.CreateMarker(0, 2, 0);
			base.CreateMarker(-1, 1, 1);
			base.CreateMarker(1, 1, 1);
		}
		if (color == 1)
		{
			base.CreateMarker(0, -1, 0);
			if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x, y - 1, 0] == 0)
				base.CreateMarker(0, -2, 0);
			base.CreateMarker(-1, -1, 1);
			base.CreateMarker(1, -1, 1);
		}
	}
}
