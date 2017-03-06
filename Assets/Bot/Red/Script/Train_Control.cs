using UnityEngine;
using System.Collections;

public class Train_Control : MonoBehaviour {
    private Rigidbody2D rigi;
    public float move_speed = 350;
    public float rot_speed = 5;
    public float jumpForce = 700;
    public bool isGround = true;
    public float ATTACK_CD = 0.4f;
    public float cd_count = 2;

    public GameObject Bullet;

    //初始化
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        cd_count += Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(-1);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Rotate(0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Move(1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Move(-1);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            Move(0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Attack();
        }

    }

    void Attack()
    {
        if (cd_count > ATTACK_CD)
        {
            cd_count = 0;
            float unit_vector = 0.4f;
            Vector3 pos = gameObject.transform.position + new Vector3(unit_vector * Mathf.Cos(rigi.rotation * Mathf.Deg2Rad), unit_vector * Mathf.Sin(rigi.rotation * Mathf.Deg2Rad), 0);
            Instantiate(Bullet, pos, gameObject.transform.rotation);
            
        }
        
    }

    void Rotate(int direction)
    {

        rigi.rotation -= direction*rot_speed;
    }

   
    void Move(int direction)
    {
        float unit_vector = direction * move_speed * Time.deltaTime;
        rigi.velocity = new Vector2(unit_vector * Mathf.Cos(rigi.rotation* Mathf.Deg2Rad), unit_vector * Mathf.Sin(rigi.rotation * Mathf.Deg2Rad));
    }
}
