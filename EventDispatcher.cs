using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subtegral.EscapeHouse
{
    public static class EventDispatcher
    {
        public static DisplayEvent OnItemNotExists;
        public static EffectorEvent<Item> OnItemTaken;
        public static EffectorEvent<Item> OnItemRemoved;
    }

    public delegate void EffectorEvent<in T>(T t);
    public delegate void DisplayEvent();
}