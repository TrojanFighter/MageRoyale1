using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageRoyale.ElementalBall
{

	public class ElementalBall : MonoBehaviour
	{

		// Public vars
		public Transform m_CurrentTarget;
		public BallMovement m_BallMovement;

		public float TurnSpeed;
		public float DetectionWidth;

		// Private vars

		// Use this for initialization
		void Start()
		{
			// If follow is null, then pick the player.
			m_BallMovement = GetComponent<BallMovement>();
		}

		// Update is called once per frame
		void FixedUpdate()
		{

			return;
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
		}
	}
}
