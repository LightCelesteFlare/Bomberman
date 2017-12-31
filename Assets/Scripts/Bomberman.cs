using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour {
    public float Bomb;
    public float Fire;
    public float Speed;
    public float maxfire = 10, maxbomb = 9, maxspeed = 4;

    bool facingRight = true;
    bool facingDown = true;

    private GameObject Player;
    private GameObject Wall;
    public GameObject Bombprefeb;

    // Use this for initialization
    void Start () {
        Speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * Speed;

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
