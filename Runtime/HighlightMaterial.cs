using System.Collections.Generic;
using UnityEngine;

namespace Isostopy.Selection
{
    public class HighlightMaterial : Highlight
    {

        [SerializeField] protected SelectionMaterials selectionMaterials;
        Material[] defaultMaterials;

        private void Start()
        {
            rendererComponent = GetComponent<Renderer>();
            defaultMaterials = rendererComponent.materials;
        }

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

        #region Binded Functions

        override protected void Select(Selectable selectable)
        {
            base.Select(selectable);
            SetMaterial(selectionMaterials.selectedMaterial);
        }

        override protected void Deselect(Selectable selectable)
        {
            base.Deselect(selectable);
            SetDefaultMaterials();
        }

        override protected void HoverEnter(Selectable selectable)
        {
            base.HoverEnter(selectable);
            if (!useHover) return;

            SetMaterial(selectionMaterials.hoverMaterial);
        }

        override protected void HoverExit(Selectable selectable)
        {
            base.HoverExit(selectable);
            if (!useHover) return;

            if (selectable.isSelected)
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