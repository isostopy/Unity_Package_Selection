using UnityEngine;

namespace Isostopy.Selection.Sample
{
	/// <summary>
	/// Una muestra de un posible manager que solo permite tener seleccionado un objeto al mismo tiempo. </summary>

    public class SelectionManagerSample : MonoBehaviour
    {
        Selectable[] selectableInstances;
        Selectable currentSelected;


		// ----------------------------------------------------------------------------
		#region Subscription Management

		private void OnEnable()
        {
            // Subscribe to events from all instances
            selectableInstances = FindObjectsByType<Selectable>(FindObjectsSortMode.InstanceID);
            foreach (var instance in selectableInstances)
            {
                instance.OnSelect.AddListener(Select);
            }
        }

        private void OnDisable()
        {
            // Unsubscribe from events to prevent memory leaks
            foreach (var instance in selectableInstances)
            {
                instance.OnSelect.RemoveListener(Select);
            }
        }

		#endregion


		// ----------------------------------------------------------------------------
		private void Select(Selectable selectable)
        {

            if (currentSelected == selectable)
            {
                Deselect();
                return;
            }

            if (currentSelected != null)
            {
                Deselect();
            }

            Debug.Log(selectable.name + " selected");
            currentSelected = selectable;

        }

        private void Deselect()
        {
            Debug.Log(currentSelected.name + " deselected");

            currentSelected.Deselect();
            currentSelected = null;

        }
    }
}