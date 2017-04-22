using UnityEngine;
using System.Collections;

public class RougeLycanJ : MonoBehaviour {
	public GameObject[] RougeLaycanParticle;
	//狼人刺客攻击J
	void RougeAttack(){
		
		//最近的怪
		int near = 0;
		//怪的位置，-1左1右
		int direction = -1;
		if (EnemyManager.Instance.EnemyList.Count > 0) {

			//找到最近的怪
			for (int i = 1; i < EnemyManager.Instance.EnemyList.Count; i++) {
				if (Mathf.Abs(EnemyManager.Instance.EnemyList [i].transform.position.x - this.transform.position.x)
					< Mathf.Abs(EnemyManager.Instance.EnemyList [near].transform.position.x- this.transform.position.x))
					near = i;
			}
			//判断方向
			if (EnemyManager.Instance.EnemyList [near].transform.position.x - this.transform.position.x > 0) direction = 1;
			float space = direction * 0.4f;
			this.transform.position = new Vector3 (EnemyManager.Instance.EnemyList [near].transform.position.x + space,
				EnemyManager.Instance.EnemyList [near].transform.position.y,
				EnemyManager.Instance.EnemyList [near].transform.position.z);
			//设置人物朝向
			Player.Instance.Character.CanMove = 1;
			Player.Instance.Character.Direction = new Vector3 (direction * -1f, 0, 0);
			Player.Instance.Character.CanMove = 0;

		}
	}

	//生成粒子
	void LaycanParticle(){
		if (EnemyManager.Instance.EnemyList.Count > 0) {
			Vector3 playerPos = Player.Instance.Character.transform.position;
			GameObject particle = Instantiate (RougeLaycanParticle [0], playerPos, Quaternion.identity) as GameObject;
		}
	}
}