using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Subtegral.EscapeHouse.Managers
public static class ManagerFactory
{
    public static T GetInstance<T>() where T:AbstractManager<T>
    {
        GameObject managerObject = new GameObject(typeof(T).Name);
        return managerObject.AddComponent<T>();
    }
}
