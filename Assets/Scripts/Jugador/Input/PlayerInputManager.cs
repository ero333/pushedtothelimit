using InControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager
{
    private PlayerController _player;
    private InputDevice _device;

    private PlayerInputActions _actions;

    #region Input Values
    public float MovementAxisValue { get { return _actions.Move; } }
    public bool JumpWasJustPressed { get { return _actions.Jump.IsPressed && _actions.Jump.HasChanged; } }

    public bool ShootIsPressed { get { return _actions.Jump.IsPressed; } }
    public bool ShootWasJustPressed { get { return _actions.Jump.IsPressed && _actions.Jump.HasChanged; } }

    public Vector2 AimAxisValue { get { return _actions.Aim; } }

    public bool JetpackThurstIsPressed { get { return _actions.IgniteJetpack.IsPressed; } }
    public float JetpackRotationAxisValue { get { return _actions.RotateJetpack; } }

    #endregion

    public PlayerInputManager(PlayerController player)
    {
        _player = player;

        _actions = new PlayerInputActions();

        //TODO: ¿Es esta la forma en la que queremos implementar la asignación de controles?

        foreach (InputDevice device in InputManager.Devices)
        {
            if (device.IsAttached)
            {
                _device = device;
            }

        }

        _actions.Device = _device;
    }

    public void Vibrate(float intensity, float duration)
    {
        if (duration <= 0 || intensity <= 0) return;

        _player.StartCoroutine(MakeGamepadVibrate(intensity, duration));
    }

    private IEnumerator MakeGamepadVibrate(float intensity, float duration)
    {
        _device.Vibrate(intensity);
        yield return new WaitForSeconds(duration);
        _device.StopVibration();
    }
}
