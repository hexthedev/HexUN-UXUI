using HexCS.Core;
using HexUN.Data;
using System;
using System.Reflection;
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

            Type spriteArgsType = typeof(SpriteArgs);
            Type spriteType = typeof(Sprite);

            foreach (string guid in guids)
            {
                PathString path = AssetDatabase.GUIDToAssetPath(guid);
                SpriteArgs args =  AssetDatabase.LoadAssetAtPath<SpriteArgs>(path);

                string head = path.RelativeTo("So").ToString('/', false);

                foreach (FieldInfo f in spriteArgsType.GetFields())
                {
                    if (f.FieldType != spriteType) continue;

                    UnityPath spritePath = "Assets/Art/Sprites/" + head + $"@{f.Name}.png";

                    Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath.AssetDatabaseAssetPath);
                    if (sprite != null) f.SetValue(args, sprite);
                }
            }

            AssetDatabase.Refresh();
        }
    }
}