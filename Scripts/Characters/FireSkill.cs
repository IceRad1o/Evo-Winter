using UnityEngine;
using System.Collections;

public class FireSkill : MonoBehaviour {

    public GameObject fire;


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
    //圈
    IEnumerator IEnumFire0()
    {
        int count = 6;
        int angle = 360 / count;
        float offset = 1.0f;
        while(count>0)
        {
            yield return new WaitForSeconds(0.02f);
            float x =Mathf.Cos( count * angle / 2*3.14f);
            float y = Mathf.Sin(count * angle / 2*3.14f);
            Instantiate(fire, new Vector3(transform.position.x + x* offset* GetComponent<Character>().FaceDirection,transform.position.y+y/2*offset,transform.position.z+y/2*offset), Quaternion.identity);
            count--;
        }
       
    }
    //直线
    IEnumerator IEnumFire1()
    {
        int count = 30;
        while (count > 0)
        {
            yield return new WaitForSeconds(0.02f);
            Instantiate(fire, new Vector3(transform.position.x + (31 - count) * 0.7F * GetComponent<Character>().FaceDirection, transform.position.y, transform.position.z), Quaternion.identity);
            count--;
        }

    }

    IEnumerator IEnumFire2()
    {
        int count = 30;
        while (count > 0)
        {
            yield return new WaitForSeconds(0.02f);
            Instantiate(fire, new Vector3(transform.position.x + (31 - count) * 0.7F * GetComponent<Character>().FaceDirection, transform.position.y, transform.position.z), Quaternion.identity);
            count--;
        }

    }

    IEnumerator IEnumFire3()
    {
        int count = 30;
        while (count > 0)
        {
            yield return new WaitForSeconds(0.02f);
            Instantiate(fire, new Vector3(transform.position.x + (31 - count) * 0.7F * GetComponent<Character>().FaceDirection, transform.position.y, transform.position.z), Quaternion.identity);
            count--;
        }

    }



 
}
