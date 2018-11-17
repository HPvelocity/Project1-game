using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] Prefap_PreBuild;
    public float Spawn_Delay;

    private int Screen_Height;
    private int Screen_Width;

    bool Spawn_Stop = false;

	// Use this for initialization
	void Start () {
        Screen_Height = Screen.height;
        Screen_Width = Screen.width;


        Spawn_Start();
    }  

    void Spawn_Enemy()
    {
        int random_Position_x = Random.Range(0,Screen_Width);
        int random_Prefab = Random.Range(0,Prefap_PreBuild.Length);

        //Vector3 prefab_Position = Prefap_PreBuild[random_Prefab].transform.position;
        Vector3 prefab_Position = new Vector3();
        prefab_Position.x = random_Position_x;
        prefab_Position.y = Screen_Height - 200;

        Vector3 prefab_EndPosition = Camera.main.ScreenToWorldPoint(prefab_Position);
        prefab_EndPosition.z = 0;
        Instantiate(Prefap_PreBuild[random_Prefab],prefab_EndPosition,Quaternion.identity);

    }

    void Spawn_Start()
    {
        if (!Spawn_Stop)
        {
            InvokeRepeating("Spawn_Enemy",1,Spawn_Delay);
        }
    }
}
