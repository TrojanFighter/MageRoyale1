﻿namespace MageRoyale.Event
{
	public abstract class GameEvent
	{
		public delegate void Handler(GameEvent e);
	}
}