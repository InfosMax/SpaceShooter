﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Planetarity.AstronomicalBodies;

namespace Planetarity.GameManagement
{
    public class LevelGenerator : MonoBehaviour, ILevelGenerator
    {
        [SerializeField]
        private GameObject sunPrefab;
        [SerializeField]
        private GameObject planetPrefab;

        private float distanceBetweenPlanets = 10f;

        public float DistanceBetweenPlanets { get => distanceBetweenPlanets; set => distanceBetweenPlanets = value; }
        public GameObject SunObj { get; set; }
        public List<GameObject> Planets { get; set; }

        public void Generate(int enemiesMinNumber, int enemiesMaxNumber)
        {
            int enemiesNum = Random.Range(enemiesMinNumber, enemiesMaxNumber + 1);
            Debug.Log($"Enemies number is {enemiesNum}");

            // Creating the Sun
            Instantiate(sunPrefab, Vector3.zero, Quaternion.identity);

            createPlanets(enemiesNum);
        }

        private void createPlanets(int planetsCount)
        {
            Planets = new List<GameObject>();
            GameObject newPlanet;

            for (var i = 0; i < planetsCount; i++)
            {
                newPlanet = Instantiate(planetPrefab,
                    new Vector3(Sun.ComparingSize / 2f + (DistanceBetweenPlanets * (i + 1)), 0f, 0f),
                    Quaternion.identity);
                Planets.Add(newPlanet);
            }

        }

        public void removePlayerPlanetFromList(GameObject planet)
        {
            Planets.Remove(planet);
        }

        public GameObject[] getPlanetsGO()
        {
            return Planets.ToArray();
        }
    }
}
