using UnityEngine;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Objeto que puede seleccionarse y deseleccionarse haciendo clic. </summary>
	
	/* TO DO:
			- Quiza molaria tener un [serialize field] string selectionGroup;
				si no esta vacio
					solo puede haber elegido un selectable de cada grupo
				si esta vacio
					nada, con el campo vacio pueden estar elegidos todos los que queramos
				Un static dictionary<string, selectable> que relaciona en id del grupo con que esta seleccionado en cada momento.
					Si nos selecccionan y hay uno en nuestro grupo, hacemos deselect y nos ponemos a nostros.
	 */

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


		// ----------------------------------------------------------------------------

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
