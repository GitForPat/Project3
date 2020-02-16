// GENERATED AUTOMATICALLY FROM 'Assets/inputControllerPlayer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControllerPlayer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControllerPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""inputControllerPlayer"",
    ""maps"": [
        {
            ""name"": ""playerControls"",
            ""id"": ""d7338d1d-8ffc-4261-855d-d7c0257ce254"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Button"",
                    ""id"": ""5885076a-2a79-40f8-b53f-2bade9ad6eee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e793e8b9-f9b3-47d9-aca0-5db8784664f5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // playerControls
        m_playerControls = asset.FindActionMap("playerControls", throwIfNotFound: true);
        m_playerControls_move = m_playerControls.FindAction("move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // playerControls
    private readonly InputActionMap m_playerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_playerControls_move;
    public struct PlayerControlsActions
    {
        private @InputControllerPlayer m_Wrapper;
        public PlayerControlsActions(@InputControllerPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_playerControls_move;
        public InputActionMap Get() { return m_Wrapper.m_playerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
            }
        }
    }
    public PlayerControlsActions @playerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
