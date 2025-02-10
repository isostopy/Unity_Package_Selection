using UnityEngine;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Objeto que puede seleccionarse y deseleccionarse. </summary>

	[AddComponentMenu("Isostopy/Selection/Selectable")] 
    public class Selectable : PointerInteractable
    {
		/// Eventos
		[HideInInspector] public UnityEvent<Selectable> onSelect;
		[HideInInspector] public UnityEvent<Selectable> onDeselect;

		/// <summary> Si esta o no seleccionado este objeto. </summary>
        public bool isSelected { get; private set; }


		// ----------------------------------------------------------------------------

		protected override void OnClick()
		{
			if (isSelected == false)
				Select();
			else if (isSelected == true)
				Deselect();
		}

		// --------------------------------------

		public void Select()
        {
            isSelected = true;

			OnSelect();
            onSelect.Invoke(this);
        }
		protected virtual void OnSelect() { }

		// -----

        public void Deselect()
        {
            isSelected = false;

			OnDeselect();
            onDeselect.Invoke(this);
        }
		protected virtual void OnDeselect() { }
	}
}
