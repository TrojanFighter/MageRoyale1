using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace MageRoyale.ElementalBall
{

	public class BallTrackingGuidance : MonoBehaviour
	{

		// Public vars
		public Transform m_CurrentTarget;
		public BallMovement m_BallMovement;
		public Transform m_turnableRoot;
		public Rigidbody m_rigidBody;
		private Vector3 lastDirection;
		//private Vector3 lastFramePosition;

		//public float TurnSpeed;
		//public float DetectionWidth;

		// Private vars

		// Use this for initialization
		void Start()
		{
			// If follow is null, then pick the player.
			m_BallMovement = GetComponent<BallMovement>();
			m_rigidBody = GetComponent<Rigidbody>();
		}

		// Update is called once per frame
		void FixedUpdate()
		{

			//return;

			
			if (m_CurrentTarget != null)
			{
				// Point at it.
				m_BallMovement.TurnTo(m_CurrentTarget.position - transform.position);
				

				// Go forward
				m_BallMovement.Thrust();
			}
			else
			{
				m_BallMovement.Thrust();
			}
			
			if (m_rigidBody.velocity.sqrMagnitude>0f)//(transform.position-lastFramePosition).sqrMagnitude>0f)
			{
				lastDirection=(m_rigidBody.velocity).normalized;
				m_turnableRoot.forward=lastDirection;
				//Debug.DrawLine(transform.position,transform.position+lastDirection*5f);
			}
			else
			{
				m_turnableRoot.forward=lastDirection;
				//Debug.DrawLine(transform.position,transform.position+lastDirection*5f);
			}

			//lastFramePosition = transform.position;
		}
	}
}
