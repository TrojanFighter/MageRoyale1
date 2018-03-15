﻿using MageRoyale.Services.Task;
using UnityEngine;

namespace MageRoyale.Services
{
	public static class Services
	{
		// Renderer     
		private static GameSceneManager _gameSceneManager;

		public static GameSceneManager GameSceneManager
		{
			get
			{
				Debug.Assert(_gameSceneManager != null);
				return _gameSceneManager;
			}
			set { _gameSceneManager = value; }
		}

		private static TaskManager _taskManager;

		public static TaskManager TaskManager
		{
			get
			{
				Debug.Assert(_taskManager != null);
				return _taskManager;
			}
			set { _taskManager = value; }
		}

		// etc... 
	}
}