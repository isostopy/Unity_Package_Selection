using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Resalta un <see cref="Selectable"/> activando un objeto y luego a ese objeto se le intercambian los materiales.
	///	<para></para> Es decir:
	///	<br/> Al hacer hover o seleccionar el Selectable se activa un game object.
	///	<br/> A ese game object se le intercambian los materiales para mostrar si esta haciendo hover o seleccionando el Selectable.
	///	<br/> Si no se esta haciendo hover ni esta seleccionado el Selectable, ese game object esta desactivado.
	/// </summary>

    public class HighlightObject : Highlight
    {

        [SerializeField] protected HighlightMaterialData selectionMaterials;
        [SerializeField] GameObject mesh;
        Material defaultMaterial;


        private void Start()
        {
            rendererComponent = mesh.GetComponent<Renderer>();
            defaultMaterial = rendererComponent.material;

			mesh.SetActive(false);
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

        override protected void Select(PointerInteractable selectable)
        {
            base.Select(selectable);

            if ((selectable as Selectable).isSelected)
            {
                ShowMesh(true);
            }

            SetDefaultMaterial();
        }

        override protected void Deselect(PointerInteractable selectable)
        {
            base.Deselect(selectable);
            ShowMesh(false);
        }

        override protected void HoverEnter(PointerInteractable selectable)
        {
            base.HoverEnter(selectable);
            if (!useHover) return;

            ShowMesh(true);
            SetMaterial(selectionMaterials.hoverMaterial);
        }

        override protected void HoverExit(PointerInteractable selectable)
        {
            base.HoverExit(selectable);
            if (!useHover) return;

            if ((selectable as Selectable).isSelected)
            {
                SetDefaultMaterial();
            } 
            else
            {
                ShowMesh(false);
            }
             
        }

        #endregion

    }

}