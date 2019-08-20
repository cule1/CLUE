namespace VRTK.Examples
{
    using UnityEngine;

    public class OpenInventory : VRTK_InteractableObject
    {
        public GameObject panel;

        public override void StartUsing(VRTK_InteractUse currentUsingObject)
        {
            base.StartUsing(currentUsingObject);
            OpenPanel();
			print("using");
        }

		// public override void Grabbed(VRTK_InteractGrab currentGrabbingObject)
		// {
		// 	base.Grabbed(currentGrabbingObject);
		// 	ClosePanel();
		// }

		// public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject)
			
		// {
		// 	base.Ungrabbed(previousGrabbingObject);
		// 	if(!IsInSnapDropZone())
		// 	{
		// 		OpenPanel();
		// 	}
		// }

		public void StopUsing(VRTK_InteractUse currentUsingObject )
		{
			base.StopUsing(currentUsingObject);
			print("calling dum butt");
			ClosePanel();
		}

        protected void Start()
        {

        }

		void OpenPanel()
		{
			panel.SetActive(true);
		}

		void ClosePanel()
		{
			panel.SetActive(false);
		}

    }
}