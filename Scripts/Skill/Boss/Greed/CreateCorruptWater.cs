using UnityEngine;
using System.Collections;

public class CreateCorruptWater : Skill {

    public float skillRangeX = 30;
    public float skillRangeY = 30;
    public int waterLeastNum = 10;
    public int waterMostNum = 20;

    public GameObject waterInFly;
    public GameObject waterInGround;
    public override void Trigger()
    {
        Cd = Random.Range(10,15);
        base.Trigger();
  
        StartCoroutine(SkillTrigger());
    }

    private IEnumerator SkillTrigger()
    {

        int num = Random.Range(waterLeastNum, waterMostNum);
        Vector3 bossPos = this.transform.position;
        Vector3[] posList = new Vector3[num];



        for (int i = 0; i < num; i++)
        {
            float x = (Random.value - 0.5f) * skillRangeX;
            float y = (Random.value - 0.5f) * skillRangeY / 2;
            //TODO 边界判断
            posList[i] = new Vector3(x, y, y);
            UtilManager.Instance.CreateEffcet("Skill/HintCircle", this.transform.position + posList[i]);
        }

        yield return new WaitForSeconds(1f);

        Vector3 startPoint = this.gameObject.transform.position + new Vector3(0, 2, 0);

        for (int i = 0; i < num; i++)
        {
            GameObject ins = Instantiate(waterInFly, startPoint, Quaternion.identity) as GameObject;
            if(tag=="Boss")
                ins.GetComponent<CorruptWater>().Boss = gameObject;
            else if(tag=="FakeBoss")
                ins.GetComponent<CorruptWater>().Boss = GetComponent<FakeBoss>().trueBoss;

            Vector3[] paths = new Vector3[3];
            paths[0] = startPoint;
            paths[2] = bossPos + posList[i];
            paths[1] = paths[0] + (paths[2] - paths[0]) / 3;
            paths[1] = new Vector3(paths[1].x, 3, paths[1].z);
         
            iTween.MoveTo(ins, iTween.Hash("path", paths, "speed", 20f, "easeType", iTween.EaseType.easeInQuad));
        }

    }

}
