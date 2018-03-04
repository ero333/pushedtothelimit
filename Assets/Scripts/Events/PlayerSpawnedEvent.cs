using CatPot.Framework.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnedEvent : GameEvent
{ 
    public PlayerController Player { get; private set; }

    public PlayerSpawnedEvent(GameObject sender, PlayerController player) : base(sender)
    {
        Player = player;
    }
}
