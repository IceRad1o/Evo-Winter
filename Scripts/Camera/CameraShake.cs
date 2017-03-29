using UnityEngine;  
using System.Collections;
public class CameraShake : ExUnitySingleton<CameraShake>
{
    private Vector3 vecOriginPos;
    public int shakeLevelX=5;
    public int shakeLevelY = 5;
    public float time=0.15f;
    void Start()
    {
        Player.Instance.Character.AddObserver(this);
    }
    void Shake()
    {
        StartCoroutine("IEnumShakeCamera");
    }
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Alpha1))                //当按下1时  
        {
            Shake();
        }
    }

    public override void OnNotify(string msg)
    {
        base.OnNotify(msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
       
        if (str[0] == "Shake")
        {
            time = float.Parse(str[1]);
            shakeLevelX = int.Parse(str[2]);
            shakeLevelY = int.Parse(str[3]);
            Shake();
        }
            
    }
    IEnumerator IEnumShakeCamera()
    {
        vecOriginPos = this.transform.position;   //记录初始位置  
        GetComponent<CameraController>().enabled = false;
        float count = 0;
        Vector3 vecRandom = Vector3.zero;
        while (count < time)
        {
            count += 1 * Time.smoothDeltaTime;
            print(count);
            vecRandom.x = vecOriginPos.x + Random.Range(-0.1f * shakeLevelX, 0.1f * shakeLevelX);
            vecRandom.y = vecOriginPos.y + Random.Range(-0.05f*shakeLevelY, 0.05f*shakeLevelY); ;
            vecRandom.z = vecOriginPos.z;
            transform.position = vecRandom;
            yield return 0;
        }
        transform.position = vecOriginPos;
        GetComponent<CameraController>().enabled = true;
    }
}