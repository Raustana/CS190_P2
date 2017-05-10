using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : AkTriggerBase {

	public void Opening()
    {
        if(triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
