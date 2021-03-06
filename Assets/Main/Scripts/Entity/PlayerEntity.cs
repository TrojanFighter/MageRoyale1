﻿
using UnityEngine;
using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D;
using MageRoyale.RewiredBase;
using MageRoyale.Services;
using GameOver = Com.LuisPedroFonseca.ProCamera2D.TopDownShooter.GameOver;

namespace MageRoyale.Entity
{

	public class PlayerEntity : EntityBase
	{
		public int Health = 100;
		
		
		public Renderer[] _renderers;
		Color _originalColor;

		public override bool Init()
		{
			//_renderers = GetComponentsInChildren<Renderer>();
			_originalColor = _renderers[0].material.color;
			return base.Init();
		}
		public void Hit(int damage)
		{
			Health -= damage;

			StartCoroutine(HitAnim());

			if (Health <= 0)
			{
				// Do something here
				SelfDestroy();
			}
		}

		IEnumerator HitAnim()
		{
			ProCamera2DShake.Instance.Shake("PlayerHit");

			for (int i = 0; i < _renderers.Length; i++)
			{
				_renderers[i].material.color = Color.white;
			}

			yield return new WaitForSeconds(.05f);

			for (int i = 0; i < _renderers.Length; i++)
			{
				_renderers[i].material.color = _originalColor;
			}
		}

		public override void SelfDestroy()
		{
			GameOver.Instance.ShowScreen(GetComponent<PlayerRewiredControl>().playerId.ToString());
			base.SelfDestroy();
		}
	}
}
