using UnityEngine;

namespace Isostopy.Selection.Sample
{
	/// <summary>
	/// Una muestra de un posible manager que solo permite tener seleccionado un objeto al mismo tiempo. </summary>

    public class SelectionManagerSample : MonoBehaviour
    {
        Selectable[] selectableInstances;
        Selectable currentlySelected;


		// ----------------------------------------------------------------------------

		private void OnEnable()
        {
            // Subscribe to events from all instances
            selectableInstances = FindObjectsByType<Selectable>(FindObjectsSortMode.InstanceID);
            foreach (var instance in selectableInstances)
            {
                instance.onSelect.AddListener(OnSelected);
				instance.onDeselect.AddListener(OnDeselected);
            }
        }

        private void OnDisable()
        {
            // Unsubscribe from events to prevent memory leaks
            foreach (var instance in selectableInstances)
            {
                instance.onSelect.RemoveListener(OnSelected);
				instance.onDeselect.RemoveListener(OnDeselected);
            }
        }


		// ----------------------------------------------------------------------------

		private void OnSelected(Selectable selectable)
        {
            if (currentlySelected != null)
            {
				currentlySelected.Deselect();
			}
            currentlySelected = selectable;
        }

        private void OnDeselected(Selectable selectable)
        {
			if (selectable != currentlySelected)
				return;

            currentlySelected = null;
        }
    }
}
