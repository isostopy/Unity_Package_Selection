using UnityEngine;

namespace Isostopy.Selection
{

    [CreateAssetMenu(fileName = "SelectionMaterials", menuName = "Scriptable Objects/SelectionMaterials")]

    public class SelectionMaterials : ScriptableObject
    {
        public Material hoverMaterial;
        public Material selectedMaterial;

    }

}