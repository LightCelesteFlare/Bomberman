using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomberman : MonoBehaviour {
    public float Bomb = 1;
    public float Fire = 1;
    public float Speed = 1;
    public float maxfire = 10, maxbomb = 9, maxspeed = 4;

    public float Action = 0f;
    public float ActionUD = 0f;
    public int Direction = 0;

    private Transform Player;
    private GameObject Wall;
    public GameObject Bombprefeb;
    public GameObject explosion;
    // Animators
    public SpriteRenderer mySpriteRend;
    public Animator Anim;

    // Use this for initialization
    void Start () {
        Anim = GetComponent<Animator>();
	}

    private void Awake()
    {
        mySpriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * Speed;
        
        // Down
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            Action = 1f;
            ActionUD = 0.5f;
            Anim.SetFloat("inputA", Action);
            Anim.SetFloat("inputB", ActionUD);
            Anim.SetInteger("inputD", Direction);
            Direction = 0;
        }
        // Right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            Action = 1f;
            ActionUD = 1.5f;
            Anim.SetFloat("inputA", Action);
            Anim.SetFloat("inputB", ActionUD);
            Anim.SetInteger("inputD", Direction);
            mySpriteRend.flipX = false;
            Direction = 1;
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            Action = 1f;
            ActionUD = 2f;
            Anim.SetFloat("inputA", Action);
            Anim.SetFloat("inputB", ActionUD);
            Anim.SetInteger("inputD", Direction);
            mySpriteRend.flipX = true;
            Direction = 1;
        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            Action = 1f;
            ActionUD = 1f;
            Anim.SetFloat("inputA", Action);
            Anim.SetFloat("inputB", ActionUD);
            Anim.SetInteger("inputD", Direction);
            Direction = 3;
        }
        // IdleUp
        if (Direction == 3 && Action != 1)
        {
            Action = 0f;
            ActionUD = 0.25f;

            Anim.SetFloat("inputB", ActionUD);
        }
        // Idledown
        if (Direction == 0 && Action != 1)
        {
            Action = 0f;
            ActionUD = 0.10f;

            Anim.SetFloat("inputB", ActionUD);
        }
        if (Direction == 1 && Action != 1)
        {
            Action = 0f;
            ActionUD = 3f;

            Anim.SetFloat("inputB", ActionUD);
        }
        else
        {
            Action = 0;
        }
        //Death
        //if (Action == 9)
        //{
        //    Action = 9;
        //    Anim.SetFloat("inputA", Action);
        //}
        // Bombs
        if (Input.GetKeyDown("space"))
        {

                Instantiate(Bombprefeb, this.gameObject.transform.position, Quaternion.identity);                  
        }

        }
    
}
