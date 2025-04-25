using System.Collections.Generic;
using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Resalta intercambiando materiales. </summary>

    public class HighlightSwappingMaterial : Highlight
    {
		Renderer rendererComponent = null;

        [SerializeField] protected HighlightMaterialData selectionMaterials;
        Material[] defaultMaterials;


		// ----------------------------------------------------------------------------

		private void Start()
        {
            rendererComponent = GetComponent<Renderer>();
            defaultMaterials = rendererComponent.materials;
        }


		// ----------------------------------------------------------------------------

		protected override void ShowAsNormal()
		{
			SetDefaultMaterials();
		}

		protected override void ShowAsHover()
		{
			SetMaterial(selectionMaterials.hoverMaterial);
		}

		protected override void ShowAsPressed()
		{
			SetMaterial(selectionMaterials.pressedMaterial);
		}

		protected override void ShowAsSelected()
		{
			SetMaterial(selectionMaterials.selectedMaterial);
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
	}

}
