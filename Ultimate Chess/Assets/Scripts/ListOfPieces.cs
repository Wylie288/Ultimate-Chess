using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfPieces : MonoBehaviour
{
    
    public GameObject[] allPieces;
    public GameObject[] currentPieces;
    public List<GameObject> list;
    BoardManager manager;
    GameObject[] delete;
    GameObject m;
    GameObject s;
    // Use this for initialization
    void Start () {
        m = GameObject.FindGameObjectWithTag("Mainbtn");
        s = GameObject.FindGameObjectWithTag("Save");
        allPieces = new GameObject[60];
        delete = GameObject.FindGameObjectsWithTag("Button");
        manager = GameObject.FindGameObjectWithTag("Grid").GetComponent<BoardManager>();
    }
	
	// Update is called once per frame
	void Update () {
        list = GameObject.FindWithTag("Grid").GetComponent<BoardManager>().objectList;
        currentPieces = GameObject.FindGameObjectsWithTag("IndPiece");
        if (LoadGame.load == true)
        {
            Debug.Log("clicked");
            //LoadPosition();
            LoadGame.load = false;
            LoadPosition();

        }
        //list = GameObject.FindWithTag("Grid").GetComponent<BoardManager>().objectList;
        //currentPieces = GameObject.FindGameObjectsWithTag("IndPiece");
    }
    public void OnMouseDown()
    {
        PlayerPrefs.DeleteAll();
        allPieces = GameObject.FindGameObjectsWithTag("IndPiece");
        
        for (int i = 0; i < allPieces.Length; i++)
        {
            Piece pieceObject = allPieces[i].GetComponent<Piece>();
            int color = 0;
            int id = 0;
            color = pieceObject.color;
            id = pieceObject.pieceID;
            PlayerPrefs.SetFloat("Piece" + i + "X", allPieces[i].transform.position.x);
            PlayerPrefs.SetFloat("Piece" + i + "Y", allPieces[i].transform.position.y);
            PlayerPrefs.SetString("Piece" + i + "Name", allPieces[i].name);
            PlayerPrefs.SetInt("Piece" + i + "Color", color);
            PlayerPrefs.SetInt("Piece" + i + "PieceID", id);
            PlayerPrefs.SetInt("GameState", manager.gameState);
            PlayerPrefs.SetInt("Piece" + i + "Sprite", LoadLevel.styleSelect);
        }
    }
    public void LoadPosition()
    {
        Destroy(GameObject.FindWithTag("Selector"));
        Destroy(GameObject.FindWithTag("canvas"));
        GameObject f = GameObject.FindGameObjectWithTag("Finalize");
        f.SetActive(false);
        
        m.SetActive(true);
        
        s.SetActive(true);
        for(int i = 0; i < delete.Length; i++)
        {
            Destroy(delete[i]);
        }
        manager.gameState = PlayerPrefs.GetInt("GameState");
        for (int i = 0; i < currentPieces.Length; i++)
        {
            Destroy(currentPieces[i]);
        }
        for (int i = 0; i <= 9; i++)
            for (int j = 0; j <= 9; j++)
            {
                manager.boardState[i, j, 0] = 0;
                manager.boardState[i, j, 1] = 0;
            }
        for (int i = 0; i < allPieces.Length; i++)
        {
            if (PlayerPrefs.HasKey("Piece" + i + "PieceID"))
            {
                float x = PlayerPrefs.GetFloat("Piece" + i + "X");
                float y = PlayerPrefs.GetFloat("Piece" + i + "Y");
                int color = PlayerPrefs.GetInt("Piece" + i + "Color");
                int style = PlayerPrefs.GetInt("Piece" + i + "Sprite");
                //string name = PlayerPrefs.GetString("Piece" + i + "Name");
                int id = PlayerPrefs.GetInt("Piece" + i + "PieceID");
                //Debug.Log(PlayerPrefs.GetInt("GameState"));
                LoadLevel.styleSelect = style;
                GameObject instance = (GameObject)Instantiate(list[id - 1], new Vector2(x, y), Quaternion.identity);
                instance.gameObject.GetComponent<Piece>().pieceID = id;
                instance.gameObject.GetComponent<Piece>().color = color;
                instance.gameObject.GetComponent<Piece>().x = (int)x / 58;
                instance.gameObject.GetComponent<Piece>().y = (int)y / 58;
                manager.boardState[(int)x / 58, (int)y / 58, 0] = id;
                manager.boardState[(int)x / 58, (int)y / 58, 1] = color;
                

            }
        }
        Debug.Log(PlayerPrefs.GetInt("GameState"));

    }
}
