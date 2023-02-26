using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public List<GameObject> objectList; //List for prefabs to avoid resources.oload
    public float selectionX;
    public float selectionY;
    public int gameState = 2; // p1 build, p2 build, p1 turn, p2 turn
    public int pieceSelect = 6;
    public int color = 0;
    public int points = 45;
    public int kingUsed = 1;
    public int threeUsed = 0;
    public Text specialText;
    public Text threeText;
    public Text Wtxt;
    public Text checkdisplay; 
    public int[,,] boardState = new int[10, 10, 3]; //Piece Type, Color, 
    public Text showPiece;
    public Text derp;
    public bool check = false;
    public int winVar = 0;
    public Text win;
    public Text turn;

    void Start()
    {
        for (int i = 0; i <= 9; i++)
            for (int j = 0; j <= 9; j++)
            {
                boardState[i, j, 0] = 0;
                boardState[i, j, 1] = 0;
            }
        //CreatePiece();
        checkdisplay.text = "not check";
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, LayerMask.GetMask("Grid"));
            if (hit.collider != null) // If clicked on grid
            {
                selectionX = (float)Math.Floor(hit.point.x / 58); // get x space
                selectionY = (float)Math.Floor(hit.point.y / 58); // get y space
                Debug.Log("Type: " + boardState[(int)selectionX, (int)selectionY, 0]);
                Debug.Log("Color: " + boardState[(int)selectionX, (int)selectionY, 1]);
            }
        }
        showName();

        Wtxt.text = "Points  (" + points + "/45)";
        threeText.text = "Tier three used  (" + threeUsed + " /2)";
        if (check == true)
            checkdisplay.text = "Check";
        else
        checkdisplay.text = " ";

        if (winVar == 1 )
            win.text = "A Winner is You";
        else if (winVar == 2)
        win.text = "Your'e Winner";

        if (gameState == 2)
            turn.text = "It's White's Turn";
        else if (gameState == 3)
            turn.text = "It's Black's Turn";
        //gamestate 2 = white 3 = black


    }

    void OnMouseDown()
    {
        if ((gameState == 0) || (gameState == 1))
            GetMouse(); //spanws a piece
    }

    private void GetMouse()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, LayerMask.GetMask("Grid"));
        if (hit.collider != null) // If clicked on grid
        {
            selectionX = (float)Math.Floor(hit.point.x / 58); // get x space
            selectionY = (float)Math.Floor(hit.point.y / 58); // get y space
            if (row())
            {
                CreatePiece();
                threeCounter();
            }


        }
    }

    public void CreatePiece()
    {
        if (points - pieceValue() >= 0) // if points are availa/e
        {
            GameObject instance = (GameObject)Instantiate(objectList[pieceSelect - 1], new Vector2(selectionX * 58, selectionY * 58), Quaternion.identity);
            instance.gameObject.GetComponent<Piece>().pieceID = pieceSelect;
            instance.gameObject.GetComponent<Piece>().color = color;
            instance.gameObject.GetComponent<Piece>().value = pieceValue();
            points -= pieceValue();
            instance.gameObject.GetComponent<Piece>().x = (int)selectionX;
            instance.gameObject.GetComponent<Piece>().y = (int)selectionY;
            boardState[(int)selectionX, (int)selectionY, 0] = pieceSelect;
            boardState[(int)selectionX, (int)selectionY, 1] = color;
        }
    }
    public void showName()
    {
        if (pieceSelect == 1)
            showPiece.text = "King";
        else if (pieceSelect == 2)
            showPiece.text = "Pawn";
        else if (pieceSelect == 3)
            showPiece.text = "Minion";
        else if (pieceSelect == 4)
            showPiece.text = "Rook";
        else if (pieceSelect == 5)
            showPiece.text = "Bishop";
        else if (pieceSelect == 6)
            showPiece.text = "Kinght";
        else if (pieceSelect == 7)
            showPiece.text = "Queen";
        else if (pieceSelect == 8)
            showPiece.text = "Assassin";
        else if (pieceSelect == 9)
            showPiece.text = "Beserker";


    }

    int pieceValue() //returns piece value
    {
        if (pieceSelect == 1 && kingUsed == 0)
            return 0;
        else if (pieceSelect == 1 && kingUsed == 1)
            return 70;
        else if (pieceSelect == 2)
            return 1;
        else if (pieceSelect == 3)
            return 1;
        else if (pieceSelect == 4)
            return 5;
        else if (pieceSelect == 5)
            return 3;
        else if (pieceSelect == 6)
            return 3;
        else if (pieceSelect == 7 && threeUsed < 2)
            return 7;
        else if (pieceSelect == 7 && threeUsed >= 2)
            return 50;
        else if (pieceSelect == 8 && threeUsed < 2)
            return 9;
        else if (pieceSelect == 8 && threeUsed >= 2)
            return 50;
        else if (pieceSelect == 9)
            return 4;
        else
            return 0;
    }
    void threeCounter()// keeps count of how many  tier three you have
    {

        if ((pieceSelect == 7) && (2 - threeUsed > 0))
            threeUsed += 1;

        else if ((pieceSelect == 8) && (2 - threeUsed > 0))
            threeUsed += 1;

        else if ((pieceSelect == 1) && (kingUsed == 0))
            kingUsed++; 


    }

    bool row()
    {
        if (color == 0)
        {
            if (selectionY == 2)
            {
                if (pieceSelect == 2)
                    return true;
                else if (pieceSelect == 3)
                    return true;
                else
                    return false;
            }

            else if (selectionY == 1)
            {
                if (pieceSelect == 1)
                    return false;
                else
                    return true;
            }
            else if (selectionY == 0)
            {
                if (pieceSelect == 2)
                    return false;
                else if (pieceSelect == 3)
                    return false;
                else
                    return true;
            }
            else return false;
        }
        if (color == 1)
        {
            if (selectionY == 7)
            {
                if (pieceSelect == 2)
                    return true;
                else if (pieceSelect == 3)
                    return true;
                else
                    return false;
            }

            else if (selectionY == 8)
            {
                if (pieceSelect == 1)
                    return false;
                else
                    return true;
            }
            else if (selectionY == 9)
            {
                if (pieceSelect == 2)
                    return false;
                else if (pieceSelect == 3)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        else
            return false;
    }
}
