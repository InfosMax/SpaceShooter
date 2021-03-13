﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Planetarity.RocketsFunctionality;

namespace Planetarity.AstronomicalBodies
{
    public abstract class SpaceBody : MonoBehaviour
    {
        protected const int MIN_SIZE = 3;
        public int Size { get; protected set; }
        public float Speed { get; set; }
        public SphereCollider ObjectGravityZone { get; set; }

        protected float selfRotationSpeedModifier = .05f;
        protected Vector3 rotationVector = Vector3.one;

        protected void RotateSelf()
        {
            transform.Rotate(rotationVector * selfRotationSpeedModifier);
        }

        protected virtual void Update()
        {
            RotateSelf();
        }

        protected virtual void Awake()
        {
            rotationVector = new Vector3(Random.value, Random.value, Random.value);
        }

        protected void AssignGravityZone()
        {
            ObjectGravityZone = gameObject.AddComponent<SphereCollider>();
            ObjectGravityZone.isTrigger = true;
            ObjectGravityZone.radius = 1f;
        }

        protected virtual void InitAppearance()
        {
            Size = MIN_SIZE;
            transform.localScale *= Size;
        }

        // Space object's gravitation implementation
        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<Rocket>() != null)
            {
                var forceVector = (transform.position - other.transform.position).normalized;
                other.attachedRigidbody.AddForce(forceVector * this.Size, ForceMode.Force);
            }

        }
    }
}
