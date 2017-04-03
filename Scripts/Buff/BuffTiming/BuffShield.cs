using UnityEngine;
using System.Collections;

public class BuffShield : BuffTiming
{

    GameObject prefabInstance, prefabInstance1;

    int shieldHealth;

    /// <summary>
    /// ××（F）××(E)×××(B)01(02)11
    /// 改变属性的状态buff，01（加）02（减）(E)确定属性，(F)表示数
    /// (B) 持续时间，（C）循环类型 (D)为时间
    /// </summary>
    /// <param name="ID"></param>
    public override void Create(int ID, string spTag = "")
    {
        int[] part = { 2,3 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

        shieldHealth = idPart[1];

        Debug.Log("shield");
        GameObject pfb = Resources.Load("Buffs/SpeedDown") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.transform;
        prefabInstance.transform.localScale = new Vector3(1, 1, 1);

    }
    public override void Trigger()
    {
        Debug.Log("Trigger");
        shieldHealth--;
        this.GetComponent<Character>().Health++;
        if (shieldHealth == 0)
            DestroyBuff();



        GameObject pfb = Resources.Load("Buffs/AttackShield") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        prefabInstance1 = Instantiate(pfb);
        prefabInstance1.transform.position = s;
        prefabInstance1.transform.parent = this.gameObject.transform;
        prefabInstance1.transform.localScale = new Vector3(1, 1, 1);
    }

    public override void DestroyBuff()
    {
        this.gameObject.GetComponent<Character>().RemoveObserver(this);
        Destroy(prefabInstance);
        base.DestroyBuff();
    }

    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "HealthChanged" && int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 0)) - int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 1)) > 0 && UtilManager.Instance.GetFieldFormMsg(msg, 2) == "Player")
        {
            Trigger();
        }
    }

    void Start()
    {
        this.gameObject.GetComponent<Character>().AddObserver(this);
    }
}
