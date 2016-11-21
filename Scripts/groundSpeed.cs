using UnityEngine;
using System.Collections;

public class groundSpeed : MonoBehaviour {
    public float speed;
    public float speedx2;
    public float speedx3;

    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
        //скорость х2
        speedx2 = PlayerPrefs.GetFloat("uplvlx2");
        if (speedx2 == 1.4f)
        {
            speed = 10;
        }
        //скорость х3
        speedx3 = PlayerPrefs.GetFloat("uplvlx3");
        if (speedx3 == 0.7f)
        {
            speed = 15;
        }
        transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
    }
}
