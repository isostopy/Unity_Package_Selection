using UnityEngine;

namespace Isostopy.Selection
{
    public class HighlightableBox : MonoBehaviour
    {

        [SerializeField] GameObject box;
        [SerializeField] SelectionMaterials selectionMaterials;

        Renderer rendererComponent;
        Material defaultMaterial;
        Selectable selectable;

        #region Subscription Management

        private void OnEnable()
        {
            selectable = GetComponent<Selectable>();

            selectable.OnSelect += Select;
            selectable.OnDeselect += Deselect;
            selectable.OnHoverEnter += HoverEnter;
            selectable.OnHoverExit += HoverExit;

        }

        private void OnDisable()
        {
            selectable.OnSelect -= Select;
            selectable.OnDeselect -= Deselect;
            selectable.OnHoverEnter -= HoverEnter;
            selectable.OnHoverExit -= HoverExit;
        }

        #endregion

        private void Start()
        {
            rendererComponent = box.GetComponent<Renderer>();
            defaultMaterial = rendererComponent.material;
        }

        public void ShowBox()
        {
            box.SetActive(true);
        }

        public void HideBox() 
        {
            box.SetActive(false);
        }

        public void SetDefaultMaterial()
        {
            rendererComponent.material = defaultMaterial;
        }

        public void SetMaterial(Material material)
        {
            rendererComponent.material = material;
        }


        private void Select(Selectable selectable)
        {
            ShowBox();
            SetDefaultMaterial();
        }

        private void Deselect(Selectable selectable)
        {
            HideBox();
        }

        private void HoverEnter(Selectable selectable)
        {
            SetMaterial(selectionMaterials.hoverMaterial);
        }

        private void HoverExit(Selectable selectable)
        {
            SetDefaultMaterial();   
        }

    }

}