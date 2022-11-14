using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private PlayerControls playerInput;
    [SerializeField]
    private float forwardSpeed = .5f;
    [SerializeField]
    private float lateralSpeed = .5f;


    private void Awake()
    {
        playerInput = new PlayerControls();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public Vector2 GetDirection()
    {
        return playerInput.Player.Move.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetDirection());
        transform.Translate(new Vector3(GetDirection().x * lateralSpeed, 0, 1 * forwardSpeed) * Time.deltaTime);
    }
}
