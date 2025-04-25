using UnityEngine;
using UnityEngine.EventSystems;

namespace Isostopy.Selection
{
	/// <summary>
	/// Clase base para lanzar rayacast y disparar las funciones de un <see cref="PointerInteractable"/>. </summary>

	public abstract class Raycaster : MonoBehaviour
	{
		private GameObject hoveringObject = null;

		private GameObject pressedObject = null;
		protected bool isPressing { get; private set; }


		// ----------------------------------------------------------------------------

		private void Update()
		{
			// Hover
			var newHoveringObject = Raycast();
			if (newHoveringObject != hoveringObject)
			{
				ExitPrevHover();
				EnterNewHover(newHoveringObject);
			}

			// Press
			var wasPressing = isPressing;
			isPressing = IsButtonPressed();

			var wasPressedThisFrame = isPressing == true && wasPressing == false;
			var wasReleaseThisFrame = isPressing == false && wasPressing == true;

			if (wasPressedThisFrame)
			{
				PressDown(hoveringObject);
			}
			if (wasReleaseThisFrame)
			{
				PressUp();
			}
		}

		// -----

		private void ExitPrevHover()
		{
			if (hoveringObject == null)
				return;

			var interactables = hoveringObject.GetComponents<IPointerExitHandler>();
			foreach(var interactable in interactables)
			{
				interactable.OnPointerExit(null);
			}

			hoveringObject = null;
		}

		private void EnterNewHover(GameObject newHoveringObject)
		{
			hoveringObject = newHoveringObject;
			if (hoveringObject == null)
				return;

			var interactables = hoveringObject.GetComponents<IPointerEnterHandler>();
			foreach (var interactable in interactables)
			{
				interactable.OnPointerEnter(null);
			}
		}

		// -----

		private void PressDown(GameObject newPressingObject)
		{
			pressedObject = newPressingObject;
			if (pressedObject == null)
				return;

			var interactables = hoveringObject.GetComponents<IPointerDownHandler>();
			foreach (var interactable in interactables)
			{
				interactable.OnPointerDown(null);
			}
		}

		private void PressUp()
		{
			if (pressedObject == null)
				return;

			var interactables = pressedObject.GetComponents<IPointerUpHandler>();
			foreach (var interactable in interactables)
			{
				interactable.OnPointerUp(null);
			}

			// Click
			if (pressedObject == hoveringObject)
				Click(pressedObject);

			pressedObject = null;
		}

		// -----

		private void Click(GameObject objectToClick)
		{
			var interactables = objectToClick.GetComponents<IPointerClickHandler>();
			foreach (var interactable in interactables)
			{
				interactable.OnPointerClick(null);
			}
		}


		// ----------------------------------------------------------------------------

		/// <summary> Devuelve el GameObject al que se esta apuntando. </summary>
		protected abstract GameObject Raycast();

		/// <summary> Indica si se esta pulsando el boton con el que se hace click. </summary>
		protected abstract bool IsButtonPressed();
	}
}