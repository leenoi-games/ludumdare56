using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Managers/InputReader", order = 0)]
public class InputReader : ScriptableObject, InputActions.IMouseMovementActions
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private InputActions playerInput;

    [Header("GameEvents for Player Input")]
    [SerializeField] private VectorEvent moveEvent;
    [SerializeField] private GameEvent pickUpEvent;
    [SerializeField] private GameEvent dropEvent;
/*
     [Header("GameEvents for Point n Click")]
    [SerializeField] private VectorEvent moveClickEvent;

    [Header("GameEvents for Dialogue Input")]
    [SerializeField] private GameEvent nextDialogueEvent;

    [Header("GameEvents for UI Input")]
    [SerializeField] private GameEvent navigateEvent;
    [SerializeField] private GameEvent submitEvent;
    [SerializeField] private GameEvent cancelEvent;
    [SerializeField] private GameEvent pointEvent;
    [SerializeField] private GameEvent clickEvent;
    [SerializeField] private GameEvent ScrollWheelEvent;
    [SerializeField] private GameEvent MiddleClickEvent;
    [SerializeField] private GameEvent TrackedDevicePositionEvent;
    [SerializeField] private GameEvent RightClickEvent;
    [SerializeField] private GameEvent TrackedDeviceOrientationEvent;

    [Header("GameEventListeners")]
    [SerializeField] private CodedFloatEventListener playerInputInstantiatedListener;

    [Header("GameEvents for Music Level Input")]
    [SerializeField] private VectorEvent moveCursorEvent;
    [SerializeField] private GameEvent pressedAKeyEvent;
    [SerializeField] private GameEvent pressedSKeyEvent;
    [SerializeField] private GameEvent pressedDKeyEvent;
    [SerializeField] private GameEvent pressedFKeyEvent;

    [SerializeField] private GameEvent canceledAKeyEvent;
    [SerializeField] private GameEvent canceledSKeyEvent;
    [SerializeField] private GameEvent canceledDKeyEvent;
    [SerializeField] private GameEvent canceledFKeyEvent;


    [Header("GameEvents for Point n' Click Input")]
    [SerializeField] private VectorEvent moveOnClickEvent;*/
    
    private void OnEnable() 
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        SetCallbacks();
    }

    private void SetCallbacks()
    {
        if(inputManager != null)
        {
            playerInput = inputManager.GetPlayerInput();
        }
        else
        {
            playerInput = new InputActions();
        }
        /*playerInput.Player.SetCallbacks(this);
        playerInput.UI.SetCallbacks(this);
        playerInput.Dialogue.SetCallbacks(this);
        playerInput.MusicLevel.SetCallbacks(this);
        playerInput.PointnClick.SetCallbacks(this);*/
        playerInput.MouseMovement.SetCallbacks(this);
        playerInput.Enable();
    }

    private void OnDisable() 
    {
        //playerInputInstantiatedListener?.OnDisable();
    }



//-------------------------------------------------------------
// ADVENTURE ACTIONS
//-------------------------------------------------------------

    public void OnWalk(InputAction.CallbackContext context)
    {
        if(moveEvent != null)
        {
            moveEvent.testProperty = context.ReadValue<Vector2>();
            moveEvent.Raise(context.ReadValue<Vector2>());
        }
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if(pickUpEvent != null && context.phase == InputActionPhase.Performed)
        {
            pickUpEvent.Raise();
        }

        if(dropEvent != null && context.phase == InputActionPhase.Canceled)
        {
            dropEvent.Raise();
        }
    }


    /*public void OnInteract(InputAction.CallbackContext context)
    {
        if(interactEvent != null && context.phase == InputActionPhase.Performed)
        {
            interactEvent.Raise();
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if(sprintEvent != null && context.phase == InputActionPhase.Performed)
        {
            sprintEvent.Raise();
        }
    }


//-------------------------------------------------------------
// UI ACTIONS
//-------------------------------------------------------------

    public void OnNavigate(InputAction.CallbackContext context)
    {
        if(navigateEvent != null && context.phase == InputActionPhase.Performed)
        {
            navigateEvent.Raise();
        }
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if(submitEvent != null && context.phase == InputActionPhase.Performed)
        {
            submitEvent.Raise();
        }
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if(cancelEvent != null && context.phase == InputActionPhase.Performed)
        {
            cancelEvent.Raise();
        }
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        if(pointEvent != null && context.phase == InputActionPhase.Performed)
        {
            pointEvent.Raise();
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(clickEvent != null && context.phase == InputActionPhase.Performed)
        {
            clickEvent.Raise();
        }
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        if(ScrollWheelEvent != null && context.phase == InputActionPhase.Performed)
        {
            ScrollWheelEvent.Raise();
        }
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        if(MiddleClickEvent != null && context.phase == InputActionPhase.Performed)
        {
            MiddleClickEvent.Raise();
        }
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        if(RightClickEvent != null && context.phase == InputActionPhase.Performed)
        {
            RightClickEvent.Raise();
        }
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        if(TrackedDevicePositionEvent != null && context.phase == InputActionPhase.Performed)
        {
            TrackedDevicePositionEvent.Raise();
        }
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        if(TrackedDeviceOrientationEvent != null && context.phase == InputActionPhase.Performed)
        {
            TrackedDeviceOrientationEvent.Raise();
        }
    }


//-------------------------------------------------------------
// DIALOGUE ACTIONS
//-------------------------------------------------------------

    public void OnNextDialogue(InputAction.CallbackContext context)
    {
        if(nextDialogueEvent != null && context.phase == InputActionPhase.Performed)
        {
            nextDialogueEvent.Raise();
        }
    }

//-------------------------------------------------------------
// MUSIC LEVEL ACTIONS
//-------------------------------------------------------------

    public void OnMoveCursor(InputAction.CallbackContext context)
    {
        if(moveCursorEvent != null)
        {
            moveCursorEvent.testProperty = context.ReadValue<Vector2>();
            moveCursorEvent.Raise(context.ReadValue<Vector2>());
        }
    }
    public void OnActivateAKey(InputAction.CallbackContext context)
    {
        if(pressedAKeyEvent != null && canceledAKeyEvent != null)
        {
            if(context.phase == InputActionPhase.Started)
            {
                pressedAKeyEvent.Raise();
            } 
            else if(context.phase == InputActionPhase.Canceled)
            {
                canceledAKeyEvent.Raise();
            } 
        }
    }

    public void OnActivateSKey(InputAction.CallbackContext context)
    {
        if(pressedSKeyEvent != null && canceledSKeyEvent != null)
        {
            if(context.phase == InputActionPhase.Started)
            {
                pressedSKeyEvent.Raise();
            } 
            else if(context.phase == InputActionPhase.Canceled)
            {
                canceledSKeyEvent.Raise();
            } 
        }
    }

    public void OnActivateDKey(InputAction.CallbackContext context)
    {
        if(pressedDKeyEvent != null && canceledDKeyEvent != null)
        {
            if(context.phase == InputActionPhase.Started)
            {
                pressedDKeyEvent.Raise();
            } 
            else if(context.phase == InputActionPhase.Canceled)
            {
                canceledDKeyEvent.Raise();
            } 
        }
    }
    public void OnActivateFKey(InputAction.CallbackContext context)
    {
        if(pressedFKeyEvent != null && canceledFKeyEvent != null)
        {
            if(context.phase == InputActionPhase.Started)
            {
                pressedFKeyEvent.Raise();
            } 
            else if(context.phase == InputActionPhase.Canceled)
            {
                canceledFKeyEvent.Raise();
            } 
        }
    }

//-------------------------------------------------------------
// ADVENTURE LEVEL ACTIONS
//-------------------------------------------------------------

    public void OnMoveOnClick(InputAction.CallbackContext context)
    {
        if(moveOnClickEvent != null && context.phase == InputActionPhase.Performed)
        {
            Vector3 currentMousePos = Mouse.current.position.ReadValue();
            moveOnClickEvent.testProperty = currentMousePos;
            moveOnClickEvent.Raise(currentMousePos);
        }
    }*/
}

