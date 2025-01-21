using System;
using UnityEngine;

namespace Isostopy.Selection
{

    public class Selectable : MonoBehaviour
    {
        // Declare the event with the sender as a parameter
        public event Action<Selectable> OnSelect;
        public event Action<Selectable> OnDeselect;
        public event Action<Selectable> OnHoverEnter;
        public event Action<Selectable> OnHoverExit;

        public bool isSelected;

        public void Select()
        {
            OnSelect?.Invoke(this);
        }
        public void Deselect()
        {
            OnDeselect?.Invoke(this);
        }

        public void HoverEnter()
        {
            OnHoverEnter?.Invoke(this);
        }

        public void HoverExit()
        {
            OnHoverExit?.Invoke(this);
        }

    }

}