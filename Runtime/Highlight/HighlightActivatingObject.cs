using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Resalta activando un objeto y luego a ese objeto se le intercambian los materiales.
	///	<para></para> Es decir:
	///	<br/> Al hacer hover o seleccionar el Selectable se activa un game object.
	///	<br/> A ese game object se le intercambian los materiales para mostrar si esta haciendo hover o seleccionando el Selectable.
	///	<br/> Si no se esta haciendo hover ni esta seleccionado el Selectable, ese game object esta desactivado.
	/// </summary>

    public class HighlightActivatingObject : Highlight
    {
		Renderer rendererComponent = null;

        [SerializeField] HighlightMaterialData selectionMaterials;
        [SerializeField] GameObject mesh;


		// ----------------------------------------------------------------------------

		private void Start()
        {
            rendererComponent = mesh.GetComponent<Renderer>();

			ShowMesh(false);
        }


		// ----------------------------------------------------------------------------

		protected override void ShowAsNormal()
		{
			ShowMesh(false);
		}

		protected override void ShowAsHover()
		{
			ShowMesh(true);
			SetMaterial(selectionMaterials.hoverMaterial);
		}

		protected override void ShowAsSelected()
		{
			ShowMesh(true);
			SetMaterial(selectionMaterials.selectedMaterial);
		}


		// ----------------------------------------------------------------------------

		void ShowMesh(bool value)
		{
			mesh.SetActive(value);
		}

		void SetMaterial(Material material)
		{
			rendererComponent.material = material;
		}
	}

}