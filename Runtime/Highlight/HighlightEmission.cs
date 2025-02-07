using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Resalta un <see cref="Selectable"/> cambiando el color del emission. </summary>

    public class HighlightEmission : Highlight
    {
        [SerializeField] protected HighlightColorData selectionColors;


		// ----------------------------------------------------------------------------

		private void Start()
        {
            rendererComponent = GetComponent<Renderer>();

            rendererComponent.material.EnableKeyword("_EMISSION");
            rendererComponent.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        }


		// ----------------------------------------------------------------------------

		private void SetEmissionColor(Color color)
        {
            foreach (Material mat in rendererComponent.materials)
            {
                mat.SetColor("_EmissionColor", color);
            }
        }

        private void SetNoEmissionColor()
        {
            foreach (Material mat in rendererComponent.materials)
            {
                mat.SetColor("_EmissionColor", Color.black);
            }
        }


		// ----------------------------------------------------------------------------
		#region Binded Functions

		override protected void Select(PointerInteractable selectable)
        {
            SetEmissionColor(selectionColors.selectedColor);
        }

        override protected void Deselect(PointerInteractable selectable)
        {
            SetNoEmissionColor();
        }

        override protected void HoverEnter(PointerInteractable selectable)
        {
            if (!useHover) return;

            SetEmissionColor(selectionColors.hoverColor);
        }

        override protected void HoverExit(PointerInteractable selectable)
        {
            if (!useHover) return;

            if ((selectable as Selectable).isSelected)
            {
                SetEmissionColor(selectionColors.selectedColor);
            }
            else
            {
                SetNoEmissionColor();
            }
        }

        #endregion
    }
}