using UnityEngine;
using System.Collections;

public class AttributeRandom : BuffTiming {

    /// <summary>
    /// 保存原有属性，MoveSpeed  ， AttackSpeed ， AttackRange ， HitRecover ， Luck
    /// </summary>
    int[] attribute_old = new int[5];
    int[] attribute_Buff = new int[5];
    int[] attribute_change = new int[5];  


    public override void Trigger()
    {
        int sum = 0;        
        //获得当前buff的加成
        foreach (var item in this.gameObject.GetComponents<BuffChangeAttributeTemp>())
        {
            if (item != null)
            {                    
                switch (item.Attribute)
                {
                    case 2:
                        attribute_Buff[0] -= item.DValue;
                        break;
                    case 3:
                        attribute_Buff[1] -= item.DValue;
                        break;
                    case 4:
                        attribute_Buff[2] -= item.DValue;
                        break;
                    case 6:
                        attribute_Buff[3] -= item.DValue;
                        break;
                    case 9:
                        attribute_Buff[4] -= item.DValue;
                        break;
                    default:
                        break;
                }
            }
        }
        //获得当前实际的属性值
        attribute_old[0] = Player.Instance.GetComponent<Character>().Mov-attribute_Buff[0];
        attribute_old[1] = Player.Instance.GetComponent<Character>().Spd - attribute_Buff[1];
        attribute_old[2] = Player.Instance.GetComponent<Character>().Rng - attribute_Buff[2];
        attribute_old[3] = Player.Instance.GetComponent<Character>().Fhr - attribute_Buff[3];
        attribute_old[4] = Player.Instance.GetComponent<Character>().Luk - attribute_Buff[4];
        //获得当前属性的总和
        for (int i = 0; i <= 4; i++)
            sum += attribute_old[i];
        //如果当前属性总和大于5
        if (sum >= 5)
        {
            sum -= 5;
            for (int i = 0; i <= 4; i++)
                attribute_change[i] = 1;
            //劲量保证每个属性不超过5
            int head = 0, tail = 4;
            while (sum > 0)
            {
                int attribute = Random.Range(head, tail);
                if (attribute_change[attribute] < 5)
                {
                    attribute_change[attribute]++;
                    sum--;
                    if (attribute_change[attribute] == 5)
                    {
                        int temp = attribute_change[attribute];
                        attribute_change[attribute] = attribute_change[tail];
                        attribute_change[tail] = temp;
                        tail--;
                        if (tail < head)
                            break;
                    }
                }
                else
                    continue;
            }
            //如果每个属性超过5，继续加
            while (sum > 0)
            {
                int attribute = Random.Range(head, tail);
                attribute_change[attribute]++;
                sum--;
            }
        }
        else 
        {
            for (int i = 0; i < sum; i++)
                attribute_change[i] = 1;        
        }
        //将数组中的值随机交换，再次保证随机性
        int attribute_number = 5;
        for (int i = 0; i < attribute_number - 1; i++)
        {
            int k = (int)(Random.value * (attribute_number - i)) + i;
            int n = attribute_change[i];
            attribute_change[i] = attribute_change[k];
            attribute_change[k] = n;
        }



        //改变属性
        Player.Instance.GetComponent<Character>().Mov = Player.Instance.GetComponent<Character>().Mov - attribute_old[0] + attribute_change[0];
        Player.Instance.GetComponent<Character>().Spd = Player.Instance.GetComponent<Character>().Spd - attribute_old[1] + attribute_change[1];
        Player.Instance.GetComponent<Character>().Rng = Player.Instance.GetComponent<Character>().Rng - attribute_old[2] + attribute_change[2];
        Player.Instance.GetComponent<Character>().Fhr = Player.Instance.GetComponent<Character>().Fhr - attribute_old[3] + attribute_change[3];
        Player.Instance.GetComponent<Character>().Luk = Player.Instance.GetComponent<Character>().Luk - attribute_old[4] + attribute_change[4];
    }


    public override void DestroyBuff()
    {
        Player.Instance.GetComponent<Character>().RemoveObserver(this);


        Player.Instance.GetComponent<Character>().Mov = Player.Instance.GetComponent<Character>().Mov + attribute_old[0] - attribute_change[0];
        Player.Instance.GetComponent<Character>().Spd = Player.Instance.GetComponent<Character>().Spd + attribute_old[1] - attribute_change[1];
        Player.Instance.GetComponent<Character>().Rng = Player.Instance.GetComponent<Character>().Rng + attribute_old[2] - attribute_change[2];
        Player.Instance.GetComponent<Character>().Fhr = Player.Instance.GetComponent<Character>().Fhr + attribute_old[3] - attribute_change[3];
        Player.Instance.GetComponent<Character>().Luk = Player.Instance.GetComponent<Character>().Luk + attribute_old[4] - attribute_change[4];



        base.DestroyBuff();
    }
    
    
    public override void Create(int ID, string spTag = "")
    {
        SpecialTag = spTag;
        BuffID = ID;
        Player.Instance.GetComponent<Character>().AddObserver(this);
        Trigger();
    }


    public override void OnNotify(string msg)
    {
        if (UtilManager.Instance.GetFieldFormMsg(msg, -1) == "Die" && UtilManager.Instance.GetFieldFormMsg(msg, 0) == "Boss")
        {
            this.DestroyBuff();        
        }
    }

}
