using UnityEngine;
using UnityEngine.EventSystems;

namespace Isostopy.Selection
{
	/// <summary>
	/// Componente que pasa los eventos del puntero de Unity al <see cref="PointerInteractable"/> de Isostopy. </summary>

	[RequireComponent(typeof(PointerInteractable))]
	public class UnityToIsostopyInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
	{
		private PointerInteractable interactable = null;

		private void Start()
		{
			interactable = GetComponent<PointerInteractable>();
		}


		// ----------------------------------------------------------------------------

		public void OnPointerEnter(PointerEventData eventData)
		{
			interactable.OnPointerEnter();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			interactable.OnPointerExit();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			interactable.OnPointerDown();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			interactable.OnPointerUp();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			interactable.OnPointerClick();
		}
	}
}