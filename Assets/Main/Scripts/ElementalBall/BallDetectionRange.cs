using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MageRoyale.Entity;

namespace MageRoyale.ElementalBall
{
	public class BallDetectionRange : MonoBehaviour
	{

		public ElementalBall m_hostBall;
		public LayerMask trackingLayer;
		public List<PlayerEntity> m_rawTrackingPlayerList,m_trueTrackingPlayerList;
		public Transform m_pursuingTarget;
		public float DetectionAngleInDegrees, maxDistance;
		//The Cos of the maximum angle accepted (-1 is 0 degrees 0 is 90 degrees, -0.5 is 45 degrees, etc...)
		private float maxCosAngle;
		
		// Use this for initialization
		void Start()
		{
			//trackingLayer = LayerMask.NameToLayer("PlayerCollider");
			m_rawTrackingPlayerList=new List<PlayerEntity>();
			m_trueTrackingPlayerList=new List<PlayerEntity>();
			if (m_hostBall == null)
			{
				m_hostBall = transform.parent.GetComponent<ElementalBall>();
			}
		}

		//Fill the raw TrackingList;
		private void OnTriggerEnter(Collider other)
		{
			//if (other.gameObject.layer == trackingLayer)
			{
				if (other.GetComponent<PlayerEntity>())
				{
					Debug.Log("Raw Detect"+other.gameObject.name);
					if (!m_rawTrackingPlayerList.Contains(other.GetComponent<PlayerEntity>()))
					{
						m_rawTrackingPlayerList.Add(other.GetComponent<PlayerEntity>());
					}
				}
			}

		}

		private void OnTriggerExit(Collider other)
		{
			//if (other.gameObject.layer == trackingLayer)
			{
				if (other.GetComponent<PlayerEntity>())
				{
					if (m_rawTrackingPlayerList.Contains(other.GetComponent<PlayerEntity>()))
					{
						m_rawTrackingPlayerList.Remove(other.GetComponent<PlayerEntity>());
					}
					
					if (m_trueTrackingPlayerList.Contains(other.GetComponent<PlayerEntity>()))
					{
						m_trueTrackingPlayerList.Remove(other.GetComponent<PlayerEntity>());
					}
				}
			}
		}

		private void FixedUpdate()
		{
			FilterTruePlayerList();
			LockClosestPlayerAhead();
		}

		void FilterTruePlayerList()
		{
			if (m_rawTrackingPlayerList.Count <= 0)
			{
				return;
			}

			for (int i = 0; i < m_rawTrackingPlayerList.Count; i++)
			{
				if (CheckInCone(m_rawTrackingPlayerList[i].transform))
				{
					Debug.Log("True Tracking Begins " + m_rawTrackingPlayerList[i].gameObject.name);
					if (!m_trueTrackingPlayerList.Contains(m_rawTrackingPlayerList[i]))
					{
						m_trueTrackingPlayerList.Add(m_rawTrackingPlayerList[i]);
					}
					
				}
				else
				{
					if (m_trueTrackingPlayerList.Contains(m_rawTrackingPlayerList[i]))
					{
						m_trueTrackingPlayerList.Remove(m_rawTrackingPlayerList[i]);
					}
				}
			}
		}

		void LockClosestPlayerAhead()
		{
			if (m_trueTrackingPlayerList == null || m_trueTrackingPlayerList.Count <= 0)
			{
				TriggerTracking(null);
				return;
			}

			float closestDistance = maxDistance*maxDistance;
			Transform closestTarget = null;
			for (int i = 0; i < m_trueTrackingPlayerList.Count; i++)
			{
				if (SqrDistance(m_trueTrackingPlayerList[i].transform) <= closestDistance)
				{
					closestDistance = SqrDistance(m_trueTrackingPlayerList[i].transform);
					closestTarget = m_trueTrackingPlayerList[i].transform;
				}
			}
			TriggerTracking(closestTarget);
		}
		
		public bool TriggerTracking(Transform target)
		{
			m_pursuingTarget = target;
			m_hostBall.m_CurrentTarget = target;
			if (target != null)
			{
				Debug.Log("Now Tracking"+target);
				return true;
			}
			else
			{
				return false;
			}
		}


		//tool methods
		
		public bool CheckInCone(Transform toCheck)
		{
			maxCosAngle = Mathf.Cos(DetectionAngleInDegrees * Mathf.Deg2Rad / 2.0f);

			Vector3 difference =  toCheck.position-m_hostBall.transform.position ;
        //Check if it's within range of the arc
			if (difference.magnitude < maxDistance)
			{
        //Checks to see if the object is within a 90 degree Cone in front of the player.
				if (Vector3.Dot(transform.forward, difference.normalized) > maxCosAngle)
				{
					//This object is within the Cone
					return true;
				}
				return false;
			}
			return false;
		}

		public float SqrDistance(Transform toCheck)
		{
			return Vector3.SqrMagnitude(transform.position - toCheck.position);
		}
	}
}
