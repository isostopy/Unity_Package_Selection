using UnityEngine;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Objeto que puede seleccionarse y deseleccionarse. </summary>
    public class Selectable : MonoBehaviour
    {
		/// Eventos.
		[System.Serializable] public class SelectableEvent : UnityEvent<Selectable> { }
        public SelectableEvent OnHoverEnter;
        public SelectableEvent OnHoverExit;
		public SelectableEvent OnSelect;
        public SelectableEvent OnDeselect;

		/// <summary> Si esta o no seleccionado este objeto. </summary>
        [HideInInspector] public bool isSelected { get; private set; }


		// ----------------------------------------------------------------------------
		
		public void HoverEnter()
		{
			OnHoverEnter.Invoke(this);
		}

		public void HoverExit()
		{
			OnHoverExit.Invoke(this);
		}

		public void Select()
        {
            isSelected = true;
            OnSelect.Invoke(this);
        }

        public void Deselect()
        {
            isSelected = false;
            OnDeselect.Invoke(this);
        }

		/*
			TO DO:
				- Quiza hacer que estas funciones no sean virtual para no tener que llamar a base.Funcion desde todas las clases que hereden,
					porque la funcionalidad que hay aqui es necesaria por la bool que se pone a true
					Entonces tenemos Select y OnSelect, select no es virtual y se llama por el manager o quien sea igual que ahora. Select llama a OnSelect.
					Y las clases que heredan de Selectable, haces override de OnSelect donde da igual lo que hagas, porque la funcionalidad obligatoria esta ya en Select.
				- Quiza tengan que tener 3 posibles estados Hover, Pressed, Selected (ahora hay dos: Hover y Selected).
					Con funciones HoverEnter/Exit, Press/UnPress, Select/Deselect.
					Para saber cuando se pone el raton encima, cuando se esta pulsando sobre el objeto, y cuando se selecciona o deselecciona.
		 */
	}
}
