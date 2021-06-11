using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cattle : Animal
{
    public override void CaptureAnimal()
    {
        base.CaptureAnimal();
        MasterSingleton.instance.SoundEffects.PlayCattleSound();
    }
}
