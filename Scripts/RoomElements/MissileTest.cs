using UnityEngine;
using System.Collections;

public class MissileTest : MonoBehaviour {

    public int choice = 0;
    public float distance = 1;
    public int flyPath = 1;
    public int penetrating = 0;
    private int direction = 0;

    public GameObject[] missile;

	void Start () {
	
	}
	

	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            flyPath = flyPath % 4 + 1;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            choice = (choice + 1) % 2;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            distance = distance % 5 + 1;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            penetrating = (penetrating + 1) % 2;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
        }



        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject missileInstance = Instantiate(missile[choice], Player.Instance.Character.transform.position, Quaternion.identity) as GameObject;

            //Debug.Log("Missile飞行路径:" +  flyPath);
            //missileInstance.GetComponent<Missiles>().InitMissiles(distance*2 + 0.5f, 5f, penetrating, direction, 1, flyPath);
            missileInstance.GetComponent<Missiles>().Fly();
        }

	}




}
