using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// <para>Brief 负责由主场景到冒险场景的切换</para>
/// <para>Author YYF</para>
/// <para>Time 17.3.19</para>
/// </summary>
public class StartAdventrue : MonoBehaviour {

    /// <summary>
    /// 是否开始新游戏
    /// </summary>
    public int isNew;

    /// <summary>
    /// 选择模式
    /// </summary>
    public int mode;

    /// <summary>
    /// 是否有存档
    /// </summary>
    int canLoad;

    public AudioClip clickSound;
    public GameObject modeInDevelopingDialog;
    public GameObject dark;
	void Start () {
        Button btn = this.GetComponent<Button>();
        canLoad = PlayerPrefs.GetInt("canLoad", 0);

        if (mode == 0)
        {
            btn.onClick.AddListener(OnStartAdventrue);
            if (canLoad == 0 )
            {
                if (tag == "ContinueButton")
                    gameObject.SetActive(false);
                else
                    gameObject.transform.localPosition = new Vector3(0, -68, 0);
            }
                
        }
        else if (mode == 1)
            btn.onClick.AddListener(OnStartBook);
        else if (mode == 2)
            btn.onClick.AddListener(OnStartAward);
   


	}
	
    /// <summary>
    /// 开始冒险,切换至冒险场景
    /// </summary>
    void OnStartAdventrue()
    {
        SoundManager.Instance.PlaySoundEffect(clickSound);
        PlayerPrefs.SetInt("isNew", isNew);
        PlayerPrefs.SetInt("mode", mode);
        dark.SetActive(true);
        SceneManager.LoadSceneAsync("Scenes/Formal/AdventureScene");

    }

     void OnStartBook()
    {
        SoundManager.Instance.PlaySoundEffect(clickSound);
        Instantiate(modeInDevelopingDialog, this.transform.parent, false);
    }

     void OnStartAward()
     {
         SoundManager.Instance.PlaySoundEffect(clickSound);
         Instantiate(modeInDevelopingDialog, this.transform.parent,false);
     }

}
