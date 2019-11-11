using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class flyweight
{
    public flyweight(Material mat, bool isHard = false)
    {
        this.mat = mat;
        _ishard = ishard;
    }

    public Material mat;

    bool _ishard = false;

    public bool ishard
    {
        get { return _ishard; }
    }

}
