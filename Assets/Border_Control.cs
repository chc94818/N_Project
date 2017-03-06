using UnityEngine;
using System.Collections;

public class Border_Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
        if (col.tag == "Bullet")
        {

            Destroy(col.gameObject);
        }
    }
}
