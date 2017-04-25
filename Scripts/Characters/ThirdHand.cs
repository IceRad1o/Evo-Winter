using UnityEngine;
using System.Collections;
/// <summary>
/// 技能:第三只手
/// </summary>
public class ThirdHand : MonoBehaviour {

    public GameObject thirdHand;
    public GameObject thirdHandChain;
    public GameObject thirdHandChaw;
    int direction;
    bool isBack = false;
	// Use this for initialization
	void Start () {
	
	}


    void ShowThirdHand()
    {

        thirdHand.SetActive(true);
        thirdHandChain.transform.localScale = new Vector3(0, 1, 1);
        direction = this.GetComponent<Character>().FaceDirection;

        StartCoroutine(IEnumThirdHand());
    }


    IEnumerator IEnumThirdHand()
    {
        int count=0;
        while(true)
        {
            if (isBack)
            {
                thirdHandChain.transform.localScale = new Vector3(thirdHandChain.transform.localScale.x - 0.8f , thirdHandChain.transform.localScale.y, thirdHandChain.transform.localScale.z);
                count-=2;
             
            }
            else
            {
                if (this.GetComponent<Character>().DirectionAttempt.x * direction < 0)
                    isBack = true;
                if (Mathf.Abs(thirdHandChain.transform.localScale.x) > 9)
                    isBack = true;

                if (thirdHandChaw.GetComponent<MyHook>().isWork == true)
                    isBack = true;
                count++;
                thirdHandChain.transform.localScale = new Vector3(thirdHandChain.transform.localScale.x + 0.4f, thirdHandChain.transform.localScale.y, thirdHandChain.transform.localScale.z);
            }


            thirdHandChaw.transform.position = thirdHandChain.transform.Find("Point").transform.position;

            if (count <= 0)
            {
                thirdHand.SetActive(false);
                GetComponent<Animator>().SetTrigger("Idle");
                isBack = false;
                this.GetComponent<Character>().DirectionAttempt = GetComponent<Character>().Direction;
                this.GetComponent<Character>().CanMove = 1;
                thirdHandChaw.GetComponent<MyHook>().isWork = false;
                break;
            }
            else
                 yield return null;
        }
    

    }


}
