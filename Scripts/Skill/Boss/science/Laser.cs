using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
    /// <summary>
    /// 每次旋转改变的差值
    /// </summary>
    public float d_Value_Rotate = 10;
    /// <summary>
    /// 时间间隔
    /// </summary>
    public float interval_Rotate = 0.5f;
    /// <summary>
    /// 旋转持续时间
    /// </summary>
    public float duration_Rotate=2.0f;
    /// <summary>
    /// 伸长是每次改变的差值
    /// </summary>
    public float d_Value_Scale = 7.0f;
    /// <summary>
    /// 伸长的时间间隔
    /// </summary>
    public float interval_Scale = 0.2f;
    /// <summary>
    /// 伸长的持续时间
    /// </summary>
    public float duration_Scale = 0.6f;
    /// <summary>
    /// 伸长的方向
    /// </summary>
    int direction_Scale = -1;
    /// <summary>
    /// 销毁的延迟
    /// </summary>
    public float destroyDelay = 4.0f;
    /// <summary>
    /// 销毁时的特效
    /// </summary>
    public GameObject destroyEffect;


    IEnumerator ChangeRotate()
    {
        yield return new WaitForSeconds(interval_Rotate);
        this.transform.rotation = new Quaternion(0, 0, (this.transform.rotation.z + d_Value_Rotate) % 360, 0);
        duration_Rotate -= interval_Rotate;
        if (duration_Rotate > 0.0f)
            StartCoroutine(ChangeRotate());
        else
        {
            this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

            foreach (var item in EnemyManager.Instance.EnemyList.ToArray())
            {
                if (item != null && item.tag == "Boss")
                {
                    //-1朝左，1朝右
                    direction_Scale = item.GetComponent<Character>().FaceDirection;
                }
            }
            StartCoroutine(ChangeScale());
        }
           
    }

    IEnumerator ChangeScale()
    {
        yield return new WaitForSeconds(interval_Scale);
        this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + d_Value_Scale * direction_Scale, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        Debug.Log("localScale.y:    "+this.gameObject.transform.localScale.x);
        //this.GetComponent<BoxCollider>().center = new Vector3(this.GetComponent<BoxCollider>().center.x + d_Value_Scale * direction_Scale, this.GetComponent<BoxCollider>().center.y, this.GetComponent<BoxCollider>().center.z);
        duration_Scale -= interval_Scale;
        if (duration_Scale > 0.0f)
            StartCoroutine(ChangeScale());    
    }

    IEnumerator DestroyLaser()
    {
        yield return new WaitForSeconds(destroyDelay);
        GameObject prefabInstance = Instantiate(destroyEffect);
        prefabInstance.gameObject.transform.position = this.gameObject.transform.position;
        prefabInstance.gameObject.transform.localScale = this.gameObject.transform.localScale;
        UtilManager.Instance.CreateEffcet(prefabInstance, prefabInstance.transform.position);
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Laser Trigger   ");
            other.gameObject.GetComponent<BuffManager>().CreateDifferenceBuff(7110);
        }

    }




    // Use this for initialization
	void Start () {
        StartCoroutine(ChangeScale());
        StartCoroutine(DestroyLaser());
    }
	
}
