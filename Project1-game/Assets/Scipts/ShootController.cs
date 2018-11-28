using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    public GameObject shoot;
    public Transform[] ShootPoints;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Transform current in ShootPoints)
            {
                Quaternion qu = current.rotation;

                qu.z = 180;

                Instantiate(shoot, current.position, qu);
            }
        }

	}
}
