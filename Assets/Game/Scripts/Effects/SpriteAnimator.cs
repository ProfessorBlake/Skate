using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class SpriteAnimator : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer sprRend;
		[SerializeField] private Sprite[] sprites;
		[SerializeField] private float frameDelay;
		[SerializeField] private bool loop;
		[SerializeField] private bool randomStartFrame;

		private float frameTime;
		private int spriteIndex;

		private void Start()
		{
			if(randomStartFrame) spriteIndex = Random.Range(0, sprites.Length);
		}

		private void Update()
		{
			if(Time.time >= frameTime)
			{
				frameTime = Time.time + frameDelay;
				spriteIndex += 1;
				if(spriteIndex >= sprites.Length) spriteIndex = 0;
				sprRend.sprite = sprites[spriteIndex];
			}
		}
	}
}