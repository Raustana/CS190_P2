using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep_Carpet : AkTriggerBase
{
    public void FootstepCarpet()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
