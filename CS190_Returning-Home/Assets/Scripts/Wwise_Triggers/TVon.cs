using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVon : AkTriggerBase {

	public void TurningOn()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
