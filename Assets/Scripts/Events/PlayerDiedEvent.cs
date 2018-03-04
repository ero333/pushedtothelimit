using CatPot.Framework.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiedEvent : GameEvent
{ 
    public PlayerController Player { get; private set; }

    public PlayerDiedEvent(GameObject sender, PlayerController player) : base(sender)
    {
        Player = player;
    }
}
