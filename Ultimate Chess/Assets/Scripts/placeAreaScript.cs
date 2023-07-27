using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeAreaScript : MonoBehaviour {
    public Sprite blackSprite;

    public void toBlack() {
        gameObject.GetComponent<SpriteRenderer>().sprite = blackSprite;
    }
}
