using InControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase para almacenar el set de acciones de input que va a poder realizar el jugador. Es parte del plugin InControl.
/// Para más, ver http://www.gallantgames.com/pages/incontrol-binding-actions-to-controls
/// </summary>

public class PlayerInputActions : PlayerActionSet
{
    public PlayerAction MoveLeft { get; private set; }
    public PlayerAction MoveRight { get; private set; }
    public PlayerOneAxisAction Move { get; private set; }

    public PlayerAction Jump { get; private set; }
    
    public PlayerAction IgniteJetpack { get; private set; }
    public PlayerAction RotateLeft { get; private set; }
    public PlayerAction RotateRight { get; private set; }
    public PlayerOneAxisAction RotateJetpack { get; private set; }

    public PlayerAction Shoot { get; private set; }

    public PlayerAction AimUp { get; private set; }
    public PlayerAction AimDown { get; private set; }
    public PlayerAction AimLeft { get; private set; }
    public PlayerAction AimRight { get; private set; }
    public PlayerTwoAxisAction Aim { get; private set; }

    public PlayerAction RotateAimLeft { get; private set; }
    public PlayerAction RotateAimRight { get; private set; }
    public PlayerOneAxisAction RotateAim { get; private set; }


    public PlayerInputActions()
    {
        MoveLeft = CreatePlayerAction("Move Left");
        MoveRight = CreatePlayerAction("Move Right");
        Move = CreateOneAxisPlayerAction(MoveLeft, MoveRight);

        Jump = CreatePlayerAction("Jump");

        IgniteJetpack = CreatePlayerAction("Thrust");
        RotateLeft = CreatePlayerAction("Rotate Left");
        RotateRight = CreatePlayerAction("Rotate Right");
        RotateJetpack = CreateOneAxisPlayerAction(RotateLeft, RotateRight);

        Shoot = CreatePlayerAction("Shoot");

        AimUp = CreatePlayerAction("Aim Up");
        AimDown = CreatePlayerAction("Aim Down");
        AimLeft = CreatePlayerAction("Aim Left");
        AimRight = CreatePlayerAction("Aim Right");
        Aim = CreateTwoAxisPlayerAction(AimLeft, AimRight, AimDown, AimUp);

        SetupDefaultBindings();
    }

    private void SetupDefaultBindings()
    {
        MoveLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
        MoveLeft.AddDefaultBinding(InputControlType.DPadLeft);
        MoveRight.AddDefaultBinding(InputControlType.LeftStickRight);
        MoveRight.AddDefaultBinding(InputControlType.DPadRight);

        Jump.AddDefaultBinding(InputControlType.LeftBumper);

        IgniteJetpack.AddDefaultBinding(InputControlType.LeftTrigger);
        RotateLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
        RotateRight.AddDefaultBinding(InputControlType.LeftStickRight);

        Shoot.AddDefaultBinding(InputControlType.RightTrigger);

        AimUp.AddDefaultBinding(InputControlType.RightStickUp);
        AimDown.AddDefaultBinding(InputControlType.RightStickDown);
        AimLeft.AddDefaultBinding(InputControlType.RightStickLeft);
        AimRight.AddDefaultBinding(InputControlType.RightStickRight);
    }
}
