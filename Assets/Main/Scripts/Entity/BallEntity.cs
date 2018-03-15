

using MageRoyale.ElementalBall;
using UnityEngine;

namespace MageRoyale.Entity
{

	public class BallEntity : EntityBase
	{
		public int DamageToPlayer = 30;
		public BallTrackingGuidance m_Guidance;

		public override bool Init()
		{
			transform.rotation=Quaternion.Euler(0,Random.Range(0,360f),0);
			//m_Guidance.InitThrust();
			return base.Init();
		}
	}
}
