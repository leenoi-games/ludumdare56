using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ActionMapType
{
    Player,
    UI,
    MusicLevel,
    Dialogue,
    PointnClick
}

[CreateAssetMenu(fileName = "InputManager", menuName = "Managers/InputManager", order = 0)]
public class InputManager : ScriptableObject
{
    [SerializeField] InputActions playerInput;
    //[SerializeField] CodedGameStateEventListener gameStateEventListener;
    //[SerializeField] FloatEvent instantiatedPlayerInput;

    private void OnEnable() 
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        if(playerInput == null)
        {
            playerInput = new InputActions();
        }
        //gameStateEventListener?.OnEnableEvent(ChangeActionMap);
    }

    private void OnDisable()
    {
        //gameStateEventListener?.OnDisable();
    }

/*
    private void ChangeActionMap(GameState gameState)
    {
        playerInput.Disable();
        switch(gameState)
        {
            case GameState.Adventure:
                playerInput.Player.Enable();
                Debug.Log("Enableing Player Controls");
                return;
            case GameState.Menu:
                playerInput.UI.Enable();
                return;
            case GameState.Dialogue:
                playerInput.Dialogue.Enable();
                Debug.Log("Enableing Dialogue Controls");
                return;
            case GameState.MusicLevel:
                playerInput.MusicLevel.Enable();
                Debug.Log("Enableing Music Level Controls");
                return;
            case GameState.PointnClick:
                playerInput.PointnClick.Enable();
                Debug.Log("Enableing PointnClick Controls");
                return;
            case GameState.Cutscene:
                playerInput.Cutscene.Enable();
                return;
            default:
                playerInput.Player.Enable();
                return;
        }
    }*/
    
    public InputActions GetPlayerInput()
    {
        return playerInput;
    }
}