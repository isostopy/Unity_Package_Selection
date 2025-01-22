using System;
using UnityEngine;
using UnityEngine.Events;

namespace Isostopy.Selection
{

    [System.Serializable]
    public class SelectableEvent : UnityEvent<Selectable> { }

    public class Selectable : MonoBehaviour
    {
        public SelectableEvent OnSelect;
        public SelectableEvent OnDeselect;
        public SelectableEvent OnHoverEnter;
        public SelectableEvent OnHoverExit;

        [HideInInspector] public bool isSelected;

        public void Select()
        {
            isSelected = true;
            OnSelect.Invoke(this);
        }
        public void Deselect()
        {
            isSelected = false;
            OnDeselect.Invoke(this);
        }

        public void HoverEnter()
        {
            OnHoverEnter.Invoke(this);
        }

        public void HoverExit()
        {
            OnHoverExit.Invoke(this);
        }

    }

}