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
		public GameObject WaypointList;
		private Transform CurrentTarget;
		private Transform LastWaypoint;
		IAstarAI ai;
		private System.Random random = new System.Random();
		public float DistanceToChase;
		public float TimeLeft;

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
	}
}
