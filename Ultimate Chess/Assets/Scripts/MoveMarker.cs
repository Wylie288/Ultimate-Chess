using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveMarker : MonoBehaviour 
{
	public int pieceID;
	public int color;
	public int oldx;
	public int oldy;
	public int newx;
	public int newy;
	public int type; 
	public GameObject instance;
	public GameObject fireworks;
	public List<Sprite> spriteList;
	public GameObject[] piece;

	void Start()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[type] as Sprite;
	}

	void OnMouseDown()
	{
		//instance.transform.position = gameObject.transform.position;
		instance.gameObject.GetComponent<Piece> ().DestroyMarkers ();
		instance.gameObject.GetComponent<Piece> ().x = newx;
		instance.gameObject.GetComponent<Piece> ().y = newy;
		GameObject.FindWithTag ("Grid").GetComponent<BoardManager> ().boardState [oldx, oldy, 0] = 0;
		GameObject.FindWithTag ("Grid").GetComponent<BoardManager> ().boardState [newx, newy, 0] = pieceID;
		GameObject.FindWithTag ("Grid").GetComponent<BoardManager> ().boardState [newx, newy, 1] = color;
		if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[newx, newy, 0] > 0)
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, LayerMask.GetMask("Piece"));
			if ((hit.collider != null) && (hit.transform.gameObject != GameObject.FindGameObjectWithTag("Grid"))) // If clicked on grid
			{
				if (hit.transform.GetComponent<Piece>().pieceID == 1)
				{
					if (hit.transform.GetComponent<Piece>().color == 0)
						GameObject.FindWithTag("Grid").GetComponent<BoardManager>().winVar = 1;
					if (hit.transform.GetComponent<Piece>().color == 1)
						GameObject.FindWithTag("Grid").GetComponent<BoardManager>().winVar = 2;
					Instantiate (fireworks, new Vector3 (5 * 58 +29, 1 * 58 +29), Quaternion.Euler(-90, 0, 0));
					Instantiate (fireworks, new Vector3 (2 * 58 +29, 3 * 58 +29), Quaternion.Euler(-90, 0, 0));
					Instantiate (fireworks, new Vector3 (7 * 58 +29, 3 * 58 +29), Quaternion.Euler(-90, 0, 0));
					piece = GameObject.FindGameObjectsWithTag("IndPiece");
					for (int i = 0; i < piece.Length; i++)
					{
						if (piece[i].GetComponent<Piece>().color != GameObject.FindWithTag("Grid").GetComponent<BoardManager>().winVar - 1)
							piece[i].SetActive(false);
					}
				}
				Destroy(hit.transform.gameObject);
			}
		}
		instance.transform.position = gameObject.transform.position;

		switch (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState)
		{
		case 2:
			GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState = 3;
			break;
		case 3:
			GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState = 2;
			break;
		}

		GameObject.FindWithTag("Grid").GetComponent<BoardManager>().check = false;
		piece = GameObject.FindGameObjectsWithTag("IndPiece");
		for (int i = 0; i < piece.Length; i++)
		{
			if (piece[i].GetComponent<Piece>().color + 2 != GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState)
				piece[i].GetComponent<Piece>().Movement ();
		}
	}
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveMarker : MonoBehaviour 
{
	public int pieceID;
	public int color;
	public int oldx;
	public int oldy;
	public int newx;
	public int newy;
    public int type; 
    public GameObject instance;
	public GameObject instance2;
	public GameObject fireworks;
    public List<Sprite> spriteList;
	public GameObject[] piece;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[type] as Sprite;
    }

    void OnMouseDown()
	{
		//instance.transform.position = gameObject.transform.position;
		instance.gameObject.GetComponent<Piece> ().DestroyMarkers ();
		instance.gameObject.GetComponent<Piece> ().x = newx;
		instance.gameObject.GetComponent<Piece> ().y = newy;
		GameObject.FindWithTag ("Grid").GetComponent<BoardManager> ().boardState [oldx, oldy, 0] = 0;
		GameObject.FindWithTag ("Grid").GetComponent<BoardManager> ().boardState [newx, newy, 0] = pieceID;
		GameObject.FindWithTag ("Grid").GetComponent<BoardManager> ().boardState [newx, newy, 1] = color;
        if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().boardState[newx, newy, 0] > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, LayerMask.GetMask("Piece"));
            if ((hit.collider != null) && (hit.transform.gameObject != GameObject.FindGameObjectWithTag("Grid"))) // If clicked on grid
            {
                if (hit.transform.GetComponent<Piece>().pieceID == 1)
                {
                    if (hit.transform.GetComponent<Piece>().color == 0)
                        GameObject.FindWithTag("Grid").GetComponent<BoardManager>().winVar = 1;
                    if (hit.transform.GetComponent<Piece>().color == 1)
                        GameObject.FindWithTag("Grid").GetComponent<BoardManager>().winVar = 2;
					GameObject instance2 = (GameObject)Instantiate (fireworks, new Vector3 (5 * 58 +29, 1 * 58 +29), Quaternion.Euler(-90, 0, 0));
					instance2 = (GameObject)Instantiate (fireworks, new Vector3 (2 * 58 +29, 3 * 58 +29), Quaternion.Euler(-90, 0, 0));
					instance2 = (GameObject)Instantiate (fireworks, new Vector3 (7 * 58 +29, 3 * 58 +29), Quaternion.Euler(-90, 0, 0));

                }
                Destroy(hit.transform.gameObject);
            }
        }
        instance.transform.position = gameObject.transform.position;

        switch (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState)
        {
            case 2:
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState = 3;
                break;
            case 3:
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState = 2;
                break;
        }

        GameObject.FindWithTag("Grid").GetComponent<BoardManager>().check = false;
		piece = GameObject.FindGameObjectsWithTag("IndPiece");
		for (int i = 0; i < piece.Length; i++)
		{
			if (piece[i].GetComponent<Piece>().color + 2 != GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState)
				piece[i].GetComponent<Piece>().Movement ();
		}
    }
}*/
