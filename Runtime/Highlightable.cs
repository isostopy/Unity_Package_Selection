using System.Collections.Generic;
using UnityEngine;

namespace Isostopy.Selection
{
    public class Highlightable : MonoBehaviour
    {
        [SerializeField] protected SelectionMaterials selectionMaterials;

        Material[] defaultMaterials;
        protected Renderer rendererComponent;
        protected Selectable selectable;

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

        protected virtual void Select(Selectable selectable)
        {
            SetMaterial(selectionMaterials.selectedMaterial);
        }

        protected virtual void Deselect(Selectable selectable)
        {
            SetDefaultMaterials();
        }

        protected virtual void HoverEnter(Selectable selectable)
        {
            SetMaterial(selectionMaterials.hoverMaterial);
        }

        protected virtual void HoverExit(Selectable selectable)
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

        #endregion

    }

}