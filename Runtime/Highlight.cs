using System.Collections.Generic;
using UnityEngine;

namespace Isostopy.Selection
{

    [CreateAssetMenu(fileName = "SelectionMaterials", menuName = "Scriptable Objects/SelectionMaterials")]
    public class SelectionMaterials : ScriptableObject
    {
        public Material hoverMaterial;
        public Material selectedMaterial;
    }

    [CreateAssetMenu(fileName = "SelectionColors", menuName = "Scriptable Objects/SelectionColors")]
    public class SelectionColors : ScriptableObject
    {
        public Color hoverColor;
        public Color selectedColor;
    }

    public abstract class Highlight : MonoBehaviour
    {

        public bool useHover = true;

        protected Selectable selectable;
        protected Renderer rendererComponent;

        #region Subscription Management

        private void OnEnable()
        {
            selectable = GetComponent<Selectable>();

            selectable.OnSelect.AddListener(Select);
            selectable.OnDeselect.AddListener(Deselect);
            selectable.OnHoverEnter.AddListener(HoverEnter);
            selectable.OnHoverExit.AddListener(HoverExit);

        }

        private void OnDisable()
        {
            selectable.OnSelect.RemoveListener(Select);
            selectable.OnDeselect.RemoveListener(Deselect);
            selectable.OnHoverEnter.RemoveListener(HoverEnter);
            selectable.OnHoverExit.RemoveListener(HoverExit);
        }

        #endregion

        
        #region Binded Functions

        protected virtual void Select(Selectable selectable)
        {

        }

        protected virtual void Deselect(Selectable selectable)
        {

        }

        protected virtual void HoverEnter(Selectable selectable)
        {
            
        }

        protected virtual void HoverExit(Selectable selectable)
        {

        }

        #endregion

    }

}