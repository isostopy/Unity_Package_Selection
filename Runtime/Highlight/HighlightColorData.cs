using UnityEngine;

namespace Isostopy.Selection
{
	[CreateAssetMenu(fileName = "new Highlight Color Data", menuName = "Isostopy/Selection/Selectable Highlight Data/Highlight Color Data")]
	public class HighlightColorData : ScriptableObject
	{
		[Space]
		public Color hoverColor;
		public Color selectedColor;
	}
}
