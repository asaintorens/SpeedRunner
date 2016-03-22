using UnityEngine;
using System.Collections;

public enum EnumerationInput {
    Jump = 0,
    Slide= 1,
    Enforce=2,
    Spear=3,
    Run = 4,
    All = Jump | Slide | Enforce | Spear | Run
}
