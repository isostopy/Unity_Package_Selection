using UnityEngine;

namespace Isostopy.Selection
{
    public class HighlightableMesh : Highlightable
    {

        [SerializeField] GameObject mesh;
        Material defaultMaterial;


        private void Start()
        {
            rendererComponent = mesh.GetComponent<Renderer>();
            defaultMaterial = rendererComponent.material;
        }

        private void ShowMesh(bool value)
        {
            mesh.SetActive(value);
        }

        private void SetDefaultMaterial()
        {
            rendererComponent.material = defaultMaterial;
        }

        private void SetMaterial(Material material)
        {
            rendererComponent.material = material;
        }

        #region Binded Functions

        override protected void Select(Selectable selectable)
        {
            if (selectable.isSelected)
            {
                ShowMesh(true);
            }

            SetDefaultMaterial();
        }

        override protected void Deselect(Selectable selectable)
        {
            ShowMesh(false);
        }

        override protected void HoverEnter(Selectable selectable)
        {
            SetMaterial(selectionMaterials.hoverMaterial);
        }

        override protected void HoverExit(Selectable selectable)
        {
            SetDefaultMaterial();   
        }

        #endregion

    }

}