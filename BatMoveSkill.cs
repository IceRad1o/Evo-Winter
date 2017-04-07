using UnityEngine;
using System.Collections;

public class BatMoveSkill : MonoBehaviour {

	// Use this for initialization
    void UseBatMoveSkill()
    {
        GameObject huanying = Instantiate(this.GetComponent<CharacterSkin>().BodyNode, this.transform.position, Quaternion.identity) as GameObject;
        huanying.transform.localScale = new Vector3(this.transform.localScale.x * this.GetComponent<CharacterSkin>().BodyNode.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        FadeOut fo=huanying.AddComponent<FadeOut>();
        fo.delayTime = 0.3f;
        fo.isDelay = true;
        huanying.AddComponent<AutoDestoryedObject>().destroyTime = 1.3f;

        
        ScaleTo st=gameObject.GetComponent<CharacterSkin>().Body.AddComponent<ScaleTo>();
        st.isDelay = true;
        st.delayTime = 0.1f;
        st.destScale = new Vector3(0,0,0);
        st.duration =0.2f;
        st.isReverse = true;
        StartCoroutine(IEnumSkill());

    }

    IEnumerator IEnumSkill()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject bat=GameObject.FindGameObjectWithTag("Bat");
       if( bat!=null)
       {
           Vector3 temp = bat.transform.position;
     
       
           this.transform.position = temp;
           Destroy(bat);
       }
     
    }

}
