using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;
using MageRoyale.Entity;

namespace MageRoyale.ElementalBall
{
	public class BallCollisionDetector : MonoBehaviour
	{
		/*public BallTrackingGuidance m_TrackingGuidance;*/

		public BallEntity m_hostBallEntity;

		void Start()
		{
			/*if (m_TrackingGuidance == null)
			{
				m_TrackingGuidance = GetComponent<BallTrackingGuidance>();
			}*/
			if (m_hostBallEntity == null)
			{
				m_hostBallEntity = GetComponent<BallEntity>();
			}
		}


		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.layer == GlobalDefine.wallLayerMask)
			{
				MasterAudio.PlaySound("Bounce");
			}
			else if (other.gameObject.layer == GlobalDefine.playerMask)
			{
				MasterAudio.PlaySound("Dead");
				other.gameObject.GetComponent<PlayerEntity>().Hit(m_hostBallEntity.DamageToPlayer);
				m_hostBallEntity.SelfDestroy();
			}
		}
	}
}
