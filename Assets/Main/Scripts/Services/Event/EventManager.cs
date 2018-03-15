﻿using System;
using System.Collections;
using System.Collections.Generic;
using MageRoyale.Event;

namespace MageRoyale.Services.Event
{

	public class EventManager:ServiceBase
	{
		/*private static EventManager _instance;
		public static EventManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance=new EventManager();
				}

				return _instance;
			}
		}*/
		public EventManager()
		{
			Init();
		}

		// Use this for initialization
		public override void Init() {
		
		}
	
		// Update is called once per frame
		public override void Update() {
		
		}

		public override void Destroy()
		{
		}
		
		private readonly Dictionary<System.Type,GameEvent.Handler> _eventTypeToHandlersMap=new Dictionary<Type, GameEvent.Handler>();

		public void Register<EventType>(GameEvent.Handler handler) where EventType : GameEvent
		{
			System.Type type = typeof(EventType);
			GameEvent.Handler handlers;
			if (_eventTypeToHandlersMap.ContainsKey(type))
			{
				_eventTypeToHandlersMap[type] += handler;
			}
			else
			{
				_eventTypeToHandlersMap.Add(type,handler);
			}
		}

		public void UnRegister<EventType>(GameEvent.Handler handler) where EventType : GameEvent
		{
			System.Type type = typeof(EventType);
			GameEvent.Handler handlers;
			if (_eventTypeToHandlersMap.TryGetValue(type, out handlers))
			{
				handlers -= handler;
				if (handlers == null)
				{
					_eventTypeToHandlersMap.Remove(type);
				}
				else
				{
					_eventTypeToHandlersMap[type] = handlers;
				}
			}
		}

		public void Fire(GameEvent e)
		{
			System.Type type = e.GetType();
			GameEvent.Handler handlers;
			if (_eventTypeToHandlersMap.TryGetValue(type, out handlers))
			{
				handlers(e);
			}
			//GameEvent.Handler handlers;
			//_eventTypeToHandlersMap[type].
			
		}
	}
}