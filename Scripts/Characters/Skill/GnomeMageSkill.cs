using UnityEngine;
using System.Collections;

public class GnomeMageSkill : MonoBehaviour {

    public GameObject explosion;
    Character ch;
    GameObject[] armsAndHands;
    enum MageState
    {
        Normal,
        SpdAdvanced,
        RngAdvanced,
    }
    MageState state = MageState.Normal;

    private MageState State
    {
        get { return state; }
        set 
        { 
            state = value;
            switch (state)
            {
                case MageState.Normal:
                    for (int i = 0; i < armsAndHands.Length; i++)
                        armsAndHands[i].GetComponent<SpriteRenderer>().color = Color.white;
                        break;
                case MageState.SpdAdvanced:
                        for (int i = 0; i < armsAndHands.Length; i++)
                            armsAndHands[i].GetComponent<SpriteRenderer>().color = new Color(0,1,1f,1f);
                    break;
                case MageState.RngAdvanced:
                    for (int i = 0; i < armsAndHands.Length; i++)
                        armsAndHands[i].GetComponent<SpriteRenderer>().color = new Color(0.7f, 1f, 0f, 1f);

                    break;
                default:
                    break;
            }

        }
    }
    void Start()
    {
        ch=GetComponent<Character>();
        var skin = GetComponent<CharacterSkin>();
        armsAndHands = new GameObject[] {skin.leftHand,skin.leftArm,skin.rightArm,skin.rightHand };
    }

    public void Ignite()
    {
        for(int i=0;i<ch.Servants.Count;i++)
        {
            UtilManager.Instantiate(explosion, ch.Servants[i].transform.position);
        }
        ch.KillServants();

    }

    public void TransSpdState()
    {
        switch(State)
        {
            case MageState.Normal:
                ch.Spd += 1;
                ch.Rng -= 1;
                State = MageState.SpdAdvanced;
                break;
            case MageState.SpdAdvanced:
                ch.Spd -= 1;
                ch.Rng += 1;
                State = MageState.Normal;
                break;
            case MageState.RngAdvanced:
                ch.Spd += 2;
                ch.Rng -= 2;
                State = MageState.SpdAdvanced;
                break;
            default:
                break;
        }
    }

    public void TransRngState()
    {
        switch (State)
        {
            case MageState.Normal:
                ch.Spd -= 1;
                ch.Rng += 1;
                State = MageState.RngAdvanced;
                break;
            case MageState.SpdAdvanced:
                ch.Spd -= 2;
                ch.Rng += 2;
                State = MageState.RngAdvanced;
                break;
            case MageState.RngAdvanced:
                ch.Spd += 1;
                ch.Rng -= 1;
                State = MageState.Normal;
                break;
            default:
                break;
        }
    }

}
