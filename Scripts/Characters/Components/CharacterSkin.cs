using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// CharacterSkin
/// 负责Character的骨骼节点以及皮肤的管理
/// 节点和皮肤可以为空
/// Author:IfYan
/// Latest Update Time:2017.5.11
/// </summary>
public class CharacterSkin : MonoBehaviour
{
    #region  Variables

    public enum Type{
        HeadNode,
        TailNode
    }

    #region Control Variables
    public bool isRandomSkin;
    public bool isRandomColor;
    #endregion

    #region Lists
    List<GameObject> boneNodeList = new List<GameObject>(10);

    List<GameObject> skinList = new List<GameObject>(10);

    List<GameObject> decorationList = new List<GameObject>(10);
    #endregion

    #region Bone Nodes
    //节点型
    public GameObject bodyNode;
    public GameObject headNode;
    public GameObject leftArmNode;
    public GameObject rightArmNode;
    public GameObject leftHandNode;
    public GameObject rightHandNode;
    public GameObject leftLegNode;
    public GameObject rightLegNode;
    public GameObject leftEarNode;
    public GameObject rightEarNode;
    public GameObject leftWingNode;
    public GameObject rightWingNode;
    public GameObject tailNode;
    #endregion

    #region Skin Nodes
    //皮肤型
    public GameObject body;
    public GameObject head;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject leftEar;
    public GameObject rightEar;
    #endregion

    #region Decoration Nodes
    /*装饰型*/
    //帽子
    public GameObject cap;
    //额头
    public GameObject forehead;
    //左眼
    public GameObject leftEye;
    //右眼
    public GameObject rightEye;
    //鼻子
    public GameObject nose;
    //嘴
    public GameObject mouth;
    //胡须
    public GameObject whiskers;
    //上衣
    public GameObject coat;
    //左肩甲
    public GameObject leftScapula;
    //右肩甲
    public GameObject rightScapula;
  
    //腰带
    public GameObject belt;
    //背饰
    public GameObject trimBack;

    //左鞋
    public GameObject leftShoe;
    //右鞋
    public GameObject rightShoe;


    //裤根
    public GameObject rootPants;
    //左裤管
    public GameObject leftPant;
    //右裤管
    public GameObject rightPant;
    //左翅膀
    public GameObject leftWing;
    //右翅膀
    public GameObject rightWing;
    //尾部
    public GameObject tail;

    #endregion

    #region Weapon&Missiles
    //发射物
    public GameObject[] missiles;
    //武器
    public GameObject[] weapons;
    //武器的骨骼节点
    public GameObject[] weaponNodes;
    //发射点
    public GameObject[] missilePoints;
    #endregion

    #region Sprites
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
    #endregion
    #endregion
  
    #region Methods

    #region Main Methods
    public void RandomSkinColor()
    {
        float r = Random.value + 0.5f;
        float g = Random.value + 0.5f;
        float b = Random.value + 0.5f;
        for (int i = 0; i < skinList.Count; i++)
        {
            skinList[i].GetComponent<SpriteRenderer>().color = new Color(r, g, b, 1f);
        }
    }

    public void RandomDecoration()
    {
        int rand;
        //Ear
        if (leftEarSprite.Length > 0)
        {
            rand = Random.Range(0, leftEarSprite.Length);
            leftEar.GetComponent<SpriteRenderer>().sprite = leftEarSprite[rand];
            rightEar.GetComponent<SpriteRenderer>().sprite = rightEarSprite[rand];
        }


        //Eye
        rand = Random.Range(0, leftEyeSprite.Length);
        leftEye.GetComponent<SpriteRenderer>().sprite = leftEyeSprite[rand];
        rightEye.GetComponent<SpriteRenderer>().sprite = rightEyeSprite[rand];

        //Cap
        if (capSprite.Length > 0)
        {
            rand = Random.Range(0, capSprite.Length);
            cap.GetComponent<SpriteRenderer>().sprite = capSprite[rand];
        }


        //Whiskers
        rand = Random.Range(0, whiskersSprite.Length);
        whiskers.GetComponent<SpriteRenderer>().sprite = whiskersSprite[rand];

        //Cloth
        //rand = Random.Range(0, clothSprite.Length);
        //cloth.GetComponent<SpriteRenderer>().sprite = clothSprite[rand];

        if (leftShoeSprite.Length > 0)
        {
            //Shoe
            rand = Random.Range(0, leftShoeSprite.Length);
            leftShoe.GetComponent<SpriteRenderer>().sprite = leftShoeSprite[rand];
            rightShoe.GetComponent<SpriteRenderer>().sprite = rightShoeSprite[rand];
        }


    }

    public void SetSkin()
    {
        //Transform bodyNode1 = gameObject.transform.FindChild("BodyNode");
        //Transform body1 = gameObject.transform.FindChild("Body");
        //if(body1!=null)
        //  body1.SetParent(bodyNode1);
        //bodyNode = gameObject.transform.Find("BodyNode").gameObject;
        //body = bodyNode.transform.Find("Body").gameObject;
        ////body.transform.position = new Vector3(0, -1.96f, 0);
        ////body.transform.SetParent(bodyNode.transform);
        //headNode = body.transform.Find("HeadNode").gameObject;
        //head = headNode.transform.Find("Head").gameObject;
        //leftEye = head.transform.Find("LeftEye").gameObject;
        //rightEye = head.transform.Find("RightEye").gameObject;
        //cap = head.transform.Find("Cap").gameObject;
        //whiskers = head.transform.Find("Whiskers").gameObject;
        //rightEarNode = head.transform.Find("RightEarNode").gameObject;
        //leftEarNode = head.transform.Find("LeftEarNode").gameObject;
        //rightEar = rightEarNode.transform.Find("RightEar").gameObject;
        //leftEar = leftEarNode.transform.Find("LeftEar").gameObject;
        //leftArmNode = body.transform.Find("LeftArmNode").gameObject;
        //rightArmNode = body.transform.Find("RightArmNode").gameObject;
        //leftLegNode = body.transform.Find("LeftLegNode").gameObject;
        //rightLegNode = body.transform.Find("RightLegNode").gameObject;
        //cloth = body.transform.Find("Cloth").gameObject;
        //leftArm = leftArmNode.transform.Find("LeftArm").gameObject;
        //rightArm = rightArmNode.transform.Find("RightArm").gameObject;
        //leftHandNode = leftArm.transform.Find("LeftHandNode").gameObject;
        //rightHandNode = rightArm.transform.Find("RightHandNode").gameObject;
        //leftHand = leftHandNode.transform.Find("LeftHand").gameObject;
        //rightHand = rightHandNode.transform.Find("RightHand").gameObject;

        ////weaponPoint = weapon.transform.Find("WeaponPoint").gameObject;
        //leftLeg = leftLegNode.transform.Find("LeftLeg").gameObject;
        //rightLeg = rightLegNode.transform.Find("RightLeg").gameObject;
        //leftShoe = leftLeg.transform.Find("LeftShoe").gameObject;
        //rightShoe = rightLeg.transform.Find("RightShoe").gameObject;

        if(body&&bodyNode)
            body.transform.SetParent(bodyNode.transform);


        BoneNodeList.Clear();
        if (bodyNode)
            BoneNodeList.Add(bodyNode);
        if (headNode)
            BoneNodeList.Add(headNode);
        if (leftArmNode)
            BoneNodeList.Add(leftArmNode);
        if (rightArmNode)
            BoneNodeList.Add(rightArmNode);
        if (leftHandNode)
            BoneNodeList.Add(leftHandNode);
        if (rightHandNode)
            BoneNodeList.Add(rightHandNode);
        if (leftLegNode)
            BoneNodeList.Add(leftLegNode);
        if (rightLegNode)
            BoneNodeList.Add(rightLegNode);
        if (leftEarNode)
            BoneNodeList.Add(leftEarNode);
        if (rightEarNode)
            BoneNodeList.Add(rightEarNode);
        if (leftWingNode)
            BoneNodeList.Add(leftWingNode);
        if (rightWingNode)
            BoneNodeList.Add(rightWingNode);

        SkinList.Clear();
        if (body)
            SkinList.Add(body);
        if (head)
            SkinList.Add(head);
        if (leftArm)
            SkinList.Add(leftArm);
        if (rightArm)
            SkinList.Add(rightArm);
        if (leftHand)
            SkinList.Add(leftHand);
        if (rightHand)
            SkinList.Add(rightHand);
        if (leftLeg)
            SkinList.Add(leftLeg);
        if (rightLeg)
            SkinList.Add(rightLeg);
        if (leftEar)
            SkinList.Add(leftEar);
        if (rightEar)
            SkinList.Add(rightEar);

        DecorationList.Clear();
        if (leftEye)
            DecorationList.Add(leftEye);
        if (rightEye)
            DecorationList.Add(rightEye);
        if (cap)
            DecorationList.Add(cap);
        if (mouth)
            DecorationList.Add(mouth);
        if (whiskers)
            DecorationList.Add(whiskers);
        if(leftScapula)
            DecorationList.Add(leftScapula);
        if (rightScapula)
            DecorationList.Add(rightScapula);
        if (leftShoe)
            DecorationList.Add(leftShoe);
        if (rightShoe)
            DecorationList.Add(rightShoe);
        if (nose)
            DecorationList.Add(nose);
        if (coat)
            DecorationList.Add(coat);
        if (rootPants)
            DecorationList.Add(rootPants);
        if (leftPant)
            DecorationList.Add(leftPant);
        if (rightPant)
            DecorationList.Add(rightPant); 

        if (leftWing)
            DecorationList.Add(leftWing);
        if (rightWing)
            DecorationList.Add(rightWing);
        if (belt)
            DecorationList.Add(belt);
        if (trimBack)
            DecorationList.Add(trimBack);


    }

    public void Add(GameObject obj,CharacterSkin.Type type,string tag=null)
    {

    }

    #endregion

    #region Mono Methods
    void Awake()
    {
        SetSkin();
    }

    void Start()
    {
        if (isRandomSkin)
            RandomDecoration();
        if (isRandomColor)
            RandomSkinColor();
    }
    #endregion

    #region Getter&Setter
    public List<GameObject> BoneNodeList
    {
        get { return boneNodeList; }
        set { boneNodeList = value; }
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

    #endregion
    #endregion
     

}
