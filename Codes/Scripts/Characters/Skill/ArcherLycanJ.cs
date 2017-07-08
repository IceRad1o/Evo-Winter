using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcherLycanJ : MonoBehaviour {

	public Animator animator;
	public float fearRangeX = 2.5f;
	public float fearRangeY = 1f;
	public GameObject ArcherLycanParticle;

	void Start()
	{
		animator = GetComponent<Animator>();
	}
	void ArcherLycanJJ()
	{
		//生成粒子
		Vector3 playerPos = Player.Instance.Character.transform.position;
		GameObject particle = Instantiate (ArcherLycanParticle, playerPos, Quaternion.identity) as GameObject;

		//判断恐惧
		FindFear();
	}

	//判断恐惧
	void FindFear()
	{
		if (EnemyManager.Instance.EnemyList.Count > 0) {

			//找到恐惧范围内的怪
			for (int i = 1; i < EnemyManager.Instance.EnemyList.Count; i++) 
			{
				if (Mathf.Abs (EnemyManager.Instance.EnemyList [i].transform.position.x - this.transform.position.x) < fearRangeX &&
					Mathf.Abs (EnemyManager.Instance.EnemyList [i].transform.position.y - this.transform.position.y) < fearRangeY)
				{
					Fear (i);
				}
			}
		}
	}

	//恐惧
	void Fear(int i)
	{
		EnemyManager.Instance.EnemyList [i].CanMove = 0;
		Debug.Log ("Fear:"+i);
		if (Player.Instance.transform.position.x > EnemyManager.Instance.EnemyList [i].transform.position.x)
		{
			if(EnemyManager.Instance.EnemyList [i].FaceDirection>0)
				EnemyManager.Instance.EnemyList [i].FlashBy (-15030);
			else
				EnemyManager.Instance.EnemyList [i].FlashBy (15030);
		} 
		else 
		{
			if(EnemyManager.Instance.EnemyList [i].FaceDirection>0)
				EnemyManager.Instance.EnemyList [i].FlashBy (15030);
			else
				EnemyManager.Instance.EnemyList [i].FlashBy (-15030);
		}

		EnemyManager.Instance.EnemyList [i].CanMove = 1;
	}

	//疾跑
	void Run()
	{
		animator.SetTrigger ("Run");
	}

	void RunEnd()
	{
		animator.SetTrigger ("RunEnd");
	}
}
