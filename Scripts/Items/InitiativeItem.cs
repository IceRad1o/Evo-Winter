using UnityEngine;
using System.Collections;

public class InitiativeItem : Item{







    /*@Destroy
     *@Brief 销毁该实例
     */
    public void Destroy()
    {
        //need UIManager.GetInstance().DestroyInitiativeItem();

        Destroy(gameObject);
    }
}
