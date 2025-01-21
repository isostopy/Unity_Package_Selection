using UnityEngine;

namespace Isostopy.Selection.Sample
{
    public class SelectionManager : MonoBehaviour
    {
        public Material onHoverMaterial;
        public Material selectedMaterial;

        public Material onHoverBoxMaterial;

        Selectable[] selectableInstances;

        Selectable currentSelected;

        #region Subscription Management

        private void OnEnable()
        {
            // Subscribe to events from all instances
            selectableInstances = FindObjectsByType<Selectable>(FindObjectsSortMode.InstanceID);
            foreach (var instance in selectableInstances)
            {
                instance.OnSelect += Select;
                instance.OnHoverEnter += HoverEnter;
                instance.OnHoverExit += HoverExit;
            }
        }

        private void OnDisable()
        {
            // Unsubscribe from events to prevent memory leaks
            foreach (var instance in selectableInstances)
            {
                instance.OnSelect -= Select;
                instance.OnHoverEnter -= HoverEnter;
                instance.OnHoverExit -= HoverExit;
            }
        }

        #endregion

        private void Select(Selectable selectable)
        {
            Debug.Log(selectable.name + " selected");

            if (currentSelected == selectable)
            {
                Deselect();
                return;
            }

            if (currentSelected != null) Deselect();

            currentSelected = selectable;
            currentSelected.isSelected = true;

        }

        private void Deselect()
        {
            Debug.Log(currentSelected.name + " deselected");

            currentSelected.Deselect();
            currentSelected.isSelected = false;
            currentSelected = null;

        }

        private void HoverEnter(Selectable selectable)
        {
            Debug.Log(selectable.name + " hover enter");
        }

        private void HoverExit(Selectable selectable)
        {
            Debug.Log(selectable.name + " hover exit");
        }
    }

}