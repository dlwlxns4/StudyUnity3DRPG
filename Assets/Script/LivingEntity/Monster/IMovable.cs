using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{

    public void Move();
    public void CanMove();
    public void Chase();
    public void GoHome(Vector3 homePos);
}
