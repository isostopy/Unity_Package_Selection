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
            selectable.onThisSelected.AddListener(Select);
            selectable.onThisDeselected.AddListener(Deselect);
            selectable.onEnter.AddListener(HoverEnter);
            selectable.onExit.AddListener(HoverExit);
        }

		protected virtual void OnDisable()
        {
            selectable.onThisSelected.RemoveListener(Select);
            selectable.onThisDeselected.RemoveListener(Deselect);
            selectable.onEnter.RemoveListener(HoverEnter);
            selectable.onExit.RemoveListener(HoverExit);
        }

		#endregion


		// ----------------------------------------------------------------------------
		#region Binded Functions

		protected virtual void HoverEnter(PointerInteractable selectable) { }

		protected virtual void HoverExit(PointerInteractable selectable) { }

		protected virtual void Select(PointerInteractable selectable) { }

        protected virtual void Deselect(PointerInteractable selectable) { }

        #endregion
    }


	// ================================================================================




}