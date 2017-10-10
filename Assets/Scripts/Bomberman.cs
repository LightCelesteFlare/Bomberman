using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour {
    public int Bomb;
    public int Fire;
    public int Speed;
    public int maxfire = 10, maxbomb = 9, maxspeed = 4;

    bool facingRight = true;
    bool facingDown = true;

    private GameObject Player;
    private GameObject Wall;
	// Use this for initialization
	void Start () {
        Speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * Speed;
    }
}
