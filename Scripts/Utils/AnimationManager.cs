using UnityEngine;
using System.Collections;

/*AnimationManager
 *@Brief 负责管理游戏视频/动画
 *@Remark PC端支持.ogv 移动端支持.mp4
 *@Author YYF
 *@Time 16.12.23
 */
public class AnimationManager : MonoBehaviour {


    /*GetInstance
     *@Brief 获取一个AnimationManager实例 
     *@Return AnimationManager
     */
    static public AnimationManager GetInstance()
    {
        if (instance)
            return instance;
        else
        {
            instance = Instantiate(instance);
            return instance;
        }

    }

    /*PlayAnimation
     *@Brief 播放动画
     *@Param int animationID 需要播放的动画对应的ID 
     */
    public void PlayAnimation(int animationID)
    {
        GetComponent<MeshRenderer>().enabled = true;
        selAnimationID = animationID;
       
#if UNITY_IOS||UNITY_ANDROID||UNITY_WP8||UNITY_IPHONE
        string str;
        str = "Resources/Animations/" + animationID + ".mp4";
        Handheld.PlayFullScreenMovie(str, Color.black, FullScreenMovieControlMode.Hidden);  
#endif
#if UNITY_STANDALONE_WIN
        GetComponent<Renderer>().material.mainTexture = movTextures[animationID];
        movTextures[animationID].Stop();
        movTextures[animationID].loop = false;
        movTextures[animationID].Play();  
 
#endif       
    }
#if UNITY_STANDALONE_WIN
    public MovieTexture[] movTextures;  //电影纹理
#endif
    private static AnimationManager instance = null;  //单例

    private int selAnimationID; //正在播放的动画ID
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
#if UNITY_STANDALONE_WIN
        //当播放完毕使其不可见
        if (movTextures[selAnimationID].isPlaying == false&&GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
#endif
    }
}
