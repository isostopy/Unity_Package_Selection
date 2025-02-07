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
		public UnityEvent<Selectable> onSelect;
        public UnityEvent<Selectable> onDeselect;

		/// <summary> Si esta o no seleccionado este objeto. </summary>
        [HideInInspector] public bool isSelected { get; private set; }


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
            onSelect.Invoke(this);
        }
		protected virtual void OnSelect() { }

		// -----

        public void Deselect()
        {
            isSelected = false;
            onDeselect.Invoke(this);
        }
		protected virtual void OnDeselect() { }
	}
}
