using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Enemy : MonoBehaviour {
    private GameObject Main_Player;
    public float Move_Speed;
    public int Distance_To_Player_DownUp;
    public float Distance_To_Player_LeftRight;
    public float Move_Delay = 1;

    struct Where_Is_Player
    {
        public bool Player_Down, Player_Up, Player_Right, Player_Left;
    }
    Where_Is_Player Player_Is_There = new Where_Is_Player();

    Rigidbody2D rig_From_Enemy;

    // Use this for initialization
    void Start () {
        rig_From_Enemy = this.GetComponent<Rigidbody2D>();
        Main_Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        if (MainPlayer_Far())
        {
            if (Player_Is_There.Player_Down)
            {
                Move_Down();
            }else if (Player_Is_There.Player_Up)
            {
                Move_Up();
            }

            if (Player_Is_There.Player_Right)
            {
                Move_Right();
            }else if (Player_Is_There.Player_Left)
            {
                Move_Left();
            }
        }
	}

    private void Move_Right()
    {
        Vector3 vec3 = rig_From_Enemy.velocity;
        vec3.x = Move_Speed * Time.deltaTime;
        Transform transform = this.transform;
        transform.Translate(vec3);
    }

    private void Move_Left()
    {
        Vector3 vec3 = rig_From_Enemy.velocity;
        vec3.x -= Move_Speed * Time.deltaTime;
        Transform transform = this.transform;
        transform.Translate(vec3);
    }

    private void Move_Down()
    {
        Vector3 vec3 = rig_From_Enemy.velocity;
        vec3.y -= Move_Speed * Time.deltaTime;
        Transform transform = this.transform;
        transform.Translate(vec3);
    }

    private void Move_Up()
    {
        Vector3 vec3 = rig_From_Enemy.velocity;
        vec3.y = Move_Speed * Time.deltaTime;
        Transform transform = this.transform;
        transform.Translate(vec3);
    }

    private bool MainPlayer_Far()
    {
        bool Player_Far = false;

        if (this.transform.position.y - Distance_To_Player_DownUp >  Main_Player.transform.position.y)
        {
            Player_Is_There.Player_Down = true;
            Player_Far = true;
        }
        else
        {
            Player_Is_There.Player_Down = false;
        }
        if (this.transform.position.y < Main_Player.transform.position.y)
        {
            Player_Is_There.Player_Up = true;
            Player_Far = true;
        }
        else
        {
            Player_Is_There.Player_Up = false;
        }
        if (this.transform.position.x + Distance_To_Player_LeftRight < Main_Player.transform.position.x)
        {
            Player_Is_There.Player_Right = true;
            Player_Far = true;
        }
        else
        {
            Player_Is_There.Player_Right = false;
        }
        if (this.transform.position.x - Distance_To_Player_LeftRight > Main_Player.transform.position.x)
        {
            Player_Is_There.Player_Left = true;
            Player_Far = true;
        }
        else
        {
            Player_Is_There.Player_Left = false;
        }


        return Player_Far;
    }

}
