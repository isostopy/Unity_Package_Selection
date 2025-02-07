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

		protected override PointerInteractable Raycast()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
			{
				var interactable = hit.collider.GetComponent<PointerInteractable>();
				if (interactable != null)
					return interactable;
			}

			return null;
		}

		protected override bool IsButtonPressed()
		{
			return Input.GetKey(KeyCode.Mouse0);
		}
	}
}
