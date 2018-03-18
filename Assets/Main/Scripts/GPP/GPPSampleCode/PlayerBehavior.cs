using System.Collections;
using System.Collections.Generic;
using MageRoyale.Services;
using UnityEngine;
using MageRoyale.Event;

namespace GPP
{

	public class PlayerPoweredUp : GameEvent
	{
		public GameObject playerGO;

		public PlayerPoweredUp(GameObject player)
		{
			playerGO = player;
		}
	}

	public class PlayerBehavior : MonoBehaviour
	{
		public string Name = "Player";

		void Start()
		{
			StartCoroutine(PowerUp());
		}

		IEnumerator PowerUp()
		{
			yield return  new WaitForSeconds(1);
			ServiceList.EventManager.Fire(new PlayerPoweredUp(gameObject));
		}
	}
}