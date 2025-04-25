using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Clase base de los componentes que dan feedback al usuario cuando interactua con un <see cref="PointerInteractable"/>. </summary>

	[RequireComponent(typeof (PointerInteractable))]
    public abstract class Highlight : MonoBehaviour
    {
		/// <summary> El objeto que resalta este highlight. </summary>
        protected PointerInteractable interactable { get; private set; }

		protected bool isHovering { get; private set; }
		protected bool isPressed { get; private set; }
		protected bool isSelected { get; private set; }


		// ----------------------------------------------------------------------------

		protected virtual void Awake()
		{
            interactable = GetComponent<Selectable>();
		}

		protected virtual void OnEnable()
        {
            interactable.onEnter.AddListener(OnPointerEnter);
            interactable.onExit.AddListener(OnPointerExit);
			interactable.onDown.AddListener(OnPointerDown);
			interactable.onUp.AddListener(OnPointerUp);

			if (interactable is Selectable)
			{
				var selectable = interactable as Selectable;
				selectable.onSelected.AddListener(OnSelect);
				selectable.onDeselected.AddListener(OnDeselect); 
			}
		}

		protected virtual void OnDisable()
        {
            interactable.onEnter.RemoveListener(OnPointerEnter);
            interactable.onExit.RemoveListener(OnPointerExit);
			interactable.onDown.RemoveListener(OnPointerDown);
			interactable.onUp.RemoveListener(OnPointerUp);

			if (interactable is Selectable)
			{
				var selectable = interactable as Selectable;
				selectable.onSelected.RemoveListener(OnSelect);
				selectable.onDeselected.RemoveListener(OnDeselect);
			}
		}


		// ----------------------------------------------------------------------------

		private void OnPointerEnter(PointerInteractable thisInteractable)
		{
			isHovering = true;
			ShowAsHover();
		}

		private void OnPointerExit(PointerInteractable thisInteractable)
		{
			isHovering = false;
			if (isSelected == false)
				ShowAsNormal();
			else
				ShowAsSelected();
		}

		// -----

		private void OnPointerDown(PointerInteractable thisInteractable)
		{
			isPressed = true;
			ShowAsPressed();
		}

		private void OnPointerUp(PointerInteractable thisInteractable)
		{
			isPressed = false;

			if (isSelected)
				ShowAsSelected();
			else if (isHovering)
				ShowAsHover();
			else
				ShowAsNormal();
		}

		// -----

		private void OnSelect(Selectable thisSelectable)
		{
			isSelected = true;
			ShowAsSelected();
		}

		private void OnDeselect(Selectable thisSelectable)
		{
			isSelected = false;
			if (isHovering)
				ShowAsHover();
			else
				ShowAsNormal();
		}


		// ----------------------------------------------------------------------------

		protected abstract void ShowAsNormal();
		protected virtual void ShowAsHover() { }
		protected virtual void ShowAsPressed() { }
		protected virtual void ShowAsSelected() { }
	}
}
