using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterAgent _playerAgent;

    private Camera _playerCamera;

    public CharacterAgent PlayerAgent => _playerAgent;

    private void OnEnable()
    {
        // disable any statemachines-related components on player ship. this allows the player to be any ship that AI uses.
        NPC stateMachine = _playerAgent.GetComponent<NPC>();
        if (stateMachine) stateMachine.enabled = false;
        TargetDetector detector = _playerAgent.GetComponentInChildren<TargetDetector>();
        if (detector) detector.gameObject.SetActive(false);
    }

    private void Start()
    {
        _playerCamera = Camera.main;
    }

    private void Update()
    {
        // rotate weapon towards mouse
        Vector2 mouseWorldPosition = (Vector2)_playerCamera.ScreenToWorldPoint(Input.mousePosition);
        _playerAgent.RotateAgent(mouseWorldPosition - (Vector2)transform.position);
        // shoot weapon on input: LMB
        if (Input.GetMouseButton(0)) _playerAgent.UseWeapon();
    }

    private void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        _playerAgent.MoveAgent(new Vector2(inputX, inputY));
    }
}
