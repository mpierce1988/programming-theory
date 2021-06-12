using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : Animal
{
    // INHERITANCE
    public override void CaptureAnimal()
    {
        base.CaptureAnimal();
        MasterSingleton.instance.SoundEffects.PlayGoatSound();
    }
}
