using System.Collections.Generic;
using UnityEngine;

namespace TileGlow
{
    public class TileGlowMaterial : Material
    {
        public Texture SpriteTexture => mainTexture;
        public bool DrawOutside => IsKeywordEnabled(outsideMaterialKeyword); 
        public bool InstancingEnabled => enableInstancing;

        private const string outlineShaderName = "Sprites/Outline";
        private const string outsideMaterialKeyword = "SPRITE_OUTLINE_OUTSIDE";

        private static readonly Shader outlineShader = Shader.Find(outlineShaderName);
        private static readonly List<TileGlowMaterial> sharedMaterials = new List<TileGlowMaterial>();

        public TileGlowMaterial (Texture spriteTexture, bool drawOutside = false, bool instancingEnabled = false)
            : base(outlineShader)
        {
            if (!outlineShader) Debug.LogError($"`{outlineShaderName}` shader not found. Make sure the shader is included to the build.");

            mainTexture = spriteTexture;
            if (drawOutside) EnableKeyword(outsideMaterialKeyword);
            if (instancingEnabled) enableInstancing = true;
        }

        public static Material GetSharedFor (TileGlowEffect spriteGlow)
        {
            for (int i = 0; i < sharedMaterials.Count; i++)
            {
                if (
                    sharedMaterials[i].DrawOutside == spriteGlow.DrawOutside &&
                    sharedMaterials[i].InstancingEnabled == spriteGlow.EnableInstancing)
                    return sharedMaterials[i];
            }
            //sharedMaterials[i].SpriteTexture == Renderer.sprite.texture &&
            var material = new TileGlowMaterial(spriteGlow.Tile.sprite.texture, spriteGlow.DrawOutside, spriteGlow.EnableInstancing);
            material.hideFlags = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor | HideFlags.NotEditable;
            sharedMaterials.Add(material);

            return material;
        }
    }
}
