using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cattle : Animal
{
    // INHERITANCE
    public override void CaptureAnimal()
    {
        base.CaptureAnimal();
        MasterSingleton.instance.SoundEffects.PlayCattleSound();
    }
}
