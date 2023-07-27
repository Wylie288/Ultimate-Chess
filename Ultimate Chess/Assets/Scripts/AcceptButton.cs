using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AcceptButton : MonoBehaviour
{
    public GameObject[] list;
    public GameObject[] piece;
    public GameObject[] text;
    public GameObject savebtn;
    public GameObject loadbtn;
    public GameObject mainmenubtn;
    GameObject placeArea;
    public Text turn;

    void Start()
    {
        turn.text = "Place all white pieces";
        savebtn = GameObject.FindWithTag("Save");
        loadbtn = GameObject.FindWithTag("loadbtn");
        mainmenubtn = GameObject.FindWithTag("Mainbtn");
        placeArea = GameObject.FindWithTag("placeArea");
        mainmenubtn.SetActive(true);
        savebtn.SetActive(false);
        loadbtn.SetActive(false);
    }
    void OnMouseDown()
    {
        //Player 2 build
        if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState == 1 && GameObject.FindWithTag("Grid").GetComponent<BoardManager>().kingUsed == 0) // can't start without placing king
        {
            GameObject.FindWithTag("Grid").GetComponent<BoardManager>().derp.text = "Cannot finalize without placing a king";
        }
        else if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState == 1 && GameObject.FindWithTag("Grid").GetComponent<BoardManager>().kingUsed == 1)
        {
            GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState = 2; ;
            //Active Pieces
            for (int i = 0; i < piece.Length; i++)
            {
                piece[i].SetActive(true);
            }
            //Destroy Buttons
            for (int i = 0; i < 9; i++)
            {
                Destroy(list[i]);
            }
            Destroy(GameObject.FindWithTag("Selector"));
            Destroy(GameObject.FindWithTag("canvas"));
            Destroy(GameObject.FindWithTag("placeArea"));
            savebtn.SetActive(true);
            loadbtn.SetActive(true);
            mainmenubtn.SetActive(true);
            this.gameObject.SetActive(false);
        }

        //Player 1 build
        if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState == 0 && GameObject.FindWithTag("Grid").GetComponent<BoardManager>().kingUsed == 0)
        {
            GameObject.FindWithTag("Grid").GetComponent<BoardManager>().derp.text = "Cannot finalize without placing a king";
        }
        else if (GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState == 0 && GameObject.FindWithTag("Grid").GetComponent<BoardManager>().kingUsed == 1)
        {
                turn.text = "Place all black pieces";
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().pieceSelect = 1;
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().color = 1;
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().selectionX = 5;
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().selectionY = 9;
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().points = 45;
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().kingUsed = 0;
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().threeUsed = 0;
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().derp.text = " ";
                GameObject.FindWithTag("Grid").GetComponent<BoardManager>().gameState = 1;
                placeArea.GetComponent<placeAreaScript>().toBlack();
                list = GameObject.FindGameObjectsWithTag("Button");
                for (int i = 0; i < 9; i++)
                {
                    list[i].GetComponent<PiecePicker>().color = 1;
                    list[i].GetComponent<PiecePicker>().SelectSprite();
                }
                piece = GameObject.FindGameObjectsWithTag("IndPiece");
                for (int i = 0; i < piece.Length; i++)
                {
                    piece[i].SetActive(false);
                }
                // GameObject.FindWithTag("Grid").GetComponent<BoardManager>().CreatePiece();
                GameObject.FindWithTag("Selector").transform.position = new Vector2(-303, 516);
            }
        }
    }