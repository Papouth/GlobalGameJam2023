//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Samples/Input System/PlayerMovementInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerMovementInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMovementInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMovementInput"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""939482da-6919-4079-becd-8b8bcf8ae9bf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""128e34a3-28d3-437a-b7bc-4dc6c3a3d325"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""93842ea8-9f26-4621-8e28-4d4bd706346e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d9c28c66-c076-4ddb-b065-faa28d6ae739"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StopShoot"",
                    ""type"": ""Button"",
                    ""id"": ""dc195708-1702-4fe2-be6c-7d6544fdf432"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Wheel"",
                    ""type"": ""Value"",
                    ""id"": ""7e3d9758-52d9-48dd-aa11-cd7e8d86e24b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c4929c08-9bbf-43fb-a4ba-21dcccc2b9aa"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ad663d7a-75bf-4204-8185-1841cf4a506e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0418ea34-3841-480a-8a2f-0a4127d2eeaf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1259cc9d-4c8f-4187-a906-24864394e8cf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5aa65be8-ffd9-40c4-8efb-d0ef29d6e82c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4df059d9-92a1-4679-b871-897fd1d16545"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de9acaec-589f-46bb-99fb-56378de4133b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b8e4ad1-3625-43b8-8fd4-b6673598eca2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f405454e-4b2c-4078-abc7-c224e891b0e7"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMap
        m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
        m_PlayerMap_Movement = m_PlayerMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMap_Interact = m_PlayerMap.FindAction("Interact", throwIfNotFound: true);
        m_PlayerMap_Shoot = m_PlayerMap.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerMap_StopShoot = m_PlayerMap.FindAction("StopShoot", throwIfNotFound: true);
        m_PlayerMap_Wheel = m_PlayerMap.FindAction("Wheel", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerMap
    private readonly InputActionMap m_PlayerMap;
    private IPlayerMapActions m_PlayerMapActionsCallbackInterface;
    private readonly InputAction m_PlayerMap_Movement;
    private readonly InputAction m_PlayerMap_Interact;
    private readonly InputAction m_PlayerMap_Shoot;
    private readonly InputAction m_PlayerMap_StopShoot;
    private readonly InputAction m_PlayerMap_Wheel;
    public struct PlayerMapActions
    {
        private @PlayerMovementInput m_Wrapper;
        public PlayerMapActions(@PlayerMovementInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMap_Movement;
        public InputAction @Interact => m_Wrapper.m_PlayerMap_Interact;
        public InputAction @Shoot => m_Wrapper.m_PlayerMap_Shoot;
        public InputAction @StopShoot => m_Wrapper.m_PlayerMap_StopShoot;
        public InputAction @Wheel => m_Wrapper.m_PlayerMap_Wheel;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMapActions instance)
        {
            if (m_Wrapper.m_PlayerMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnInteract;
                @Shoot.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnShoot;
                @StopShoot.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnStopShoot;
                @StopShoot.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnStopShoot;
                @StopShoot.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnStopShoot;
                @Wheel.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnWheel;
                @Wheel.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnWheel;
                @Wheel.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnWheel;
            }
            m_Wrapper.m_PlayerMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @StopShoot.started += instance.OnStopShoot;
                @StopShoot.performed += instance.OnStopShoot;
                @StopShoot.canceled += instance.OnStopShoot;
                @Wheel.started += instance.OnWheel;
                @Wheel.performed += instance.OnWheel;
                @Wheel.canceled += instance.OnWheel;
            }
        }
    }
    public PlayerMapActions @PlayerMap => new PlayerMapActions(this);
    public interface IPlayerMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnStopShoot(InputAction.CallbackContext context);
        void OnWheel(InputAction.CallbackContext context);
    }
}
