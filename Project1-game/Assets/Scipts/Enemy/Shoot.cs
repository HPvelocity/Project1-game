using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject Shoot_Object;
    public float Shoot_Delay;
    public GameObject Shoot_Point;

    bool Shoot_Break = false;
    bool Shoot_Delay_Finished = false;
    bool Is_Corouting_Ready = true;

    // Update is called once per frame
    void Update() {
        if (!Shoot_Delay_Finished && Is_Corouting_Ready)
        {
            Is_Corouting_Ready = false;
            StartCoroutine(Start_Delay());
        }
        if (!Shoot_Break && Shoot_Delay_Finished)
        {
            Shoot_Delay_Finished = false;
            Erzeuge_Shot();
        }

    }

    private void Erzeuge_Shot()
    {
        Vector3 vec3 = Shoot_Point.transform.position;

        //Vector3 End_Vec3 = Camera.main.ScreenToViewportPoint(vec3);
        Instantiate(Shoot_Object, vec3, Quaternion.identity);
    }

   IEnumerator Start_Delay()
    {
        yield return new WaitForSeconds(Shoot_Delay);
        Shoot_Delay_Finished = true;
        Is_Corouting_Ready = true;
    }
}
