using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep_Concrete : AkTriggerBase
{
    public void FootstepConcrete()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
