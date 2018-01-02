using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour {
    public float Bomb = 1;
    public float Fire = 1;
    public float Speed = 1;
    public float maxfire = 10, maxbomb = 9, maxspeed = 4;

    public int Action = 0;
    public int Direction = 0;

    private GameObject Player;
    private GameObject Wall;
    public GameObject Bombprefeb;

    // Animators
    public Animator Anim;

    // Use this for initialization
    void Start () {
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * Speed;
        // Down
        if (Input.GetKey("s") || Action == 1)
        {
            Action = 1;
            Anim.SetInteger("inputA", Action);

        }
        // Right
        if (Input.GetKey("d") || Action == 2)
        {
            Action = 2;
            Anim.SetInteger("inputA", Action);
        }
        if (Input.GetKey("a") || Action == 3)
        {
            Action = 3;
            Anim.SetInteger("inputA", Action);
        }
        //Death
        if (Action == 9)
        {
            Action = 9;
            Anim.SetInteger("inputA", Action);
        }
        // Idle
        if (Action == 0)
        {
            Action = 0;
            Anim.SetInteger("inputA", Action);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (Input.GetKeyDown("space"))
            {
                Instantiate(Bombprefeb, this.gameObject.transform.position, Quaternion.identity);
            }
            //= new Vector3(other.transform.position.x, other.transform.position.y, 0f)
    }

}
