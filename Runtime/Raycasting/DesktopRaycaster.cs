using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary> Raycaster que lanza el rayo a la posicion del raton. </summary>
	
	/* Para esto probableme es mejor simplemente añadir el componente de Unity PhysicsRaycaster a la camara,
	 *		y dejar que todo funcione con los sistemas por defecto del motor.
			Pero es un buen ejemplo de como montar una clase heredando del Raycaster que incluye el paquete. */

	public class DesktopRaycaster : Raycaster
	{
		[Space]
		public int maxDistance = 100;
		public LayerMask layerMask = Physics.AllLayers;


		// ----------------------------------------------------------------------------

		protected override GameObject Raycast()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
			{
				return hit.transform.gameObject;
			}

			return null;
		}

		protected override bool IsButtonPressed()
		{
			return Input.GetKey(KeyCode.Mouse0);

			/* Esto esta utilizando el input system antiguo, en el nuevo seria algo como:
			 *		InputSystem.Mouse.current.leftButton.isPressed */
		}
	}
}
