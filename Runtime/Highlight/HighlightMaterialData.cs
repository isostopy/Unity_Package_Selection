using UnityEngine;

namespace Isostopy.Selection
{
	[CreateAssetMenu(fileName = "new Highlight Material Data", menuName = "Isostopy/Selection/Selectable Highlight Data/Highlight Material Data")]
	public class HighlightMaterialData : ScriptableObject
	{
		[Space]
		public Material hoverMaterial;
		public Material selectedMaterial;
	}
}
