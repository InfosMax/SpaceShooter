﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Planetarity.GameManagement;
using Planetarity.PlayerFunctionality;

namespace Planetarity.RocketsFunctionality
{
    public class RocketLaunchStation : MonoBehaviour, IRocketLaunchStation
    {
        private GameManager GM;
        private List<GameObject> launchedRockets = new List<GameObject>();
        public List<GameObject> LaunchedRockets { get => launchedRockets; set => launchedRockets = value; }

        void Start()
        {
            GM = GameManager.Instance;
        }

        public Rocket InitiateLaunch(Player initiator, string rocketName, Vector3 dirrection)
        {
            GameObject rocketPrefab = GM.GetRocketPrefab(rocketName);
            Rocket newRocket = Instantiate(rocketPrefab, 
                initiator.transform.position + dirrection * initiator.transform.localScale.x,
                Quaternion.LookRotation(dirrection, Vector3.back) ).GetComponent<Rocket>();

            newRocket.LauncherPlanet = initiator.gameObject;

            return newRocket;
        }
    }
}

