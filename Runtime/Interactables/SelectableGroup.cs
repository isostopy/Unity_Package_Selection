using UnityEngine;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Clase que usan los selectables para formar grupos de si mismos en los que solo puede haber uno seleccionado al mismo tiempo. </summary>

	/*	Esta clase sirve para asignarlo en el inspector del selectable y no tener que usar un string literal para designar grupos.
		Toda la logica de grupos se implementa en el propio script del Selectable. */

	[AddComponentMenu("Isostopy/Selection/Selectable Group")]
	public class SelectableGroup : MonoBehaviour
	{
		[HideInInspector] public UnityEvent<Selectable> onSelectableChanged = new();


		/// <summary> Obten el objeto seleccionado de este grupo. </summary>
		public Selectable GetSelected()
		{
			return Selectable.GetSelectedInGroup(this);
		}
	}
}
