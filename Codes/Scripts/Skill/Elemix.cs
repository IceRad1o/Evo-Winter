using UnityEngine;
using System.Collections;

public class Elemix : Skill {

    GameObject prefabInstance;

    public void CreateSkill(int ID, GameObject ob)
    {
        int[] part = { 2, 2, 3, 1, 2 };
        int[] idPart = UtilManager.Instance.DecomposeID(ID, part);
        float yz = -Random.value * 5;
        switch (idPart[0])
        {
            case 5:
                 CreateSkill( (int)(Random.value * 3) + 1,ob);
                 return;
            case 2:
                CreatePrefab("Skill/Firewall", new Vector3(Random.value * 12 - 6, yz, yz));
                break;
            case 3:
                CreatePrefab("Skill/Icewall", new Vector3(Random.value * 12 - 6, yz, yz));
                break;
            case 4:
                CreatePrefab("Skill/Skill4", new Vector3(Random.value * 12 - 6, yz, yz));
                break;

            default:
                break;
        }
    }

    void CreatePrefab(string add, Vector3 v3) 
    {
        Debug.Log("Create");
        GameObject pfb = Resources.Load(add) as GameObject;
        //Vector3 s = new Vector3(Random.value % 12 - 6, -Random.value % 5, -Random.value % 5);
        prefabInstance = Instantiate(pfb);
        prefabInstance.transform.position = v3;
    
    
    }
}
