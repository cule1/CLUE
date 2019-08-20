namespace VRTK.Examples
{
    using UnityEngine;

    public class BaseGrab : VRTK_InteractableObject
    {

        public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
        {
        	base.StartUsing(currentUsingObject);
        }

		public void StopUsing(VRTK_InteractUse currentUsingObject = null)
		{
			base.StopUsing(currentUsingObject);
		}
    }
}