using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Componente base con las funciones basicas con las que interactua el puntero. </summary>

	[AddComponentMenu("Isostopy/Selection/Pointer Interactable")]
	public class PointerInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
	{
		[HideInInspector] public UnityEvent<PointerInteractable> onEnter = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onExit = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onDown = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onUp = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onClick = new();


		// ----------------------------------------------------------------------------

		public void OnPointerEnter(PointerEventData eventData = null)
		{
			OnEnter();
			onEnter.Invoke(this);
		}
		protected virtual void OnEnter() { }

		// -----

		public void OnPointerExit(PointerEventData eventData = null)
		{
			OnExit();
			onExit.Invoke(this);
		}
		protected virtual void OnExit() { }

		// -----

		public void OnPointerDown(PointerEventData eventData = null)
		{
			OnDown();
			onDown.Invoke(this);
		}
		protected virtual void OnDown() { }

		// -----

		public void OnPointerUp(PointerEventData eventData = null)	
		{
			OnUp();
			onUp.Invoke(this);
		}
		protected virtual void OnUp() { }

		// -----

		public void OnPointerClick(PointerEventData eventData = null)	
		{
			OnClick();
			onClick.Invoke(this);
		}
		protected virtual void OnClick() { }
	}
}
