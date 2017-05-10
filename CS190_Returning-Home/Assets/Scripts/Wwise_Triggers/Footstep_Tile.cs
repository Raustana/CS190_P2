using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep_Tile : AkTriggerBase {
    public void FootstepTile()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
