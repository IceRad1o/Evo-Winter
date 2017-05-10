using UnityEngine;
using System.Collections;

public class BuffPoison : BuffTiming
{

    GameObject prefabInstance;

    /// <summary>
    /// ××（F）××(E)×××(B)01(02)11
    /// 改变属性的状态buff，01（加）02（减）(E)确定属性，(F)表示数
    /// (B) 持续时间，（C）循环类型 (D)为时间
    /// </summary>
    /// <param name="ID"></param>
    public override void Create(int ID, string spTag = "")
    {
        int[] part = { 2, 2, 3 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

        BuffDuration = idPart[2];

    }


    public override void Trigger()
    {
        if ((int)Random.value % 100 < 50)
            this.gameObject.GetComponent<Character>().Hp--;
       
    }

    public override void DestroyBuff()
    {
        this.gameObject.GetComponent<Character>().RemoveObserver(this);
        Debug.Log("Destroy");
        Destroy(prefabInstance);
        base.DestroyBuff();
    }

    void Start()
    {

        StartCoroutine(delay(BuffDuration, 0, 0.5f));
        this.gameObject.GetComponent<Character>().AddObserver(this);

        GameObject pfb = Resources.Load("Buffs/Poison") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.transform;
        prefabInstance.transform.localScale = new Vector3(1, 1, 1);
    }

    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "AttackStart") 
        {
            Debug.Log("Trigger");
            Trigger();
        }
    }


}
