using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Clase base de los componentes que dan feedback al usuario cuando se selecciona o hace hover un <see cref="Selectable"/>. </summary>

	[RequireComponent(typeof (Selectable))]
    public abstract class Highlight : MonoBehaviour
    {
        protected Selectable selectable;

		// Cosas que este componente no utiliza, pero alguno de sus herederos si.
		// TO DO: Sus herederos no tienen por que usarlas, pero aun asi estan aqui definidas. Por eso lo suyo quiza seria que no estuvieran aqui, si no en sus hijos.
        public bool useHover = true;
        protected Renderer rendererComponent;


		// ----------------------------------------------------------------------------
		#region Subscription Management

		protected virtual void Awake()
		{
            selectable = GetComponent<Selectable>();
		}

		protected virtual void OnEnable()
        {
            selectable.OnSelect.AddListener(Select);
            selectable.OnDeselect.AddListener(Deselect);
            selectable.OnHoverEnter.AddListener(HoverEnter);
            selectable.OnHoverExit.AddListener(HoverExit);
        }

		protected virtual void OnDisable()
        {
            selectable.OnSelect.RemoveListener(Select);
            selectable.OnDeselect.RemoveListener(Deselect);
            selectable.OnHoverEnter.RemoveListener(HoverEnter);
            selectable.OnHoverExit.RemoveListener(HoverExit);
        }

		#endregion


		// ----------------------------------------------------------------------------
		#region Binded Functions

		protected virtual void HoverEnter(Selectable selectable) { }

		protected virtual void HoverExit(Selectable selectable) { }

		protected virtual void Select(Selectable selectable) { }

        protected virtual void Deselect(Selectable selectable) { }

        #endregion

    }


	// ============================================================================

	[CreateAssetMenu(fileName = "SelectionMaterials", menuName = "Scriptable Objects/SelectionMaterials")]
	public class SelectionMaterials : ScriptableObject
	{
		public Material hoverMaterial;
		public Material selectedMaterial;
	}

	[CreateAssetMenu(fileName = "SelectionColors", menuName = "Scriptable Objects/SelectionColors")]
	public class SelectionColors : ScriptableObject
	{
		public Color hoverColor;
		public Color selectedColor;
	}
}