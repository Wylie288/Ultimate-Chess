using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {
    public static bool load = false;
    public static int styleSelect;
    public Slider select;
    public GameObject loadButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        load = true;
        loadButton = GameObject.FindGameObjectWithTag("Start");

        Debug.Log("Clicked");
        styleSelect = (int)loadButton.GetComponent<LoadLevel>().select.value;
        SceneManager.LoadScene("Main");
    }
}
