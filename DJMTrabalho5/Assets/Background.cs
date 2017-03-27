using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	// Use this for initialization

		[Header("Scene References")]
		public Material material;

		[Header("Velocity")]
		public Vector2 scrollVelocity;

		private Vector2 scrollOffset;

		private bool isStopped = false;

		// Use this for initialization
		void Start () {
			scrollOffset = Vector2.zero;

			// material.mainTextureOffset = scrollOffset;
			material.SetTextureOffset ("_MainTex", scrollOffset);
		}

		// Update is called once per frame
		void Update () {
			if (isStopped)
				return;

			// Atualiza offset
			scrollOffset += scrollVelocity * Time.deltaTime;

			// material.mainTextureOffset = scrollOffset;
			material.SetTextureOffset ("_MainTex", scrollOffset);
		}

		void StopScroll()
		{
			isStopped = true;
		}

}
