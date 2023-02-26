using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour {
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
    public SaveLoad()
    {
        
    }
}
[System.Serializable]
public class SaveBlob
{
    public GameObject[] allPieces;
    public int turn;
}
