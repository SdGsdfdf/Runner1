using UnityEngine;
using System.Collections;

public class destroyGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < -15)
            Destroy(gameObject);
	}
}
