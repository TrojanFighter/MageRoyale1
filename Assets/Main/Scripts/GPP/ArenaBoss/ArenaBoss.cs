﻿using System.Collections;
using System.Collections.Generic;
using MageRoyale.Entity;
using MageRoyale.Services;
using MageRoyale.Services.Task;
using UnityEngine;

namespace GPP
{
	public enum BossStage
	{
		Appear,
		Spawn,
		Fire,
		Chase
	}

	public class ArenaBoss : MonoBehaviour
	{

		public int HP = 100;
		public Vector3 _originalScale=new Vector3(1,1,0.6f);

		public GameObject EnemyPrefabToSpawn;

		public PlayerEntity targetPlayer;

		public GameObject firePortGO;
		public Transform  EnemySpawnPoint;

		public BossStage m_bossStage;
		
		private void Start()
		{
			Appear();
		}

		private void Update()
		{
			HealthStageCheck();
		}

		void SetBossStage(BossStage stage)
		{
			m_bossStage = stage;
		}


		void SetBossChaseStage()
		{
			SetBossStage(BossStage.Chase);
		}

		void HealthStageCheck()
		{
			if (m_bossStage == BossStage.Appear)
			{
				return;
			}
			else if (HP > 50&&m_bossStage!=BossStage.Spawn)
			{
				SetBossStage(BossStage.Spawn);
				FirstStage();
			}
			else if(HP>15&&m_bossStage!=BossStage.Fire)
			{
				SetBossStage(BossStage.Fire);
				SecondStage();
			}
			else if(m_bossStage!=BossStage.Chase)
			{
				SetBossStage(BossStage.Chase);
				ThirdStage();
			}
		}

		private void Appear()
		{
			SetBossStage(BossStage.Appear);
			// Just setting up some variables so the task constructors below are a little easier to read...
			var startPos = Vector3.zero;//Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 10));

			var startScale = _originalScale*0.01f;
			var endScale = _originalScale;//startScale * 2;

			// Teleport to the left of the screen immediately...
			ServiceList.TaskManager.Do(new SetPosTask(gameObject, startPos))

				// Move to the middle over half a second...
			.Then(new ScaleTask(gameObject, startScale, endScale, 1f)).Then(new ActionTask(SetBossChaseStage));

		}
		
		

		private void FirstStage()
		{
			ServiceList.TaskManager.Do(new SpawnTask(EnemyPrefabToSpawn, EnemySpawnPoint.position, EnemySpawnPoint.rotation));
		}

		private void SecondStage()
		{
			ServiceList.TaskManager.Do(new RandomFireTask(firePortGO, 6, 0.6f)).Then(new Wait(0.4f)).Then(new ActionTask(SecondStage));
		}

		private void ThirdStage()
		{
			SpawnByTime();
			ChasePlayer();
		}

		void SpawnByTime()
		{
			ServiceList.TaskManager.Do(new SpawnTask(EnemyPrefabToSpawn, EnemySpawnPoint.position, EnemySpawnPoint.rotation)).Then(new Wait(3f)).Then(new ActionTask(SpawnByTime));
		}

		void ChasePlayer()
		{
			ServiceList.TaskManager.Do(new MoveTask(gameObject, transform.position, targetPlayer.transform.position, 5f)).Then(new ActionTask(ChasePlayer));
		}
	}
}