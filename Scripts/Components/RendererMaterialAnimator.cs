using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
    /// <summary>
    /// Class to aid in the animating of material values on MeshRenderer or SkinnedMeshRenderer
    /// via keyframes. This is done in this wonky way because you cannot put keyframes on an array
    /// and you cannot put keyframes on seperate components of the same type on a GameObject.
    /// </summary>
    public class RendererMaterialAnimator : MonoBehaviour
    {
        [Tooltip("Use only when necessary, will leak materials into editor.")] //TODO is there way around the material leaking in the editor?
        [SerializeField]
        private bool _runInEditMode;

        //Yes you really have type out a seperate name for each serializable field you want
        //to put a keyframe on. This is true as of Unity 2017.2.0f3. This could be made fancier
        //by using reflection to collect the Serializable field names into an array.
        [SerializeField]
        private Color _color0;

        [SerializeField]
        private Color _color1;

        [SerializeField]
        private Color _color2;

        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        public void Update()
        {
            if (_renderer.materials.Length > 0)
                _renderer.materials[0].color = _color0;
            if (_renderer.materials.Length > 1)
                _renderer.materials[1].color = _color1;
            if (_renderer.materials.Length > 2)
                _renderer.materials[2].color = _color2;
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying && _runInEditMode)
            {
                if (GetComponent<Renderer>().materials.Length > 0)
                    GetComponent<Renderer>().materials[0].color = _color0;
                if (GetComponent<Renderer>().materials.Length > 1)
                    GetComponent<Renderer>().materials[1].color = _color1;
                if (GetComponent<Renderer>().materials.Length > 2)
                    GetComponent<Renderer>().materials[2].color = _color2;
            }
        }
    }
}