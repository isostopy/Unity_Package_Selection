using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Componente que imita el funcionamiento del boton de Unity pero usando las funciones del paquete de seleccion. </summary>

	[AddComponentMenu("Isostopy/Selection/IsostopyButton")]
	public class IsostopyButton : PointerInteractable
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
		private bool pressed = false;


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
			if (targetGraphic != null)
				targetGraphic.color = normalColor;
		}


		// ----------------------------------------------------------------------------

		private void OnDisable()
		{
			hovering = false;
			pressed = false;
			targetGraphic.color = normalColor;
		}


		// ----------------------------------------------------------------------------

		protected override void OnEnter()
		{
			hovering = true;
			targetGraphic.color = hoverColor;
		}

		protected override void OnExit()
		{
			hovering = false;
			targetGraphic.color = normalColor;
		}

		protected override void OnDown()
		{
			pressed = true;
			targetGraphic.color = pressedColor;
		}

		protected override void OnUp()
		{
			pressed = false;

			if (hovering)
				targetGraphic.color = hoverColor;
			else
				targetGraphic.color = normalColor;
		}

		protected override void OnClick()
		{
			publicClickEvent.Invoke();
		}


		// ----------------------------------------------------------------------------

		public Graphic TargetGraphic
		{
			get => targetGraphic;
			set
			{
				targetGraphic = value;
				if (targetGraphic == null)
					return;

				if (pressed && hovering)
					targetGraphic.color = pressedColor;
				else if (hovering)
					targetGraphic.color = hoverColor;
				else
					targetGraphic.color = normalColor;
			}
		}

		public Color NormalColor
		{
			get => normalColor;
			set
			{
				normalColor = value;
				if (!hovering && !pressed && targetGraphic != null)
					targetGraphic.color = normalColor;
			}
		}

		public Color HoverColor
		{
			get => hoverColor;
			set => hoverColor = value;
		}

		public Color PressedColor
		{
			get => pressedColor;
			set => pressedColor = value;
		}
	}
}