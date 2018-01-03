using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Bomb : MonoBehaviour {

    public GameObject explosionPrefab;
    public GameObject Bombprefeb;
    public float explodeDelay = 5f;
    public bool exploded = false;
    [SerializeField]
    private float explosionDuration = 1f;

    private int explosionRange;

    private void CreateExplosions(Vector2 direction)
    {
        ContactFilter2D contactFilter = new ContactFilter2D();

        Vector2 explosionDimensions = explosionPrefab.GetComponent<SpriteRenderer>().bounds.size;
        Vector2 explosionPosition = (Vector2)this.gameObject.transform.position + (explosionDimensions.x * direction);
        for (int explosionIndex = 1; explosionIndex < explosionRange; explosionIndex++)
        {
            Collider2D[] colliders = new Collider2D[4];
            Physics2D.OverlapBox(explosionPosition, explosionDimensions, 0.0f, contactFilter, colliders);
            bool foundBlockOrWall = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider)
                {
                    foundBlockOrWall = collider.tag == "Wall" || collider.tag == "Block";
                    if (collider.tag == "Block")
                    {
                        Destroy(collider.gameObject);
                    }
                    if (foundBlockOrWall)
                    {
                        break;
                    }
                }
            }
            if (foundBlockOrWall)
            {
                break;
            }
            GameObject explosion = Instantiate(explosionPrefab, explosionPosition, Quaternion.identity) as GameObject;
            Destroy(explosion, this.explosionDuration);
            explosionPosition += (explosionDimensions.x * direction);
        }
    }

    public void Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab, this.gameObject.transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, this.explosionDuration);
        CreateExplosions(Vector2.left);
        CreateExplosions(Vector2.right);
        CreateExplosions(Vector2.up);
        CreateExplosions(Vector2.down);
        Destroy(this.gameObject);

    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.isTrigger = false;
    }

    private void Update()
    {
        Vector3 explosionPosition = Bombprefeb.transform.position;
        if (explodeDelay <= 0)
        {
            exploded = true;
        }
        explodeDelay -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Vector3 explosionPosition = Bombprefeb.transform.position;
        if (explodeDelay <= 0)
        {

                Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
                Object.Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 explosionPosition = Bombprefeb.transform.position;
        Vector3 target = other.gameObject.transform.position;

        if (exploded == true)
        {
            if (other.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Explode();
            }
        }
    }



}
