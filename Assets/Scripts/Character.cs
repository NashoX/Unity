using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private float jumpBuffer = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private Transform interactionpoint;
    [SerializeField] private float interactionradius;
    [SerializeField] private LayerMask interactionlayer;
    private Collider2D[] interactables = new Collider2D[10]; // Permitir más de un interactuable en la zona

    private List<GameObject> activeVisualCues = new List<GameObject>(); // Lista de visual cues activos

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move();
        Jump();
        UpdateInteractables(); // Actualizar los visual cues constantemente

        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateInteractable();
        }
    }

    private void move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontal, vertical).normalized;
        rb.velocity = new Vector2(movement.x * movementSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer) != null;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpBufferCounter = jumpBuffer;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpBufferCounter = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionpoint.position, interactionradius);
    }

    private void UpdateInteractables()
    {
        int elements = Physics2D.OverlapCircleNonAlloc(interactionpoint.position, interactionradius, interactables, interactionlayer);

        // Desactivar todos los visual cues actuales
        foreach (var cue in activeVisualCues)
        {
            if (cue != null)
            {
                cue.SetActive(false);
            }
        }
        activeVisualCues.Clear();

        // Iterar sobre los interactuables detectados y activar los visual cues
        for (int i = 0; i < elements; i++)
        {
            var interactable = interactables[i].GetComponent<Iinteractable>();
            if (interactable != null)
            {
                var visualCue = interactable.GetVisualCue();
                if (visualCue != null)
                {
                    visualCue.SetActive(true); // Activar el visual cue continuamente
                    activeVisualCues.Add(visualCue);
                }
            }
        }
    }

    private void ActivateInteractable()
    {
        int elements = Physics2D.OverlapCircleNonAlloc(interactionpoint.position, interactionradius, interactables, interactionlayer);
        if (elements == 0)
        {
            Debug.Log("No interactables found");
            return;
        }

        var interactable = interactables[0].GetComponent<Iinteractable>();
        if (interactable != null)
        {
            interactable.Interact();
        }
    }
}
