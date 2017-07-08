using UnityEngine;
using System.Collections;

public class ShowHealth : ExSubject {

    void Start()
    {
        GetComponent<Character>().AddObserver(this);
    }

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if (str[0] == "HealthChanged")
            Debug.Log("Test Gnome Health Left:" + GetComponent<Character>().Hp);


    }
}
