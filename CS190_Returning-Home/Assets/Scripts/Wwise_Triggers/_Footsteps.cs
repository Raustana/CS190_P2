using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Footsteps : AkTriggerBase
{
    public void Step()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
