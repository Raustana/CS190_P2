using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PickupPing : AkTriggerBase
{

    public void Pinging()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
