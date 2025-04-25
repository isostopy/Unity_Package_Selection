using UnityEngine;

namespace Isostopy.Selection
{
	/// <summary>
	/// Resalta cambiando el color del emission. </summary>

    public class HighlightWithEmission : Highlight
    {
		Renderer rendererComponent = null;

		[Space]
        [SerializeField] HighlightColorData selectionColors;


		// ----------------------------------------------------------------------------

		private void Start()
        {
            rendererComponent = GetComponent<Renderer>();

            rendererComponent.material.EnableKeyword("_EMISSION");
            rendererComponent.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        }


		// ----------------------------------------------------------------------------

		protected override void ShowAsNormal()
		{
			SetEmissionColor(Color.black);
		}

		protected override void ShowAsHover()
		{
			SetEmissionColor(selectionColors.hoverColor);
		}

		protected override void ShowAsPressed()
		{
			SetEmissionColor(selectionColors.pressedColor);
		}

		protected override void ShowAsSelected()
		{
			SetEmissionColor(selectionColors.selectedColor);
		}


		// ----------------------------------------------------------------------------

		private void SetEmissionColor(Color color)
		{
			foreach (Material mat in rendererComponent.materials)
			{
				mat.SetColor("_EmissionColor", color);
			}
		}
	}
}