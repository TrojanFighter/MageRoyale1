using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using MageRoyale.Entity;
using UnityEngine;

namespace MageRoyale.Entity
{

    public class BallSpawner : MonoBehaviourEX<BallSpawner>
    {
        public float generationGap = 3f;

        public BallEntity ballPrefab;

        public Vector3 ballSpawnPosition;

        void Start()
        {
            StartCoroutine(GenerateBall());
        }

        IEnumerator GenerateBall()
        {
            while (true)
            {
                GenerateRandomBall();
                yield return new WaitForSeconds(generationGap);
            }
        }

        void GenerateRandomBall()
        {
            BallEntity elementalBall = Instantiate(ballPrefab, ballSpawnPosition, Quaternion.identity) as BallEntity;
            elementalBall.Init();
        }
    }
}
