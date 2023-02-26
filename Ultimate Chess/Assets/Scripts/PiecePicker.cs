using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePicker : MonoBehaviour 
{

    public int pieceID = 0;
	public int color = 0;
    public List<Sprite> spriteList;

    void Start ()
    {
        SelectSprite();
    }

    void OnMouseDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, LayerMask.GetMask("Button"));
        if (hit.collider != null) // If clicked on
		{
            GameObject.FindWithTag("Grid").GetComponent<BoardManager>().pieceSelect = pieceID;
			GameObject.FindWithTag("Grid").GetComponent<BoardManager>().color = color;
			GameObject.FindWithTag("Selector").transform.position = hit.transform.position; // Move yellow selector
		}
    }

    public void SelectSprite()
    {
        if (color == 0)
			gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[pieceID - 1+(LoadLevel.styleSelect * 24)] as Sprite;
        if (color == 1)
			gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[pieceID + 11+(LoadLevel.styleSelect * 24)] as Sprite;
    }
}
