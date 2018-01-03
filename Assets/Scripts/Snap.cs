using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Snap : MonoBehaviour {

    public float grid = 0.5f;

    float x = 0f, y = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (grid > 0f)
        {
            float RGrid = 0.25f / grid; // reciprocalGrid

            x = Mathf.Round(transform.position.x * RGrid) / RGrid;
            y = Mathf.Round(transform.position.y * RGrid) / RGrid;

            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
