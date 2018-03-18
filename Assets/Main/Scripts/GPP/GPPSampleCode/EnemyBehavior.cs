using System.Collections;
using System.Collections.Generic;
using MageRoyale.Services;
using UnityEngine;
using MageRoyale.Event;

namespace GPP
{




	public class EnemyBehavior : MonoBehaviour
	{

		// Use this for initialization
		void Start()
		{
			ServiceList.EventManager.Register<PlayerPoweredUp>(OnPlayerPoweredUp);
		}

		private void OnDestroy()
		{
			ServiceList.EventManager.UnRegister<PlayerPoweredUp>(OnPlayerPoweredUp);
		}

		void OnPlayerPoweredUp(GameEvent e)
		{
			var powerupEvent = e as PlayerPoweredUp;
			Debug.Log(powerupEvent.playerGO.name);
		}


	}
}
