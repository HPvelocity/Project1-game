using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float Move_Speed = 2;

    private Rigidbody2D rig_Shot;
    Vector3 vec3;

    private void Start()
    {
        rig_Shot = this.GetComponent<Rigidbody2D>();
        Invoke("Destroy_Me", 4);
    }

    // Update is called once per frame
    void Update()
    {
        vec3 = rig_Shot.velocity;
        vec3.y -= Move_Speed * Time.deltaTime;
        this.transform.Translate(vec3);
    }


    void Destroy_Me()
    {
        Destroy(gameObject);
    }
}
