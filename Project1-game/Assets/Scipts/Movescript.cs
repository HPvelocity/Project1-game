using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movescript : MonoBehaviour {
    public float movespeed = 3f;
    float velX;
    float vely;
    bool facingright = true;
    Rigidbody2D rigbody;

	// Use this for initialization
	void Start () {
        rigbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        velX = Input.GetAxisRaw("Horizontal");
        vely = rigbody.velocity.y;
        rigbody.velocity = new Vector2(velX * movespeed,0); 
		

    }
     void LateUpdate()
    {
        Vector3 localscale = transform.localScale;
        if(velX > 0)
        {
            facingright = true;

        }else if (velX < 0)
        {
            facingright = false;

        }
        if(((facingright) && (localscale.x <0 )) || ((!facingright)&& (localscale.x > 0)))
        {
            localscale.x *= -1;

        }
        transform.localScale = localscale;
    }
}
