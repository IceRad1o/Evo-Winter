using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// YYF 17.3.20
/// 负责Character内部节点的管理
/// </summary>
public class CharacterSkin : MonoBehaviour
{


    List<GameObject> nodeList = new List<GameObject>();


    List<GameObject> skinList = new List<GameObject>();


    List<GameObject> decorationList = new List<GameObject>();



    //节点型
    GameObject bodyNode;
    GameObject headNode;
    GameObject leftArmNode;
    GameObject rightArmNode;
    GameObject leftHandNode;
    GameObject rightHandNode;
    GameObject leftLegNode;
    GameObject rightLegNode;
    GameObject leftEarNode;
    GameObject rightEarNode;
    GameObject weaponNode;
    GameObject weapon2Node;


    //皮肤型
    GameObject body;
    GameObject head;
    GameObject leftArm;
    GameObject rightArm;
    GameObject leftHand;
    GameObject rightHand;
    GameObject leftLeg;
    GameObject rightLeg;
    GameObject leftEar;
    GameObject rightEar;

    //装饰型
    GameObject leftEye;
    GameObject rightEye;
    GameObject cap;
    GameObject whiskers;
    GameObject cloth;
    GameObject leftShoe;
    GameObject rightShoe;

    //武器型
    GameObject weapon;
    GameObject weapon2;

  
    //Sprite
   public Sprite[] leftEarSprite;
   public Sprite[] rightEarSprite;
   public Sprite[] leftEyeSprite;
   public Sprite[] rightEyeSprite;
   public Sprite[] capSprite;
   public Sprite[] whiskersSprite;
   public Sprite[] clothSprite;
   public Sprite[] leftShoeSprite;
   public Sprite[] rightShoeSprite;

    void RandomSkinColor()
   {
       float r = Random.value+0.5f;
       float g = Random.value+0.5f;
       float b = Random.value+0.5f;
        for(int i=0;i<skinList.Count;i++)
        {
            //skinList[i].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 0,1);
            skinList[i].GetComponent<SpriteRenderer>().color = new Color(r, g,b, 1f);
        }
   }

    void RandomDecoration()
    {
        int rand;
        //Ear
        rand = Random.Range(0, leftEarSprite.Length);
        leftEar.GetComponent<SpriteRenderer>().sprite = leftEarSprite[rand];
        rightEar.GetComponent<SpriteRenderer>().sprite = rightEarSprite[rand];

        //Eye
        rand = Random.Range(0, leftEyeSprite.Length);
        leftEye.GetComponent<SpriteRenderer>().sprite = leftEyeSprite[rand];
        rightEye.GetComponent<SpriteRenderer>().sprite = rightEyeSprite[rand];

        //Cap
        rand = Random.Range(0, capSprite.Length);
        cap.GetComponent<SpriteRenderer>().sprite = capSprite[rand];

        //Whiskers
        rand = Random.Range(0, whiskersSprite.Length);
        whiskers.GetComponent<SpriteRenderer>().sprite = whiskersSprite[rand];

        //Cloth
        rand = Random.Range(0, clothSprite.Length);
        cloth.GetComponent<SpriteRenderer>().sprite = clothSprite[rand];

        //Shoe
        rand = Random.Range(0, leftShoeSprite.Length);
        leftShoe.GetComponent<SpriteRenderer>().sprite = leftShoeSprite[rand];
        rightShoe.GetComponent<SpriteRenderer>().sprite = rightShoeSprite[rand];

    }





    void Awake()
    {
        Transform bodyNode1 = gameObject.transform.FindChild("BodyNode");
        Transform body1 = gameObject.transform.FindChild("Body");
        body1.SetParent(bodyNode1);
        bodyNode = gameObject.transform.Find("BodyNode").gameObject;
        body = bodyNode.transform.Find("Body").gameObject;
        //body.transform.SetParent(bodyNode.transform);
        headNode = body.transform.Find("HeadNode").gameObject;
        head = headNode.transform.Find("Head").gameObject;
        leftEye = head.transform.Find("LeftEye").gameObject;
        rightEye = head.transform.Find("RightEye").gameObject;
        cap = head.transform.Find("Cap").gameObject;
        whiskers = head.transform.Find("Whiskers").gameObject;
        rightEarNode = head.transform.Find("RightEarNode").gameObject;
        leftEarNode = head.transform.Find("LeftEarNode").gameObject;
        rightEar = rightEarNode.transform.Find("RightEar").gameObject;
        leftEar = leftEarNode.transform.Find("LeftEar").gameObject;
        leftArmNode = body.transform.Find("LeftArmNode").gameObject;
        rightArmNode = body.transform.Find("RightArmNode").gameObject;
        leftLegNode = body.transform.Find("LeftLegNode").gameObject;
        rightLegNode = body.transform.Find("RightLegNode").gameObject;
        cloth = body.transform.Find("Cloth").gameObject;
        leftArm = leftArmNode.transform.Find("LeftArm").gameObject;
        rightArm = rightArmNode.transform.Find("RightArm").gameObject;
        leftHandNode = leftArm.transform.Find("LeftHandNode").gameObject;
        rightHandNode = rightArm.transform.Find("RightHandNode").gameObject;
        leftHand = leftHandNode.transform.Find("LeftHand").gameObject;
        rightHand = rightHandNode.transform.Find("RightHand").gameObject;
        weaponNode = rightHand.transform.Find("WeaponNode").gameObject;
        weapon = weaponNode.transform.Find("Weapon").gameObject;
        //weaponPoint = weapon.transform.Find("WeaponPoint").gameObject;
        leftLeg = leftLegNode.transform.Find("LeftLeg").gameObject;
        rightLeg = rightLegNode.transform.Find("RightLeg").gameObject;
        leftShoe = leftLeg.transform.Find("LeftShoe").gameObject;
        rightShoe = rightLeg.transform.Find("RightShoe").gameObject;


        if (leftHand.transform.Find("WeaponNodeL") != null)
        { 
            weapon2Node = leftHand.transform.Find("WeaponNodeL").gameObject;
            weapon2 = weapon2Node.transform.Find("Weapon").gameObject;
        }



        NodeList.Add(bodyNode);
        NodeList.Add(headNode);
        NodeList.Add(leftArmNode);
        NodeList.Add(rightArmNode);
        NodeList.Add(leftHandNode);
        NodeList.Add(rightHandNode);
        NodeList.Add(leftLegNode);
        NodeList.Add(rightLegNode);
        NodeList.Add(leftEarNode);
        NodeList.Add(rightEarNode);
        NodeList.Add(weaponNode);

        SkinList.Add(body);
        SkinList.Add(head);
        SkinList.Add(leftArm);
        SkinList.Add(rightArm);
        SkinList.Add(leftHand);
        SkinList.Add(rightHand);
        SkinList.Add(leftLeg);
        SkinList.Add(rightLeg);
        SkinList.Add(leftEar);
        SkinList.Add(rightEar);

        DecorationList.Add(leftEye);
        DecorationList.Add(rightEye);
        DecorationList.Add(cap);
        DecorationList.Add(whiskers);
        DecorationList.Add(cloth);
        DecorationList.Add(leftShoe);
        DecorationList.Add(rightShoe);


        //RandomSkinColor();
        RandomDecoration();

    }


    /*****************************************封装*****************************************/
    public List<GameObject> NodeList
    {
        get { return nodeList; }
        set { nodeList = value; }
    }

    public List<GameObject> SkinList
    {
        get { return skinList; }
        set { skinList = value; }
    }

    public List<GameObject> DecorationList
    {
        get { return decorationList; }
        set { decorationList = value; }
    }

    public GameObject BodyNode
    {
        get { return bodyNode; }
        set
        {
            bodyNode = value;
        }
    }
    public GameObject HeadNode
    {
        get { return headNode; }
        set
        {
            headNode = value;
        }
    }
    public GameObject LeftArmNode
    {
        get { return leftArmNode; }
        set
        {
            leftArmNode = value;
        }
    }
    public GameObject RightArmNode
    {
        get { return rightArmNode; }
        set
        {
            rightArmNode = value;
        }
    }
    public GameObject LeftHandNode
    {
        get { return leftHandNode; }
        set
        {
            leftHandNode = value;
        }
    }
    public GameObject RightHandNode
    {
        get { return rightHandNode; }
        set
        {
            rightHandNode = value;
        }
    }
    public GameObject LeftLegNode
    {
        get { return leftLegNode; }
        set
        {
            leftLegNode = value;
        }
    }
    public GameObject RightLegNode
    {
        get { return rightLegNode; }
        set
        {
            rightLegNode = value;
        }
    }
    public GameObject LeftEarNode
    {
        get { return leftEarNode; }
        set
        {
            leftEarNode = value;
        }
    }
    public GameObject RightEarNode
    {
        get { return rightEarNode; }
        set
        {
            rightEarNode = value;
        }
    }
    public GameObject WeaponNode
    {
        get { return weaponNode; }
        set
        {
            weaponNode = value;
        }
    }
    public GameObject Body
    {
        get { return body; }
        set
        {
            body = value;
        }
    }
    public GameObject Head
    {
        get { return head; }
        set
        {
            head = value;
        }
    }
    public GameObject LeftArm
    {
        get { return leftArm; }
        set
        {
            leftArm = value;
        }
    }
    public GameObject RightArm
    {
        get { return rightArm; }
        set
        {
            rightArm = value;
        }
    }
    public GameObject LeftHand
    {
        get { return leftHand; }
        set
        {
            leftHand = value;
        }
    }
    public GameObject RightHand
    {
        get { return rightHand; }
        set
        {
            rightHand = value;
        }
    }
    public GameObject LeftLeg
    {
        get { return leftLeg; }
        set
        {
            leftLeg = value;
        }
    }
    public GameObject RightLeg
    {
        get { return rightLeg; }
        set
        {
            rightLeg = value;
        }
    }
    public GameObject LeftEar
    {
        get { return leftEar; }
        set
        {
            leftEar = value;
        }
    }
    public GameObject RightEar
    {
        get { return rightEar; }
        set
        {
            rightEar = value;
        }
    }
    public GameObject LeftEye
    {
        get { return leftEye; }
        set
        {
            leftEye = value;
        }
    }
    public GameObject RightEye
    {
        get { return rightEye; }
        set
        {
            rightEye = value;
        }
    }
    public GameObject Cap
    {
        get { return cap; }
        set
        {
            cap = value;
        }
    }
    public GameObject Whiskers
    {
        get { return whiskers; }
        set
        {
            whiskers = value;
        }
    }
    public GameObject Cloth
    {
        get { return cloth; }
        set
        {
            cloth = value;
        }
    }
    public GameObject LeftShoe
    {
        get { return leftShoe; }
        set
        {
            leftShoe = value;
        }
    }
    public GameObject RightShoe
    {
        get { return rightShoe; }
        set
        {
            rightShoe = value;
        }
    }
    public GameObject Weapon
    {
        get { return weapon; }
        set
        {
            weapon = value;
        }
    }


    public GameObject Weapon2Node
    {
        get { return weapon2Node; }
        set { weapon2Node = value; }
    }

    public GameObject Weapon2
    {
        get { return weapon2; }
        set { weapon2 = value; }
    }

}
