using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Isostopy.Selection
{
	/// <summary>
	/// Objeto que puede seleccionarse y deseleccionarse haciendo clic. </summary>

	[AddComponentMenu("Isostopy/Selection/Selectable")]
    public class Selectable : PointerInteractable
    {
		/// <summary> Si esta o no seleccionado este objeto. </summary>
		public bool isSelected { get; private set; }

		/// Eventos
		[HideInInspector] public UnityEvent<Selectable> onSelected = new();
		[HideInInspector] public UnityEvent<Selectable> onDeselected = new();

		/// Grupos de seleccion.
		[Space]
		[SerializeField] private SelectableGroup selectableGroup = null;
		private static SelectableGroup lastGroupAssignedInInspector = null;

		private static Dictionary<SelectableGroup, Selectable> selectedItemsByGroup = new();


		// ----------------------------------------------------------------------------

		/// Un truquito para facilitarnos la vida trabajando desde el inspector,
		/// si escribes un grupo en selectable, los que añadas despues tendran el mismo grupo.

		protected virtual void OnValidate()
		{
			lastGroupAssignedInInspector = selectableGroup;
		}

		protected virtual void Reset()
		{
			selectableGroup = lastGroupAssignedInInspector;
		}


		// ----------------------------------------------------------------------------

		protected override void OnClick()
		{
			if (isSelected == false)
				Select();
			else if (isSelected == true)
				Deselect();
		}


		// ----------------------------------------------------------------------------

		public void Select()
        {
			if (selectableGroup != null)
			{
				ChangeGroupSelectionTo(this);
			}

			isSelected = true;

			OnSelect();
            onSelected.Invoke(this);
        }
		protected virtual void OnSelect() { }

		// -----

        public void Deselect()
        {
			if (selectableGroup != null)
			{
				ChangeGroupSelectionTo(null);
			}

			isSelected = false;

			OnDeselect();
            onDeselected.Invoke(this);
		}
		protected virtual void OnDeselect() { }


		// ----------------------------------------------------------------------------

		private void ChangeGroupSelectionTo(Selectable newSelectable)
		{
			if (newSelectable == null)
			{
				selectedItemsByGroup.Remove(selectableGroup);
			}
			else
			{
				if (selectedItemsByGroup.ContainsKey(selectableGroup))
					selectedItemsByGroup[selectableGroup].Deselect();

				selectedItemsByGroup[selectableGroup] = newSelectable;
			}

			selectableGroup.onSelectableChanged.Invoke(newSelectable);
		}

		/// <summary>
		/// Obten el objeto seleccionado de un <see cref="SelectableGroup"/>. </summary>
		public static Selectable GetSelectedInGroup(SelectableGroup group)
		{
			if (selectedItemsByGroup.ContainsKey(group))
				return selectedItemsByGroup[group];
			return null;
		}
	}
}
