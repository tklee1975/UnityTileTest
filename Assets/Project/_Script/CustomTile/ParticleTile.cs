using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

//

[Serializable]
public class ParticleTile : TileBase {
	public GameObject particlePrefab;
	public Sprite previewSprite;

	public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
	{
		//tileData.transform = tileMap.GetTransformMatrix (location);	// Matrix4x4.identity;
		tileData.gameObject = null;	// particlePrefab;
		tileData.sprite = previewSprite;
		tileData.flags = TileFlags.InstantiateGameObjectRuntimeOnly;

	}

	public override bool StartUp(Vector3Int location, ITilemap tilemap, GameObject go)
	{
		if (go == null) {
			return false;
		}
//		// this.hideFlags = HideFlags.HideInHierarchy;
//		Transform tf = go.transform;
//		Vector3 euler = tf.eulerAngles;
//		euler.x = -90;
//
//
//		Vector3 tileSize = tilemap.size;
//

//		Debug.Log ("ParticleTile.StartUp: center=" + tileSize + " go.position=" + go.transform.position);
//
//		//go.transform.eulerAngles = euler;
//
//		Vector3 position = go.transform.position;
//
//		float delta = 0.16f * 3 / 2;
//
//		position += new Vector3 (delta, delta, -1.1f);
//
//		go.transform.position = position;
//
		//
		//tile.previewSprite = null;
		//tile.RefreshTile (location, tilemap);

		return base.StartUp (location, tilemap, go);
	}



	#if UNITY_EDITOR
	[MenuItem("Assets/Custom Tile/ParticleTile")]
	public static void CreateTile()
	{
		string path = EditorUtility.SaveFilePanelInProject("Save ParticleTile",
			"ParticleTile", "asset", "Save Tile", "Assets");
		if (path == "") {
			return;
		}

		AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<ParticleTile>(), path);
	}
	#endif
}
