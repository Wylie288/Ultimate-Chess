using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
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
		int i = 1;
		int stopped = 0;//false
		//up
		while (stopped==0)
		{
			base.CreateMarker(0, i, 2);
			if (y + i >= 9)
				stopped = 1;
			if (stopped == 0)
			if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x, y + i, 0] != 0)
				stopped = 1;
			i++;     
		}
		//right
		stopped = 0;
		i = 1;
		while (stopped == 0)
		{   
			base.CreateMarker(i, 0, 2);
			if (x + i >= 9)
				stopped = 1;
			if (stopped==0)
			if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x + i, y, 0] != 0)
				stopped = 1;

			i++;
		}
		//left
		stopped = 0;
		i = 1;
		while (stopped == 0)
		{
			base.CreateMarker(-i, 0, 2);
			if (x - i < 1)
				stopped = 1;
			if (stopped==0)
			if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x - i, y, 0] != 0)
				stopped = 1;

			i++;
		}
		//down
		stopped = 0;
		i = 1;
		while (stopped == 0)
		{
			base.CreateMarker(0, i *-1, 2);
			if (y - i < 1)
				stopped = 1;
			if (stopped==0)
			if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x, y - i, 0] != 0)
				stopped = 1;

			i++;
		}
	}
}
