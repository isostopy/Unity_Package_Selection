using System.Collections.Generic;
using UnityEngine;

namespace Isostopy.Selection
{
    public class Highlightable : MonoBehaviour
    {
        [SerializeField] SelectionMaterials selectionMaterials;

        Material[] defaultMaterials;
        Renderer rendererComponent;
        Selectable selectable;

        #region Subscription Management

        private void OnEnable()
        {
            selectable = GetComponent<Selectable>();

            selectable.OnSelect += Select;
            selectable.OnDeselect += Deselect;
            selectable.OnHoverEnter += HoverEnter;
            selectable.OnHoverExit += HoverExit;

        }

        private void OnDisable()
        {
            selectable.OnSelect -= Select;
            selectable.OnDeselect -= Deselect;
            selectable.OnHoverEnter -= HoverEnter;
            selectable.OnHoverExit -= HoverExit;
        }

        #endregion

        private void Start()
        {
            rendererComponent = GetComponent<Renderer>();
            defaultMaterials = rendererComponent.materials;
        }

        public void SetDefaultMaterials()
        {
            rendererComponent.materials = defaultMaterials;
        }

        public void SetMaterial(Material material)
        {
            List<Material> unicMaterialList = new List<Material>();

            foreach (Material mat in defaultMaterials)
            {
                unicMaterialList.Add(material);
            }

            rendererComponent.materials = unicMaterialList.ToArray();

        }

        private void Select(Selectable selectable)
        {
            SetMaterial(selectionMaterials.selectedMaterial);
        }

        private void Deselect(Selectable selectable)
        {
            SetDefaultMaterials();
        }

        private void HoverEnter(Selectable selectable)
        {
            SetMaterial(selectionMaterials.hoverMaterial);
        }

        private void HoverExit(Selectable selectable)
        {
            if (selectable.isSelected)
            {
                SetMaterial(selectionMaterials.selectedMaterial);
            }
            else
            {
                SetDefaultMaterials();
            }
        }

    }

}