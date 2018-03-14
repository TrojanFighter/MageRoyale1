using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageRoyale.ElementalBall
{

	public class BallMovement : MonoBehaviour
	{

// Public vars
		public float TurnForce = 10f;
		public float GuidanceVectorForce = 10f;
		public float PropellForce = 20f;
		private Rigidbody _rigidbody;

		//public Quaternion m_logicalPropulsionDirection, m_internalGuidanceDirection;

		//矢量推进引导，在目标朝向侧面垂直方向.
		public Vector3 m_guideForceDirection;
		
		//public float AcceptableAngleDifferenceInDegrees=5f;
		// Private vars
		//float lastToTurn = 0;
		//private float maxCosAngle;

		void Start()
		{
			_rigidbody = GetComponent<Rigidbody>();
			//m_logicalPropulsionDirection = transform.rotation;
		}

		// Turn to a direction
		public void TurnTo(Vector3 _targetdir)
		{
			Debug.Log("Turning to direction"+_targetdir);
			_targetdir.Normalize();
			_targetdir.y = transform.position.y;

			int angleDirection = AngleDir(_rigidbody.velocity.normalized,_targetdir,Vector3.up);

			switch (angleDirection)
			{
					case 0: break;
					case -1:
						m_guideForceDirection = Vector3.Cross(_targetdir, Vector3.up);

						_rigidbody.AddForce(m_guideForceDirection * GuidanceVectorForce * Time.deltaTime);break;
					case 1:
						m_guideForceDirection = Vector3.Cross(_targetdir, Vector3.down);

						_rigidbody.AddForce(m_guideForceDirection * GuidanceVectorForce * Time.deltaTime);break;
					default:break;
			}
			
			
			/*
			//version2
			maxCosAngle = Mathf.Cos(AcceptableAngleDifferenceInDegrees * Mathf.Deg2Rad / 2.0f);

			if (Vector3.Dot(_rigidbody.velocity.normalized, _targetdir) < maxCosAngle)
			{
				//Debug.Log(Vector3.Dot(_rigidbody.velocity.normalized, _targetdir));
				m_guideForceDirection = Vector3.Cross(_targetdir, Vector3.up);

				_rigidbody.AddForce(m_guideForceDirection * GuidanceVectorForce * Time.deltaTime);
			}*/
			//m_internalGuidanceDirection = Quaternion.LookRotation(_targetdir);
			//m_logicalPropulsionDirection=Quaternion.RotateTowards(m_logicalPropulsionDirection, m_internalGuidanceDirection, Time.deltaTime * TurnForce);

			//transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, Time.deltaTime * TurnForce);
			/*float dist = -Mathf.DeltaAngle(Quaternion.LookRotation(_targetdir).eulerAngles.y, transform.eulerAngles.y);

			float maxAcc = TurnForce / (GetComponent<Rigidbody>().mass * 10f);

			maxAcc = Mathf.Min(maxAcc, Mathf.Abs(dist));

			float targetVel;
			if (dist > 0)
				targetVel = Mathf.Sqrt(2.0f * maxAcc * dist);
			else
				targetVel = -Mathf.Sqrt(2.0f * maxAcc * -dist);

			float thrust = targetVel - GetComponent<Rigidbody>().angularVelocity.y;

			float force = thrust * GetComponent<Rigidbody>().mass * 10f;

			// Turn the rocket.
			Turn(force);*/
		}

		//旋转后指向力方向 不适用矢量推进
		public void Turn(float _val)
		{
			_val = Mathf.Clamp(_val, -TurnForce, TurnForce);

			// Turn the rocket.
			GetComponent<Rigidbody>().AddTorque(new Vector3(0, _val, 0));
		}

		public void Thrust()
		{
			//_rigidbody.AddForce(transform.TransformDirection(Vector3.forward) * GuidanceVectorForce * Time.deltaTime);
			//_rigidbody.AddForce(m_logicalPropulsionDirection.eulerAngles * GuidanceVectorForce * Time.deltaTime);
			_rigidbody.AddForce(_rigidbody.velocity.normalized * PropellForce * Time.deltaTime);
			
		}
		
		int AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
			Vector3 perp = Vector3.Cross(fwd, targetDir);
			float dir = Vector3.Dot(perp, up);
		
			if (dir > 0f) {
				return 1;
			} else if (dir < 0f) {
				return -1;
			} else {
				return 0;
			}
		}
	}
}
