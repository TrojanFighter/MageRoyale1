﻿using System;
using MageRoyale.Services.Task;
using UnityEngine;

namespace MageRoyale.Services
{

	public class GameServiceManager:MonoBehaviourEX<GameServiceManager>
	{
		public override void Awake()
		{
			base.Awake();
			Init();
		}

		public void Init()
		{
			// Initialize your services in the order         
			// and with the parameters you need

			ServiceList.GameSceneManager = new GameSceneManager();//gameObject.AddComponent<GameSceneManager>();
			ServiceList.TaskManager=new TaskManager();
			ServiceList.GameEntityManager=new GameEntityManager();

		}

		public void Update()
		{
			// Retrieve the services as needed       
			ServiceList.GameSceneManager.Update();
			ServiceList.TaskManager.Update();
			ServiceList.GameEntityManager.Update();

		}

		public void OnEnterDemoMode()
		{
			// Not tying your systems to a singleton also gives you
			// some extra flexibility to change services at runtime         
			//ServiceList.Config = new Config("config/demo_config.json");
		}

		public void OnDestroy()
		{
			// Because you're not using singletons you can manage         
			// the order of destruction for your systems and also         
			// do any additional work required to wind your systems down                 

			ServiceList.GameSceneManager.Destroy();
			ServiceList.TaskManager.Destroy();
			ServiceList.GameEntityManager.Destroy();
		}
	}
}