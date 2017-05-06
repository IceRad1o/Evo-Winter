using UnityEngine;
using System.Collections;

public class ChangeScale : MonoBehaviour {
    
    private bool isDestroy=false;
    public float intervalTime = 0.1f;
    public float proportion = 0.2f;
    public float duration = 0.3f;
    public float stopTime = 1.4f;

    void Start()
    {
        StartCoroutine(Change());
    }
    IEnumerator Change()
    {
        yield return new WaitForSeconds(intervalTime);
        duration -= intervalTime;
        Vector3 s=new Vector3(this.gameObject.transform.lossyScale.x+proportion,this.gameObject.transform.lossyScale.y+proportion,this.gameObject.transform.lossyScale.z+proportion);
        this.gameObject.transform.localScale = s;
        if (duration <= 0.0f)
        {
            StartCoroutine(delay());            
        }
        else
            StartCoroutine(Change());
    }
    IEnumerator delay()
    {
        if (isDestroy)
        {
           
            Destroy(gameObject);
        }
        else
        {
            yield return new WaitForSeconds(stopTime);
            duration = (this.gameObject.transform.localScale.x / proportion) * intervalTime /2;
            proportion = -proportion *2;
            isDestroy = true;
            StartCoroutine(Change());            
        }

        
    }
}
