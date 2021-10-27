using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivate
{
    void Activate();
    void Deactivate();
    void Enhance();
    void Diminish();
    void Toggle();
    void ActivateForSeconds(float time_t);
}
