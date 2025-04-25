using UnityEngine;
using UnityEngine.Events;

namespace Isostopy.Selection
{
	/// <summary>
	/// Clase que usan los selectables para formar grupos de si mismos en los que solo puede haber uno seleccionado al mismo tiempo. </summary>

	[AddComponentMenu("Isostopy/Selection/Selectable Group")]
	public class SelectableGroup : MonoBehaviour
	{
		[HideInInspector] public UnityEvent<Selectable> onSelectableChanged = new();

		/*	Esta clase sirve para asignarlo en el inspector del selectable y no tener que usar un string literal para designar grupos.
			Esto tiene el evento para que se puedan suscribir al cambio de elemento seleccionado del grupo desde fuera.
			Toda la logica de grupos se implementa en el propio script del Selectable. */
	}
}
