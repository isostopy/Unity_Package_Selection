using UnityEngine;
using UnityEngine.Events;

namespace Isostopy.Selection.Sample
{

    public class MouseEvents : MonoBehaviour
    {

        public UnityEvent OnMouseDownEvent;
        public UnityEvent OnMouseEnterEvent;
        public UnityEvent OnMouseExitEvent;

        private void OnMouseDown()
        {
            OnMouseDownEvent.Invoke();
        }

        private void OnMouseEnter()
        {
            OnMouseEnterEvent.Invoke();
        }

        private void OnMouseExit()
        {
            OnMouseExitEvent.Invoke();
        }

    }

}