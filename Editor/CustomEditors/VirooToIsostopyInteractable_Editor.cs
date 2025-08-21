using UnityEngine;
using UnityEditor;

namespace Isostopy.Selection.Viroo.Editor
{

	[CustomEditor(typeof(VirooToIsostopyInteractable))]
	public class VirooToIsostopyInteractable_Editor : UnityEditor.Editor
	{
#if !VIROO
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			EditorGUILayout.Space();
			EditorGUILayout.HelpBox(
				"Este componente necesita tener importado el paquete de Viroo y haber a�adido el scripting define symbol VIROO en las player settings.\n" +
				"Asegurate de haber a�adido el paquete de viroo y pulsa el boton para a�adir el define a las player settings.",
				MessageType.Info);
			if (GUILayout.Button("#define VIROO"))
			{
				PlayerSettings.SetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget.Standalone, "VIROO");
			}
		}
#endif
	}
}
