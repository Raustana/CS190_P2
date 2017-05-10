using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep_Grass : AkTriggerBase
{
    public void FootstepGrass()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
