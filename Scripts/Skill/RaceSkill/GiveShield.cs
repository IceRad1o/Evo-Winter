using UnityEngine;
using System.Collections;

public class GiveShield : Skill {

   

    public override void Create(int ID)
    {
        base.Create(ID);
        this.gameObject.GetComponent<Character>().AddObserver(this);
    }

    public override void Trigger()
    {
        if ((int)(Random.value*(100+this.GetComponent<Character>().Luck*10))>50)
            this.GetComponent<BuffManager>().CreateDifferenceBuff(3300);
    }

    protected override void skillDestory()
    {
        this.gameObject.GetComponent<Character>().RemoveObserver(this);
        base.skillDestory();
    }

    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "HealthChanged" && int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 0)) - int.Parse(UtilManager.Instance.GetFieldFormMsg(msg, 1)) > 0 && UtilManager.Instance.GetFieldFormMsg(msg, 2) == "Player")
        {
            Trigger();
        }
    }

}
