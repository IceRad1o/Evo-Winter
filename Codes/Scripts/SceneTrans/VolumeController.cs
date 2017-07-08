using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeController : ExSubject {

    public GameObject on;
    public GameObject off;
    public AudioClip clickSound;
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnVolumeGate);


        int res = PreferenceManager.Instance.Data.IsVolumeOn;
        if (res == 1)
        {
            on.SetActive(true);
            off.SetActive(false);
     
        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
          
        }
    }



    /// <summary>
    /// 开始冒险,切换至冒险场景
    /// </summary>
    void OnVolumeGate()
    {
        int res = SoundManager.Instance.IsVolumeOn;
       if (res == 1)
       {
           SoundManager.Instance.IsVolumeOn = 0;
           on.SetActive(false);
           off.SetActive(true);
       }
       else
       {
           SoundManager.Instance.IsVolumeOn = 1;
           on.SetActive(true);
           off.SetActive(false);
       }
       SoundManager.Instance.PlaySoundEffect(clickSound);

    }
}
