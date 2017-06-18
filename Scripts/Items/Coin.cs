using UnityEngine;
using System.Collections;

public class Coin : Item {

    int value=1;

    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="other">与其碰撞的GameObj</param>
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && canGet)
        {
            EnterEvent();
            
        }

    }
    public override void EnterEvent()
    {
        base.EnterEvent();
        PickUp();
    }

    public override void  PickUp()
    {
        CoinManager.Instance.GetCoin(value);
        SoundManager.Instance.PlaySoundEffect(ItemsTable.Instance.pickUpSounds[(int)ItemPickUpSound.Coin]);
        ItemManager.Instance.SendMsg("Get_Coin;" + this.gameObject.transform.position.x + ";" + this.gameObject.transform.position.y + ";" + this.gameObject.transform.position.z + ";" + CoinManager.Instance.Wealth);
        this.Destroy();
    }



    public override void Awake()
    {
        base.Awake();

    }



}
