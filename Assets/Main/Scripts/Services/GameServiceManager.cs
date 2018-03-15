using System;
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

			Services.GameSceneManager = new GameSceneManager();//gameObject.AddComponent<GameSceneManager>();
			Services.TaskManager=new TaskManager();

		}

		public void Update()
		{
			// Retrieve the services as needed       
			Services.GameSceneManager.Update();
			Services.TaskManager.Update();

		}

		public void OnEnterDemoMode()
		{
			// Not tying your systems to a singleton also gives you
			// some extra flexibility to change services at runtime         
			//Services.Config = new Config("config/demo_config.json");
		}

		public void OnDestroy()
		{
			// Because you're not using singletons you can manage         
			// the order of destruction for your systems and also         
			// do any additional work required to wind your systems down                 

			Services.GameSceneManager.Destroy();
			Services.TaskManager.Destroy();
		}
	}
}