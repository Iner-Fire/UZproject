using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : MonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		public Animator MinoAnim;
		public openChest chest;
		public GameObject WaypointList;
		public TorchScript whichKey;
		public playerMovement counterTorches;
		private Transform CurrentTarget;
		private Transform LastWaypoint;
		IAstarAI ai;
		private System.Random random = new System.Random();
		public float DistanceToChase;
		public AIPath aipath;
		public float TimeLeft;
		private float tmp;
		private float tmp1;
		public Vector3 dir;
		private Vector2 movement;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			
			MinoAnim.SetFloat("speed", aipath.maxSpeed);
			dir = target.position - transform.position;
			dir.Normalize();
			movement = dir;
			this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            MinoAnim.SetFloat("up", dir.x);
			MinoAnim.SetFloat("down", dir.y);
			
			if (chest.isChanged == 1 && PlayerPrefs.GetInt("whichOne") == 1)
			{
				if (counterTorches.potion_invisible >= 1 && whichKey.whichKey == 3)
				{
				
					counterTorches.potion_invisible -= 1;
					tmp = DistanceToChase;
					tmp1 = TimeLeft;
					TimeLeft = 0;
					DistanceToChase = (float)0;
					StartCoroutine(endPotion_invisible(5));


				}
			}
			IEnumerator endPotion_invisible(int secs)
            {
				yield return new WaitForSeconds(secs);
				DistanceToChase = tmp;
				TimeLeft = tmp1;

            }
				if (CurrentTarget!=null && ai.reachedDestination )
            {
				CurrentTarget = null;
            }
			Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, DistanceToChase);
			foreach (var hit in hitColliders)
			{
				
				if (hit.CompareTag("Player"))
				{
					Debug.Log("Target Acquired");
					CurrentTarget = target;
					TimeLeft = 5;
					break;
				}
			}
			if (CurrentTarget==null)
            {
					Transform[] waypoints = WaypointList.GetComponentsInChildren<Transform>();
					Transform selected;
					do
					{
						selected = waypoints[Random.Range(1, waypoints.Length)];
					} while (selected == LastWaypoint);
					LastWaypoint = selected;
					CurrentTarget = selected;
				
            }

			if (ai != null || CurrentTarget != null) 
			{
				ai.destination = CurrentTarget.position;
			}
			TimeLeft -= Time.deltaTime;
			if (TimeLeft <= 0 && CurrentTarget == target) CurrentTarget = null;
		}
		void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(transform.position, DistanceToChase);
		}
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Glue"))
            {
				aipath.maxSpeed /= 3;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Glue"))
            {
				aipath.maxSpeed *= 3;
			}
        }
    }
}
