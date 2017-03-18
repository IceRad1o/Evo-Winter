using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public int  Health;
    public int  MoveSpeed;
    public int  AttackSpeed;
    public int  AttackRange;
    public int  AttackDamage;
    public int  HitRecover;
    public int  Luck;
    Character character;


    public void Awake()
    {

    }
	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
        Health = character.Health;
        MoveSpeed = character.MoveSpeed;
        AttackSpeed = character.AttackSpeed;
        AttackDamage = character.AttackDamage;
        HitRecover = character.HitRecover;
        AttackRange = character.AttackRange;
        Luck = character.Luck;
	}
	
	// Update is called once per frame
	void Update () {

          
        character.Health = Health;
        character.MoveSpeed = MoveSpeed;
        character.AttackSpeed = AttackSpeed;
        character.AttackDamage = AttackDamage;
        character.AttackRange = AttackRange;
        character.HitRecover = HitRecover;
        character.Luck = Luck;

	    
	}
}
