using UnityEngine;
using System.Collections;

public class FireSkill : MonoBehaviour {

    public GameObject fire;
    public GameObject fireWall;

    void Use(int type)
    {
        if(type==0)
            StartCoroutine(IEnumFire0());
        else if(type==1)
            StartCoroutine(IEnumFire1());
        else if (type == 2)
            StartCoroutine(IEnumFire2());
        else if (type == 3)
            StartCoroutine(IEnumFire3());
    }
    //火圈
    IEnumerator IEnumFire0()
    {
        int count = 6;
        int angle = 360 / count;
        float offset = 1.0f;
        Vector3 pos = transform.position;
        while(count>0)
        {
            yield return new WaitForSeconds(0.02f);
            float x = Mathf.Cos(3.14f * count * angle / 180);
            float y = Mathf.Sin(3.14f * count * angle / 180);
            //Debug.Log("x:" + 3.14f * count * angle / 180);
            Instantiate(fire, new Vector3(pos.x + x* offset* GetComponent<Character>().FaceDirection,pos.y+y/2*offset,pos.z+y/2*offset), Quaternion.identity);
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
            Instantiate(fire, new Vector3(pos.x + x * offset * GetComponent<Character>().FaceDirection, pos.y + y / 2 * offset, pos.z + y / 2 * offset), Quaternion.identity);
            count--;
        }
       
    }
    //火焰线
    IEnumerator IEnumFire1()
    {
        int count = 30;
        Vector3 pos = transform.position;
        while (count > 0)
        {
            yield return new WaitForSeconds(0.02f);
            Instantiate(fire, new Vector3(pos.x + (31 - count) * 0.7F * GetComponent<Character>().FaceDirection, pos.y, pos.z), Quaternion.identity);
            count--;
        }

    }
    //火墙
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
        int dir = GetComponent<Character>().FaceDirection;
        GameObject fw = Instantiate(fireWall, new Vector3(transform.position.x + 1.5f * dir, -2f, transform.position.z), Quaternion.identity) as GameObject;
        fw.GetComponent<MoveBy>().deltaPosition = new Vector3(3*dir, 0, 0);
       //Instantiate(fireWall, new Vector3(transform.position.x - 1.5f * GetComponent<Character>().FaceDirection, transform.position.y, transform.position.z), Quaternion.identity);

    }

    IEnumerator IEnumFire3()
    {
        int count = 20;
        int dir = GetComponent<Character>().FaceDirection;
        while (count > 0)
        {
            yield return new WaitForSeconds(0.02f);

            GameObject fw = Instantiate(fireWall, new Vector3(transform.position.x + ((20 - count) * 0.1f * Random.value + 1.5f) * dir, -2f, transform.position.z), Quaternion.identity) as GameObject;
            fw.GetComponent<MoveBy>().deltaPosition = new Vector3((0.5f +Random.value/2)*3* dir, 0, 0);
            count--;
        }

    }



 
}
