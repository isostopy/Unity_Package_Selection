using UnityEngine;
using UnityEngine.EventSystems;

namespace Isostopy.Selection
{
	/// <summary>
	/// Un PointerInteractable que funciona con las interfaces que utiliza Unity por defecto para detectar eventos del puntero. </summary>

	[AddComponentMenu("Isostopy/Selection/Unity Pointer Interactable")]
	public class UnityPointerInteractable : PointerInteractable, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
	{
		public void OnPointerEnter(PointerEventData eventData) => HoverEnter();

		public void OnPointerExit(PointerEventData eventData) => HoverExit();

		public void OnPointerDown(PointerEventData eventData) => PressDown();

		public void OnPointerUp(PointerEventData eventData) => PressUp();

		public void OnPointerClick(PointerEventData eventData) => Click();
	}
}
