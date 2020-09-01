using Hex.Paths;
using HexUN.Data;
using System;
using UnityEditor;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Sync Sprite args based on convention
    /// </summary>
    public static class EMSyncSpriteArgs
    {
        [MenuItem("Hex/UX/SyncSpriteArgs")]
        public static void SyncSpriteArgs()
        {
            // get paths to Sprite args
            string[] guids = AssetDatabase.FindAssets($"t:{nameof(SpriteArgs)}");

            foreach(string guid in guids)
            {
                PathString path = AssetDatabase.GUIDToAssetPath(guid);
                SpriteArgs args =  AssetDatabase.LoadAssetAtPath<SpriteArgs>(path);

                string head = path.RelativeTo("So").ToString('/', false);
                UnityPath spritePath = "Assets/Art/Sprites/" + head + ".png";

                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath.AssetDatabaseAssetPath);
                if (sprite != null) args.Sprite = sprite;
            }

            AssetDatabase.Refresh();
        }
    }
}