using UnityEngine;
using System.Collections;

public class BuffInvincible : BuffTiming{

    GameObject prefabInstance;

    /// <summary>
    /// ××（F）××(E)×××(B)01(02)11
    /// 改变属性的状态buff，01（加）02（减）(E)确定属性，(F)表示数
    /// (B) 持续时间，（C）循环类型 (D)为时间
    /// </summary>
    /// <param name="ID"></param>
    public override void Create(int ID, string spTag = "")
    {
        int[] part = { 2, 2, 3};
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

        BuffDuration = idPart[2];

    }


    public override void Trigger()
    {
        Player.Instance.Character.Invincible = 1;

        GameObject pfb = Resources.Load("Buffs/Invincible") as GameObject;
        Vector3 s = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = s;
        prefabInstance.transform.parent = this.gameObject.transform;
    }

    public override void DestroyBuff()
    {
        Player.Instance.Character.Invincible = 0;
        Destroy(prefabInstance);
        base.DestroyBuff();
    }

    void Start()
    {
        Trigger();       
        StartCoroutine(delay(BuffDuration, 0,0.5f));
    }
}
