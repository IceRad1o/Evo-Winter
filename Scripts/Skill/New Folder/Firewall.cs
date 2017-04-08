using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Firewall : ExSubject
{
    bool recover=false;
    public List<GameObject> listEnemy = new List<GameObject>();
    public GameObject fire;
    public GameObject fireWall;

    int direction = 1;
    
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3.0f);
        listEnemy.RemoveAt(0);
    }
    /// <summary>
    /// 造成伤害
    /// </summary>
    /// <param name="ob">发生碰撞检测的物体</param>
    public void JudgeDamage(Collider ob) 
    {
        foreach (GameObject t in listEnemy)
        {
            if (t == ob.gameObject)
                return;
        }
        listEnemy.Add(ob.gameObject);
        ob.gameObject.GetComponent<Character>().Health--;
        if (!recover)
        {
            foreach(var item in CharacterManager.Instance.CharacterList.ToArray())
	        {
                if (item != null && item.tag== "Player")
                    item.GetComponent<Character>().Health++;
                recover = !recover;
	        } 
        }

        StartCoroutine(delay());
    
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player") 
    //    {
    //        foreach (GameObject t in listEnemy) 
    //        {
    //            if (t == other.gameObject)
    //                return;
    //        }
    //        listEnemy.Add(other.gameObject);
    //        other.gameObject.GetComponent<Character>().Health--;

    //        StartCoroutine(delay());
    //    }

    //}

    public void Create(int type,int dir) 
    {
        if (type == 0)
            StartCoroutine(IEnumFire0());
        else if (type == 1)
            StartCoroutine(IEnumFire1());
        else if (type == 2)
            StartCoroutine(IEnumFire2());
        else if (type == 3)
            StartCoroutine(IEnumFire3());

        direction = dir;

    }


    void Start() 
    {
    }

    /// <summary>
    /// 火圈
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumFire0()
    {
        int count = 6;
        int angle = 360 / count;
        float offset = 1.0f;
        Vector3 pos = transform.position;
        while (count > 0)
        {
            yield return new WaitForSeconds(0.02f);
            float x = Mathf.Cos(3.14f * count * angle / 180);
            float y = Mathf.Sin(3.14f * count * angle / 180);
            //Debug.Log("x:" + 3.14f * count * angle / 180);
            var s = Instantiate(fire, new Vector3(pos.x + x * offset * direction, pos.y + y / 2 * offset, pos.z + y / 2 * offset), Quaternion.identity) as GameObject;
            s.AddComponent<Fire>().Create(this.gameObject);
            count--;
        }
        count = 18;
        angle = 360 / count;
        offset = 2.0f;
        while (count > 0)
        {
            yield return new WaitForSeconds(0.02f);
            float x = Mathf.Cos(3.14f * count * angle / 180);
            float y = Mathf.Sin(3.14f * count * angle / 180);
            //Debug.Log("x:" + 3.14f * count * angle / 180);
            var s = Instantiate(fire, new Vector3(pos.x + x * offset * direction, pos.y + y / 2 * offset, pos.z + y / 2 * offset), Quaternion.identity) as GameObject;
            s.AddComponent<Fire>().Create(this.gameObject);
            count--;
        }

    }
    /// <summary>
    /// 火焰直线
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumFire1()
    {
        int count = 30;
        Vector3 pos = transform.position;
        while (count > 0)
        {
            yield return new WaitForSeconds(0.02f);
            var s = Instantiate(fire, new Vector3(pos.x + (31 - count) * 0.7F * direction, pos.y, pos.z), Quaternion.identity) as GameObject;
            s.AddComponent<Fire>().Create(this.gameObject);
            count--;
        }

    }
    /// <summary>
    /// 伪火墙
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumFire2()
    {
        //int count = 30;
        //while (count > 0)
        //{
        //    yield return new WaitForSeconds(0.02f);
        //    Instantiate(fire, new Vector3(transform.position.x + (31 - count) * 0.7F * GetComponent<Character>().FaceDirection, transform.position.y, transform.position.z), Quaternion.identity);
        //    count--;
        //}
        yield return new WaitForSeconds(0.02f);
        GameObject fw = Instantiate(fireWall, new Vector3(transform.position.x + 1.5f * direction, -2f, transform.position.z), Quaternion.identity) as GameObject;
        fw.GetComponent<MoveBy>().deltaPosition = new Vector3(3 * direction, 0, 0);
        fw.AddComponent<Fire>().Create(this.gameObject);
        //Instantiate(fireWall, new Vector3(transform.position.x - 1.5f * GetComponent<Character>().FaceDirection, transform.position.y, transform.position.z), Quaternion.identity);

    }
    /// <summary>
    /// 一群伪火墙
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumFire3()
    {
        int count = 20;
        while (count > 0)
        {
            yield return new WaitForSeconds(0.02f);

            GameObject fw = Instantiate(fireWall, new Vector3(transform.position.x + ((20 - count) * 0.1f * Random.value + 1.5f) * direction, -2f, transform.position.z), Quaternion.identity) as GameObject;
            fw.GetComponent<MoveBy>().deltaPosition = new Vector3((0.5f + Random.value / 2) * 3 * direction, 0, 0);
            fw.AddComponent<Fire>().Create(this.gameObject);
            count--;
        }

    }
}
