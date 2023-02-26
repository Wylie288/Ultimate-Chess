using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public List<Sprite> spriteList;
	public List<GameObject> objectList;
	public GameObject[] destroyList;
    public int pieceID;
	public int color;
	public int value;
	public int x;
	public int y;

	

	public void OnMouseDown()
	{
		if (GameObject.FindWithTag ("Grid").GetComponent<BoardManager> ().gameState < 2) 
		{ //If build phase
			GameObject.FindWithTag ("Grid").GetComponent<BoardManager> ().points += value; // Add points back to pool
			GameObject.FindWithTag ("Grid").GetComponent<BoardManager> ().boardState [x, y, 0] = 0;

            //takes away specials used
            if (value == 0)
            {
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().kingUsed -= 1; //allows king to be replaced
            }
            
            if (value == 7 || value == 9)
            {
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().threeUsed -= 1;
            }

			Destroy (gameObject);
		}
	}

	public void DestroyMarkers()
	{
		destroyList = GameObject.FindGameObjectsWithTag ("MoveMarker");
		for (int i = 0; i < destroyList.Length; i++) 
		{
			Destroy (destroyList [i]);
		}
	}

	public void CreateMarker (int rx, int ry, int type)
	{
		if ((x + rx >= 0) && (x + rx <= 9) && (y + ry >= 0) && (y + ry <= 9)) //If not out of bounds
		{
            if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState - 2 == color)
            {  // Same color
                bool empty = false;
                if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x + rx, y + ry, 0] == 0)
                    empty = true;
                bool opponent = false;
                if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x + rx, y + ry, 1] != color)
                    opponent = true;

                //Move Only
                if ((type == 0) && (empty == true))
                    InstantiateMarker(rx, ry, type);
                //Take Only
                if ((type == 1) && (empty == false) && (opponent == true))
                    InstantiateMarker(rx, ry, type);
                //Move/Take
                if ((type == 2) && ((empty == true) || (opponent == true)))
                    InstantiateMarker(rx, ry, type);
            }
            else // Different color
            {
				if ((GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x + rx, y + ry, 1] != color) && (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x + rx, y + ry, 0] == 1) && (type > 0))
                {
                    GameObject.FindWithTag("Grid").GetComponent<BoardManager>().check = true;
                }
			}
		}
	}

    public void InstantiateMarker(int rx, int ry, int type)
    {
        GameObject instance = (GameObject)Instantiate(objectList[0], new Vector2(x * 58 + rx * 58, y * 58 + ry * 58), Quaternion.identity);
        instance.gameObject.GetComponent<MoveMarker>().instance = gameObject;
        instance.gameObject.GetComponent<MoveMarker>().oldx = x;
        instance.gameObject.GetComponent<MoveMarker>().oldy = y;
        instance.gameObject.GetComponent<MoveMarker>().newx = x + rx;
        instance.gameObject.GetComponent<MoveMarker>().newy = y + ry;
        instance.gameObject.GetComponent<MoveMarker>().pieceID = pieceID;
        instance.gameObject.GetComponent<MoveMarker>().color = color;
        if(GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x + rx, y + ry, 0] != 0) 
            if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[x + rx, y + ry, 1] != color ) //Makes blue or red
                instance.gameObject.GetComponent<MoveMarker>().type = 1;
        else
            instance.gameObject.GetComponent<MoveMarker>().type = 0;
    }
		
	public virtual void Movement ()
	{
	}
}

/* Piece ID:
 * 1: King
 * 2: Pawn
 * 3: Minion
 * 4: Rook
 * 5: Bishop
 * 6: Knight
 * 7: Queen
 * 8: Assassin
 * 9: Berserker
 * 10: Shield
 * 12: Bomber
 * 12: Disruptor
*/