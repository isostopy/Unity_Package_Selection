using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Componente que imita el funcionamiento del boton de Unity pero usando las funciones del paquete de seleccion. </summary>

	[AddComponentMenu("Isostopy/Selection/Button")]
	public class Button : UnityPointerInteractable
	{
		[Space]
		[SerializeField] Graphic targetGraphic = null;
		[Space]
		[SerializeField] Color normalColor = Color.white;
		[SerializeField] Color hoverColor = Color.white;
		[SerializeField] Color pressedColor = Color.white;
		[Space]
		[SerializeField] UnityEvent publicClickEvent = new();

		private bool hovering = false;


		// ----------------------------------------------------------------------------

		private void Reset()
		{
			targetGraphic = GetComponent<Graphic>();
			if (targetGraphic != null )
			{
				normalColor = targetGraphic.color;
			}
		}

		private void OnValidate()
		{
			targetGraphic.color = normalColor;
		}


		// ----------------------------------------------------------------------------

		protected override void OnHoverEnter()
		{
			hovering = true;
			targetGraphic.color = hoverColor;
		}

		protected override void OnHoverExit()
		{
			hovering = false;
			targetGraphic.color = normalColor;
		}

		protected override void OnPressDown()
		{
			targetGraphic.color = pressedColor;
		}

		protected override void OnPressUp()
		{
			if (hovering)
				targetGraphic.color = hoverColor;
			else
				targetGraphic.color = normalColor;
		}

		protected override void OnClick()
		{
			publicClickEvent.Invoke();
		}
	}
}