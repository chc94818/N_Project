using UnityEngine;
using System.Collections;

public class Bullet_Control : MonoBehaviour {
    private Rigidbody2D rigi;
    public float move_speed = 400;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Move(1);
    }

    void Move(int direction)
    {
        float unit_vector = direction * move_speed * Time.deltaTime;
        rigi.velocity = new Vector2(unit_vector * Mathf.Cos(rigi.rotation * Mathf.Deg2Rad), unit_vector * Mathf.Sin(rigi.rotation * Mathf.Deg2Rad));
    }
}
