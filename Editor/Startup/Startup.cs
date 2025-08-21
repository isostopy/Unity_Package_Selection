
//using UnityEditor;
//using UnityEditor.Build;

//// Añadir un define para indicar que este paquete esta cargado.
//// Se usara en otros paquetes que interactuen con este y necesiten asegurarse de que existe en un #if.

// Esta comentado porque no se si usara y no se que problemas puede dar el codigo de abajo.
// Ademas, si luego borrases el paquete te defaria el define añadido. De momento, no hace falta, pero lo dejo por aqui porque puede ser util.

//[InitializeOnLoad]
//public class Startup
//{
//	static Startup()
//	{
//#if !ISOSTOPY_SELECTION
//		PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup), "ISOSTOPY_SELECTION");
//#endif
//	}
//}
