/// <summary>
/// EnemyAttack.cs
/// Oct 20, 2010
/// Peter Laliberte
/// 
/// This is a very basic Mob Attack script that we are going to use to get use to coding in C# and Unity
/// 
/// This script is ment to be attached to a mob, or a mob prefab
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject target;
	public float attackTimer;
	public float coolDown;

	// Use this for initialization
	void Start () {
		attackTimer = 0;


	}

	void update(){

	}
	// Update is called once per frame


	void OnTriggerStay(Collider entity) {
		attackTimer -= Time.deltaTime;


		if (entity.tag == "Player" && attackTimer <= 0 ) {
		
			Health en = entity.GetComponent<Health>();
			en.ModifyHealth(-10);
			attackTimer = 2;
		}
	    
	}

}
