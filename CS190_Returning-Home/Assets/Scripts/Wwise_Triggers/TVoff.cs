using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVoff : AkTriggerBase
{

    public void TurningOff()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
