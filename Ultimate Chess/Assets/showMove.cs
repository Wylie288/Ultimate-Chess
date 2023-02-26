using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showMove : MonoBehaviour {
    public List<Sprite> spriteList;
    public int pieceID;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pieceID = GameObject.FindWithTag("Grid").GetComponent<BoardManager>().pieceSelect - 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[pieceID] as Sprite;
        
    }
}
