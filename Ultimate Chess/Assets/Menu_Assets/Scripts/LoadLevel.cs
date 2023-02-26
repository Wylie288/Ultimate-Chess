using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LoadLevel : MonoBehaviour {
    public static int styleSelect;
    public Slider select;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        styleSelect = (int)gameObject.GetComponent<LoadLevel>().select.value;

        Debug.Log("Clicked");
        SceneManager.LoadScene("Main");
        
       
    }
}
