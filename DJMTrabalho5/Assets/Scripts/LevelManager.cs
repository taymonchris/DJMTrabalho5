﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : ScrollingManager {

	public Vector3 scrollVelocity;

	private ChunkSelection chunkSelection;

	// Use this for initialization
	GameObject player;
	void Awake () {
		chunkSelection 
			= scrollingObjectPrefab.GetComponent<ChunkSelection> ();
		chunkSelection.SelectChunk ();
	}
	//void Start (){
	//	player = GameObject.FindGameObjectWithTag ("Player");
	//}
	//void Update(){
	//	if (player.GetComponent<PlayerController> ().isDead) {
	//		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	//	}
	//}

	protected override Vector3 GetScrollDirection()
	{
		return scrollVelocity.normalized;
	}

	protected Vector3 GetInitialGenerationPosition()
	{
		Vector3 objectPosition = Camera.main.ViewportToWorldPoint (
			new Vector3(viewportOffset.x, 0f)
		                         );
		objectPosition.z = 0f;
		return objectPosition;
	}

	protected override Transform GenerateObject(Vector3 localPosition)
	{
		Transform levelChunk = chunkSelection.GenerateChunk ();
		levelChunk.parent = transform;

		levelChunk.localPosition = localPosition -
			new Vector3 (0.5f * scrollingObjectPrefab.size.x, 0f, 0f);
		// Gera prefabs dinamicamente
		levelChunk.GetComponent<NestedPrefab> ().GeneratePrefabs ();
		// Gera o proximo chunk
		chunkSelection.SelectChunk();

		return levelChunk;
	}






}
