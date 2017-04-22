using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LittleDialog
{
    public string content;
    public string people;
    public int condition;
}
public class DialogInfo : ExUnitySingleton<DialogInfo>
{

   public GameObject DialogContent;
    public  GameObject DialogPeople;


    public LittleDialog[] dialogs;



    // Use this for initialization
    void Start()
    {
    
        RandomDialog();
   
    }

    public void RandomDialog()
    {
        if (dialogs == null)
            return;
        if (dialogs.Length < 1)
            return;

        List<int> list=new List<int>();
        for(int i=0;i<dialogs.Length;i++){
           // Debug.Log("a"+dialogs[i].condition + CheckpointManager.Instance.CheckpointNumber);
            if(dialogs[i].condition==CheckpointManager.Instance.CheckpointNumber)
                list.Add(i);
        }
        if (list.Count < 1)
            return;
        int rand;
   
        rand= Random.Range(0, list.Count);
        //Debug.Log("Dialog:" + rand + ";" + list.Count + CheckpointManager.Instance.CheckpointNumber);
        DialogContent.GetComponent<Text>().text = dialogs[list[rand]].content;
        DialogPeople.GetComponent<Text>().text ="--"+ dialogs[list[rand]].people;

      // if( CheckpointManager.Instance.CheckpointNumber)
    }

 
}
