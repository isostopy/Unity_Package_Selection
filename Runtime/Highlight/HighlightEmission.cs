using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Resalta un <see cref="Selectable"/> cambiando el color del emission. </summary>

    public class HighlightEmission : Highlight
    {
        [SerializeField] protected SelectionColors selectionColors;


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

		override protected void Select(Selectable selectable)
        {
            base.Select(selectable);
            SetEmissionColor(selectionColors.selectedColor);
        }

        override protected void Deselect(Selectable selectable)
        {
            base.Deselect(selectable);
            SetNoEmissionColor();
        }

        override protected void HoverEnter(Selectable selectable)
        {
            base.HoverEnter(selectable);
            if (!useHover) return;

            SetEmissionColor(selectionColors.hoverColor);
        }

        override protected void HoverExit(Selectable selectable)
        {
            base.HoverExit(selectable);
            if (!useHover) return;

            if (selectable.isSelected)
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