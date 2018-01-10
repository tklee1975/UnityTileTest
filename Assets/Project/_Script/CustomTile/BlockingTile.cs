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
public class BlockingTile : TileBase {
	public Color customColor = Color.red;
	public Sprite sprite = null;

	public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
	{
		tileData.transform = Matrix4x4.identity;
		tileData.color = customColor;				// the main input 
		tileData.sprite = sprite; 	// Sprite.Create(Texture2D.whiteTexture, Rect.MinMaxRect(0, 0, 4, 4), new Vector2(0.5f, 0.5f), 1);				// manadatory to show something 
		tileData.flags = TileFlags.LockAll;		// need to make the tiled filled with a color 
		tileData.colliderType = Tile.ColliderType.Grid;

		//Debug.Log ("TileMap: " + InfoTileMap (tileMap));
		//Debug.Log ("  Tile: " + InfoTile (location, tileMap, tileData));
	}


	#if UNITY_EDITOR
	[MenuItem("Assets/Custom Tile/BlockingTile")]
	public static void CreateTile()
	{
		string path = EditorUtility.SaveFilePanelInProject("Save BlockingTile",
			"BlockingTile", "asset", "Save BlockingTile", "Assets");
		if (path == "") {
			return;
		}

		AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<BlockingTile>(), path);
	}
	#endif
}
