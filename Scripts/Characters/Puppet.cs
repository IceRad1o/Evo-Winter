using UnityEngine;
using System.Collections;
/// <summary>
/// 傀儡,接受玩家发送的消息,进行攻击
/// TODO 画连接线
/// </summary>
public class Puppet : ExSubject {

    public GameObject owner;
    Vector3 posOffset;
	// Use this for initialization
	void Start () {
        owner.GetComponent<Character>().AddObserver(this);
        this.GetComponent<RoomElement>().IsDestoryOnEnterRoom = false;
        posOffset = this.transform.position-owner.transform.position;

       // this.GetComponent<Character>().Controllable = 0;
	}

    public override void OnNotify(string msg)
    {
        if (owner == null)
        {

       
            return;
        }
        base.OnNotify(msg);
        string[] str = UtilManager.Instance.GetMsgFields(msg);
        if(str[0]=="AttackStart")
        {
            if (str[1] == "J" || str[1] == "JJ" || str[1] == "JJJ")
                this.GetComponent<Character>().NormalAttack();
            if (str[1] == "K")
                this.GetComponent<Character>().SpecialAttack();
            if (str[1] == "L")
                this.GetComponent<Character>().UseRaceSkill();
        }
        //if(str[0]=="AttackDamageChanged")


    }

	// Update is called once per frame
    void Update()
    {
        if (owner == null)
        {

            GetComponent<Character>().Destroy();
            return;
        }
        if (this.GetComponent<Character>().IsControllable == 0 || this.GetComponent<Character>().CanMove == 0)
            return;
        Vector3 destPos = owner.transform.position;
        Vector3 srcPos = transform.position;
        Vector3 offset = destPos - srcPos;
        if (offset.x < 0.05 && offset.x > -0.05 && offset.y < 0.05 && offset.y > -0.05)
        {

            this.GetComponent<Character>().IsMove = 0;

            this.GetComponent<Character>().Direction= owner.GetComponent<Character>().Direction;

        }
        else

        {

            offset.Normalize();
            //Vector3 rand = new Vector3(Random.value, Random.value, Random.value);
            //rand.Normalize();
            //offset = offset + offset + rand;//3：1
            offset.Normalize();
            this.GetComponent<Character>().Direction = offset;

            this.GetComponent<Character>().IsMove = 1;
        }
    }


    void RotateBeat()
    {
        Character ch=this.GetComponent<Character>();
        this.gameObject.AddComponent<HurtByContract>().Init(ch.Atk, 4, 0, 0, owner.GetComponent<Character>());
        this.gameObject.AddComponent<MoveBy>().Init(0.5f,new Vector3(6*owner.GetComponent<Character>().FaceDirection,0,0),true);
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject.GetComponent<HurtByContract>());
    }

	
}
