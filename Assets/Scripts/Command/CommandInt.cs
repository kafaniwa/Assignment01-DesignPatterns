using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CommandInt
{
    void Execute();

    void Undo();
}