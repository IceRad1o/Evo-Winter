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


	void Start () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnStartAdventrue);
        canLoad=PlayerPrefs.GetInt("canLoad",0);
        if (canLoad == 0&&tag=="ContinueButton")
            gameObject.SetActive(false);
	}
	
    /// <summary>
    /// 开始冒险,切换至冒险场景
    /// </summary>
    void OnStartAdventrue()
    {
        Debug.Log(3432);
        PlayerPrefs.SetInt("isNew", isNew);
        PlayerPrefs.SetInt("mode", mode);

        SceneManager.LoadScene("Scenes/Formal/AdventureScene");

    }



}
