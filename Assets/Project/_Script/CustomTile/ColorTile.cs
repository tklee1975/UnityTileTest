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
public class ColorTile : TileBase {
	public Color customColor = Color.black;
	public Sprite customSprite;

	public string InfoTileMap(ITilemap tileMap) {
		string info = "";

		info += "cellBound=" + tileMap.cellBounds;
		info += " localBounds=" + tileMap.localBounds;
		info += " origin=" + tileMap.origin;
		info += " size=" + tileMap.size;

		return info;
	}

	public string InfoTile(Vector3Int location, ITilemap tileMap, TileData tileData) {
		string info = "";

		info += "location=" + location;
		info += " color=" + tileMap.GetColor(location);
		info += " sprite=" + tileMap.GetSprite(location);
		info += " TileFlag=" + tileMap.GetTileFlags(location);
		info += " transform=" + tileMap.GetTransformMatrix(location);

		return info;
	}

	public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
	{
		tileData.transform = Matrix4x4.identity;
		tileData.color = customColor;				// the main input 
		tileData.sprite = customSprite;				// manadatory to show something 
		tileData.flags = TileFlags.LockColor;		// need to make the tiled filled with a color 

		//Debug.Log ("TileMap: " + InfoTileMap (tileMap));
		//Debug.Log ("  Tile: " + InfoTile (location, tileMap, tileData));
	}


	#if UNITY_EDITOR
	[MenuItem("Assets/Custom Tile/Color Tile")]
	public static void CreateColorTile()
	{
		string path = EditorUtility.SaveFilePanelInProject("Save ColorTile",
						"ColorTile", "asset", "Save ColorTile", "Assets");
		if (path == "") {
			return;
		}

		AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<ColorTile>(), path);
	}
	#endif
}
