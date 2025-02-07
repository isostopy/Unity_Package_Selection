using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Clase base para lanzar rayacast y disparar las funciones de un <see cref="PointerInteractable"/>. </summary>
	public abstract class Raycaster : MonoBehaviour
	{
		private PointerInteractable hoveringObject = null;

		private PointerInteractable pressedObject = null;
		protected bool isPressing { get; private set; }

		/* TO DO:
		 *		- Esto solo permite que haya un unico componente PointerInteractable por objeto.
		 *			quiza lo suyo seria permitir que en un mismo objeto haya todos los que hagan falta y todos reciban los eventos al apuntar a su game object. */


		// ----------------------------------------------------------------------------

		private void Update()
		{
			// Hover
			var newHoveringObject = Raycast();
			if (newHoveringObject != hoveringObject)
			{
				if (hoveringObject != null) { hoveringObject.HoverExit(); }
				hoveringObject = newHoveringObject;
				if (hoveringObject != null) { hoveringObject.HoverEnter(); }
			}

			// Press
			var wasPressing = isPressing;
			isPressing = IsButtonPressed();

			if (isPressing == true && wasPressing == false)
			{
				pressedObject = hoveringObject;
				if (pressedObject != null) { pressedObject.PressDown(); }
			}
			if (isPressing == false && wasPressing == true)
			{
				if (pressedObject != null)
				{
					pressedObject.PressUp();

					// Click
					if (pressedObject == hoveringObject)
						pressedObject.Click();
				}
				pressedObject = null;
			}
		}


		// ----------------------------------------------------------------------------

		/// <summary> Devuelve el PointerInteractable al que se esta apuntando. </summary>
		protected abstract PointerInteractable Raycast();

		/// <summary> Inidica si se esta pulsando el boton con el que se hace click. </summary>
		protected abstract bool IsButtonPressed();
	}
}