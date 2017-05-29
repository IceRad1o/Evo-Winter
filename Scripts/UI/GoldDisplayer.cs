using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldDisplayer : ExUnitySingleton<GoldDisplayer> {

    public GameObject valueObj;

    public GameObject coin;

    public enum SetType
    {
        Immediate,
        AfterAnimation
    }


    public void SetGlod(int value=1,SetType type=SetType.Immediate)
    {
        switch (type)
        {
            case SetType.Immediate:
                SetGoldValue(value);
                break;
            case SetType.AfterAnimation:
                StartCoroutine(DelaySetGold(value));
                break;
            default:
                break;
        }

             //valueObj.GetComponent<Text>().text = value.ToString();
        
    }

    IEnumerator DelaySetGold(int value)
    {
        yield return new WaitForSeconds(0.5f);
        SetGoldValue(value);
    }

    public void TransGoldToBar(Vector3 position)
    {
        Vector3 pos= CameraController.Instance.GetComponent<Camera>().WorldToScreenPoint(position);
        UtilManager.Instantiate(coin, pos).transform.SetParent(UIManager.Instance.transform);
    }


    void SetGoldValue(int value)
    {
        valueObj.GetComponent<Text>().text = value.ToString();
        gameObject.AddComponent<ScaleTo>().Init(0.2f, new Vector4(0.8f, 0.8f, 0, 0), true, false, true);
    }

}
