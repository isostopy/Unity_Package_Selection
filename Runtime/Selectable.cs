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

        public virtual void Select()
        {
            isSelected = true;
            OnSelect.Invoke(this);
        }
        public virtual void Deselect()
        {
            isSelected = false;
            OnDeselect.Invoke(this);
        }

        public virtual void HoverEnter()
        {
            OnHoverEnter.Invoke(this);
        }

        public virtual void HoverExit()
        {
            OnHoverExit.Invoke(this);
        }

    }

}