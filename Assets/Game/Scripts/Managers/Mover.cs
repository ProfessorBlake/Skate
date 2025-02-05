using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Mover : MonoBehaviour
	{
		public float BackstopPosition => backstopPosition;
		public float GameSpeed => gameSpeed;

		[SerializeField] private float gameSpeedStart;
		[SerializeField] private float gameSpeedIncrease;
		[SerializeField] private float gameSpeedInterval;
		[SerializeField] private Transform cameraTransform;
		[SerializeField] private float backstopOffset;

		private float gameSpeed;
		private float gameSpeedNextInc;
		private float backstopPosition;

		private void Start()
		{
			gameSpeed = gameSpeedStart;
			gameSpeedNextInc = Time.time + gameSpeedInterval;
			backstopPosition = backstopOffset;
		}

		private void Update()
		{
			if(Time.time >= gameSpeedNextInc)
			{
				gameSpeedNextInc = Time.time + gameSpeedInterval;
				gameSpeed += gameSpeedIncrease;
			}
			backstopPosition += gameSpeed * Time.deltaTime;
		}

		private void LateUpdate()
		{
			cameraTransform.position += new Vector3(gameSpeed * Time.deltaTime, 0, 0);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			if (Application.isPlaying)
				Gizmos.DrawCube(new Vector3(backstopPosition, 0, 0), new Vector3(0.1f, 4, 4));
			else
				Gizmos.DrawCube(new Vector3(backstopOffset, 0, 0), new Vector3(0.1f, 4, 4));
		}
	}
}