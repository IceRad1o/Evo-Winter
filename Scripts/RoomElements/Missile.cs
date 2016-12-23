using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public float flySpeed;
    public int number;
    public int damage;
    public bool penetrating;
    public float flyDistance;
    public float bombRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //飞行速度
    void SetFlySpeed(float speed)
    {
        flySpeed = speed;
    }
    float GetFlySpeed()
    {
        return flySpeed;
    }
    void ChangeFlySpeed(float speed)
    {
        flySpeed += speed;
    }
    //发射物数量
    void SetNumber(float num)
    {
        number = num;
    }
    float GetNumber()
    {
        return number;
    }
    void ChangeNumber(float num)
    {
        number+=num;
    }
    //伤害值
    void SetDamage(int dam)
    {
        damage = dam;
    }
    float GetDamage()
    {
        return damage;
    }
    void ChangeDamage(int dam)
    {
        damage+=dam;
    }
}
