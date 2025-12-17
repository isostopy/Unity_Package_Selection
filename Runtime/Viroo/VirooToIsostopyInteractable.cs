using UnityEngine;

namespace Isostopy.Selection.Viroo
{

#if VIROO
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
#endif

	/// <summary>
	/// Componente que trasmite los eventos desde un interactuable de Viroo a uno de Isostopy. </summary>
#if VIROO
[RequireComponent (typeof(PointerInteractable))]
[RequireComponent (typeof(XRSimpleInteractable))]
#endif
	public class VirooToIsostopyInteractable : MonoBehaviour
	{
#if VIROO

	PointerInteractable isostopyInteractable = null;
	XRSimpleInteractable virooInteractable = null;

	bool pressed = false;


	// ----------------------------------------------------------------------------

	private void Awake()
	{
		isostopyInteractable = GetComponent<PointerInteractable>();
		virooInteractable = GetComponent<XRSimpleInteractable>();

		virooInteractable.hoverEntered.AddListener(VirooHoverEnter);
		virooInteractable.hoverExited.AddListener(VirooHoverExit);
		virooInteractable.activated.AddListener(VirooActivate);
		virooInteractable.deactivated.AddListener(VirooDeactivate);
			/* DESCOMENTAR ESTO CUANDO LO ARREGLEN DE VIROO.
				La ultima vez que probamos, añadir el listener en cogido funcionaba en local
				pero los eventos de que se habia hecho clic no se propagaban en red.
				Si añades los listeler a mano en el editor si que funciona en red, 
				asi que de momento hemos añadido un clic derecho -> añadir listeners que facilite el trabajo pero que no es ideal. */
		}


	// ----------------------------------------------------------------------------

	private void VirooHoverEnter(HoverEnterEventArgs args)
	{
		isostopyInteractable.OnPointerEnter();
	}

	private void VirooHoverExit(HoverExitEventArgs args)
	{
		isostopyInteractable.OnPointerExit();

		if (pressed)
		{
			pressed = false;
			isostopyInteractable.OnPointerUp();
			// Al sacar el raton del objeto hacemos como que el usuario al levantado el boton.
			// Porque cuando se levanta el boton sin estar apuntado a este objeto, Viroo no nos notifica.
		}
	}

	private void VirooActivate(ActivateEventArgs args)
	{
		// Esta funcion se llama cuando se hace click sobre el objeto.

		isostopyInteractable.OnPointerDown();
		pressed = true;
	}

	private void VirooDeactivate(DeactivateEventArgs args)
	{
		// Esta funcion solo se llama cuando se suelta el raton sobre el objeto.
		// Aunque se haya hecho click sobre el objeto, si luego se suelta el boton fuera del objeto, no se llama.

		if (pressed)
		{
			pressed = false;
			isostopyInteractable.OnPointerUp();
			isostopyInteractable.OnPointerClick();
		}
	}
	

	// -------------------------------------------------------------------------------------

#if UNITY_EDITOR
	[ContextMenu("ISOSTOPY - Add Listeneres to XRSimpleInteractable")]
	private void AddListenerToViroo()
	{
		var xrSimpleInteractable = GetComponent<XRSimpleInteractable>();

		UnityEditor.Undo.RecordObject(xrSimpleInteractable, "Añadidos listener de Viroo");

		UnityEditor.Events.UnityEventTools.AddPersistentListener(xrSimpleInteractable.activated, VirooActivate);
		UnityEditor.Events.UnityEventTools.AddPersistentListener(xrSimpleInteractable.deactivated, VirooDeactivate);
	}
#endif

#endif
	}
}

