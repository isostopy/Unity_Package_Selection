using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary> Raycaster que lanza el rayo a la posicion del raton. </summary>

	[AddComponentMenu("Isostopy/Selection/Desktop Raycaster")] 
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

			/* TO DO: Esto esta utilizando el input system antiguo, en el nuevo seria algo como:
			 *		InputSystem.Mouse.current.leftButton.isPressed */
		}
	}
}
