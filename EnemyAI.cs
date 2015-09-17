/// <summary>
/// EnemyAI.cs
/// Oct 20, 2010
/// Peter Laliberte
/// 
/// This is some very basic Mob AI we are going to use to get use to coding in C# and Unity
/// 
/// This script is ment to be attached to a mob, or a mob prefab
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
		public Transform target;
		public int moveSpeed;
		public int rotationSpeed;
		public Transform target2;
		public int maxDistance;
		public int minDistance;
		public float distance;
		public float distance2;
		public Transform ultimatetarget;
		private Transform myTransform;
	
		void Awake ()
		{
				myTransform = transform;
		}
	
	
	
		// Update is called once per frame
		void Update ()
		{
				Debug.DrawLine (target.position, myTransform.position, Color.yellow);
				Debug.DrawLine (target2.position, myTransform.position, Color.blue);

				distance = Vector3.Distance (target.position, myTransform.position);
			
				distance2 = Vector3.Distance (target2.position, myTransform.position);
				

				if (distance <= distance2) {
						ultimatetarget = target;		
				} else {
						ultimatetarget = target2;		
				}
		
				//Look at target
				transform.LookAt (new Vector3 (ultimatetarget.position.x, transform.position.y, ultimatetarget.position.z));
		
				if (Vector3.Distance (ultimatetarget.position, myTransform.position) < maxDistance && Vector3.Distance (ultimatetarget.position, myTransform.position) > minDistance) {
						//Move towards target
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
				}
		}
}