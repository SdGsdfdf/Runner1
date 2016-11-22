using UnityEngine;
using System.Collections;

public class RandomColorBox : MonoBehaviour {
    public int numberColor;
    // Use this for initialization
    void Start () {
        numberColor = Random.Range(1, 4);
        if (numberColor == 1)
        {
            GetComponent<Renderer>().material.color = Color.red;
            gameObject.tag = "Red";
        }
        if (numberColor == 2)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            gameObject.tag = "Blue";
        }
        if (numberColor == 3)
        {
            GetComponent<Renderer>().material.color = Color.green;
            gameObject.tag = "Green";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
