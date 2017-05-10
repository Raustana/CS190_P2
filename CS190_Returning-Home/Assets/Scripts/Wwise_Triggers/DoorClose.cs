using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : AkTriggerBase
{

    public void Closing()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
