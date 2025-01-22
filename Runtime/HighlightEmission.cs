using UnityEngine;

namespace Isostopy.Selection
{

    public class HighlightEmission : Highlight
    {

        [SerializeField] protected SelectionColors selectionColors;


        private void Start()
        {
            rendererComponent = GetComponent<Renderer>();

            rendererComponent.material.EnableKeyword("_EMISSION");
            rendererComponent.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        }

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

        #region Binded Functions

        override protected void Select(Selectable selectable)
        {
            SetEmissionColor(selectionColors.selectedColor);
        }

        override protected void Deselect(Selectable selectable)
        {
            SetNoEmissionColor();
        }

        override protected void HoverEnter(Selectable selectable)
        {
            SetEmissionColor(selectionColors.hoverColor);
        }

        override protected void HoverExit(Selectable selectable)
        {
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