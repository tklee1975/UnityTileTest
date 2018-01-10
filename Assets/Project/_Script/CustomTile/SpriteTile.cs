using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

//

//public virtual Color GetColor (Vector3Int position);
//public virtual Sprite GetSprite (Vector3Int position);
//public virtual TileFlags GetTileFlags (Vector3Int position);
//public virtual Matrix4x4 GetTransformMatrix (Vector3Int position);


[Serializable]
public class SpriteTile : TileBase {
	public Sprite customSprite;
	public float rotateAngle = 0;	// Degree

	public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
	{
		//tileData.transform = tileMap.GetTransformMatrix (location);	// Matrix4x4.identity;
		tileData.sprite = customSprite;


		// Rotation Matrix 
		Matrix4x4 mat = Matrix4x4.identity;
		float rotateRad = rotateAngle * Mathf.Deg2Rad;
		mat.SetColumn(0, new Vector4(Mathf.Cos(rotateRad), Mathf.Sin(rotateRad), 0, 0));
		mat.SetColumn(1, new Vector4(-Mathf.Sin(rotateRad), Mathf.Cos(rotateRad), 0, 0));
		//mat.SetColumn (3, new Vector4 (x, y, 0, 1));
		//mat.set
		tileData.transform = mat;
		tileData.colliderType = Tile.ColliderType.Grid;

		tileData.flags = TileFlags.LockAll;
		//SetTRS (transform, Quaternion.identity, Vector3.Normalize);
	}


	#if UNITY_EDITOR
	[MenuItem("Assets/Custom Tile/Sprite Tile")]
	public static void CreateTile()
	{
		string path = EditorUtility.SaveFilePanelInProject("Save SpriteTile",
			"SpriteTile", "asset", "Save Tile", "Assets");
		if (path == "") {
			return;
		}

		AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SpriteTile>(), path);
	}
	#endif
}
