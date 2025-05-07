using UnityEngine;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Componente con las funciones basicas con las que interactua el puntero. </summary>

	[AddComponentMenu("Isostopy/Selection/Pointer Interactable")]
	public class PointerInteractable : MonoBehaviour
	{
		[HideInInspector] public UnityEvent<PointerInteractable> onEnter = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onExit = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onDown = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onUp = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onClick = new();


		// ----------------------------------------------------------------------------

		public void OnPointerEnter()
		{
			OnEnter();
			onEnter.Invoke(this);
		}
		protected virtual void OnEnter() { }

		// -----

		public void OnPointerExit()
		{
			OnExit();
			onExit.Invoke(this);
		}
		protected virtual void OnExit() { }

		// -----

		public void OnPointerDown()
		{
			OnDown();
			onDown.Invoke(this);
		}
		protected virtual void OnDown() { }

		// -----

		public void OnPointerUp()	
		{
			OnUp();
			onUp.Invoke(this);
		}
		protected virtual void OnUp() { }

		// -----

		public void OnPointerClick()	
		{
			OnClick();
			onClick.Invoke(this);
		}
		protected virtual void OnClick() { }
	}
}
