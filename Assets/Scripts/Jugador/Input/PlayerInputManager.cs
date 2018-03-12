using InControl;
using System.Collections;
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

    public PlayerInputManager(PlayerController player, int playerNumber)
    {
        _player = player;

        //TODO: ¿Es esta la forma en la que queremos implementar la asignación de controles?
        _actions = new PlayerInputActions();

       // Debug.Assert(InputManager.Devices.Count >= playerNumber, "There are not enough controllers connected!");

        if (InputManager.Devices.Count >= playerNumber && InputManager.Devices[playerNumber - 1].IsAttached)
        {
            _device = InputManager.Devices[playerNumber - 1];
            _actions.Device = _device;
            return;
        }

        _actions.Enabled = false;
    }

    public void Vibrate(float intensity, float duration)
    {
        if (_device == null) return;

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
