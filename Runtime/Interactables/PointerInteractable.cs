using UnityEngine;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Componente base con el que interactua el puntero. </summary>

	[AddComponentMenu("Isostopy/Selection/Pointer Interactable")]
	public class PointerInteractable : MonoBehaviour
	{
		[HideInInspector] public UnityEvent<PointerInteractable> onHoverEnter = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onHoverExit = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onPressDown = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onPressUp = new();
		[HideInInspector] public UnityEvent<PointerInteractable> onClick = new();


		// ----------------------------------------------------------------------------

		public void HoverEnter()
		{
			OnHoverEnter();
			onHoverEnter.Invoke(this);
		}
		protected virtual void OnHoverEnter() { }

		// -----

		public void HoverExit()
		{
			OnHoverExit();
			onHoverExit.Invoke(this);
		}
		protected virtual void OnHoverExit() { }

		// -------------------

		public void PressDown()
		{
			OnPressDown();
			onPressDown.Invoke(this);
		}
		protected virtual void OnPressDown() { }

		// -----

		public void PressUp()
		{
			OnPressUp();
			onPressUp.Invoke(this);
		}
		protected virtual void OnPressUp() { }
		
		// -----

		public void Click()
		{
			OnClick();
			onClick.Invoke(this);
		}
		protected virtual void OnClick() { }
	}
}
