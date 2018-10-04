using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fjord.Common.Extensions;

namespace Fjord.Common.Utilities
{
    public static class MaterialUtility
    {
        public static void SetAlphaAndSwitchShader(Material material, float alpha)
        {
            material.color = material.color.ChangeAlpha(alpha);
            if (alpha < 1)
            {
                material.shader = Shader.Find("Fjord/StandardFadeZPrime");
            }
            else
            {
                material.shader = Shader.Find("Standard");
            }
        }
        
        public static void SetAlphaAndSwitchShaderDepthFade(Material material, float alpha)
        {
            material.color = material.color.ChangeAlpha(alpha);
            if (alpha < 1)
            {
                material.shader = Shader.Find("Fjord/StandardDepthFade");
            }
            else
            {
                material.shader = Shader.Find("Standard");
            }
        }
    }
}