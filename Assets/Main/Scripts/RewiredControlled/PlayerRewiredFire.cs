using System.Collections;
using Rewired;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using Com.LuisPedroFonseca.ProCamera2D.TopDownShooter;

namespace MageRoyale.RewiredBase
{

	public class PlayerRewiredFire : RewiredBase
	{
		public Pool BulletPool;
		public Transform WeaponTip;

		public float FireRate = .1f;
		public float FireShakeForce = .8f;
		public float FireShakeDuration = .02f;


		protected override void GetInput()
		{
			if (_functionAllowed&& player.GetButtonDown("Launch"))
			{
				StartCoroutine(Fire());
			}
		}
		
		IEnumerator Fire()
		{
			while (_functionAllowed&&player.GetButton("Launch"))
			{
				var bullet = BulletPool.nextThing; 
				bullet.transform.position = WeaponTip.position;
				bullet.transform.rotation = _transform.rotation;

				var angle = _transform.rotation.eulerAngles.y - 90;
				var radians = angle * Mathf.Deg2Rad;
				var vForce = new Vector2((float)Mathf.Sin(radians), (float)Mathf.Cos(radians)) * FireShakeForce;

				ProCamera2DShake.Instance.ApplyShakesTimed(new Vector2[]{ vForce }, new Vector3[]{Vector3.zero}, new float[]{ FireShakeDuration });

				yield return new WaitForSeconds(FireRate);
			}
		}
	}
}
