using UnityEngine;
using System.Collections;

public class DamageUp : BuffTiming {

    GameObject prefabInstance, prefabInstance1;

    int dHealth;
    bool isTrigger = false;

    /// <summary>
    /// </summary>
    /// <param name="ID"></param>
    public override void Create(int ID, string spTag = "")
    {
        int[] part = { 2, 2, 3 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);

        SpecialTag = spTag;
        BuffDuration = idPart[2];

        //Debug.Log("shield");
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
        //MissingReferenceException: The object of type 'DamageUp' has been destroyed but you are still trying to access it.
        this.gameObject.GetComponent<Character>().Hp -= dHealth;

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
            dHealth = int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 0)) - int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 1));
            isTrigger = !isTrigger;
            if (isTrigger)
                Trigger();
        }
    }

    void Start()
    {
        this.gameObject.GetComponent<Character>().AddObserver(this);
        StartCoroutine(delay(BuffDuration, 0, 0.5f));
    }
}
