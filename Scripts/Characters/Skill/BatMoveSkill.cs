using UnityEngine;
using System.Collections;

public class BatMoveSkill : MonoBehaviour {


    public GameObject bat;
    GameObject instance;
    Character character;
    void Start()
    {
        character = GetComponent<Character>();
    }
    void BatComeToMe()
    {
        instance=UtilManager.Instantiate(bat, transform.position+new Vector3(character.FaceDirection,0,0));
        instance.GetComponent<Character>().Direction = character.Direction;
    }

    void MeComeToBat()
    {
        GameObject huanying = Instantiate(this.GetComponent<CharacterSkin>().bodyNode, this.transform.position, Quaternion.identity) as GameObject;
        huanying.transform.localScale = new Vector3(this.transform.localScale.x * this.GetComponent<CharacterSkin>().bodyNode.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        FadeOut fo = huanying.AddComponent<FadeOut>();
        fo.delayTime = 0.3f;
        fo.isDelay = true;
        huanying.AddComponent<AutoDestoryedObject>().destroyTime = 1.3f;

        ScaleTo st = gameObject.GetComponent<CharacterSkin>().body.AddComponent<ScaleTo>();
        st.isDelay = true;
        st.delayTime = 0.1f;
        st.destValue = new Vector4(0, 0, 0, 0);
        st.duration = 0.2f;
        st.isReverse = true;
        StartCoroutine(IEnumSkill());
    }


    void UseBatSkill()
    {
        if (instance != null)
            MeComeToBat();
        else
            BatComeToMe();

    }

    IEnumerator IEnumSkill()
    {
        yield return new WaitForSeconds(0.3f);
       if( instance!=null)
       {
           Vector3 temp = instance.transform.position;
           this.transform.position = temp;
           instance.GetComponent<RoomElement>().Destroy();
       }
     
    }

}
