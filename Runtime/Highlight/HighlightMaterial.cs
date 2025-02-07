using System.Collections.Generic;
using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Resalta un <see cref="Selectable"/> intercambiando materiales. </summary>

    public class HighlightMaterial : Highlight
    {
        [SerializeField] protected HighlightMaterialData selectionMaterials;
        Material[] defaultMaterials;


		// ----------------------------------------------------------------------------

		private void Start()
        {
            rendererComponent = GetComponent<Renderer>();
            defaultMaterials = rendererComponent.materials;
        }


		// ----------------------------------------------------------------------------

		private void SetDefaultMaterials()
        {
            rendererComponent.materials = defaultMaterials;
        }

        private void SetMaterial(Material material)
        {
            List<Material> unicMaterialList = new List<Material>();

            foreach (Material mat in defaultMaterials)
            {
                unicMaterialList.Add(material);
            }

            rendererComponent.materials = unicMaterialList.ToArray();

        }


		// ----------------------------------------------------------------------------
		#region Binded Functions

		override protected void Select(PointerInteractable selectable)
        {
            base.Select(selectable);
            SetMaterial(selectionMaterials.selectedMaterial);
        }

        override protected void Deselect(PointerInteractable selectable)
        {
            base.Deselect(selectable);
            SetDefaultMaterials();
        }

        override protected void HoverEnter(PointerInteractable selectable)
        {
            base.HoverEnter(selectable);
            if (!useHover) return;

            SetMaterial(selectionMaterials.hoverMaterial);
        }

        override protected void HoverExit(PointerInteractable selectable)
        {
            base.HoverExit(selectable);
            if (!useHover) return;

            if ((selectable as Selectable).isSelected)
            {
                SetMaterial(selectionMaterials.selectedMaterial);
            }
            else
            {
                SetDefaultMaterials();
            }
        }

		#endregion
	}
}
