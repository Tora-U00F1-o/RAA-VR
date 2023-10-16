using System.Collections;
using UnityEngine;

public class NpcFollowPlayer : MonoBehaviour
{
    public Transform character;
    public Transform player; // Referencia al jugador
    public float followDistance = 5.0f; // Distancia a la que el NPC comenzará a seguir al jugador
    public float stopDistance = 1.0f; // Distancia a la que el NPC se detendrá antes de alcanzar al jugador
    public float actionRepeatInterval = 10.0f; // Intervalo de tiempo para repetir la acción si el jugador no se acerca

    private bool isFollowing = false;
    private float timeSinceLastAction = 0f;

    private Animator animator;

    void Start()
    {
        animator = character.GetComponent <Animator>(); 
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // Si el jugador está a una distancia menor que 'followDistance' y mayor que 'stopDistance', el NPC sigue al jugador
        if (distanceToPlayer < followDistance && distanceToPlayer > stopDistance)
        {
            isFollowing = true;
            FollowPlayer();
        }
        // Si el jugador se acerca demasiado al NPC, el NPC se detiene
        else if (distanceToPlayer <= stopDistance)
        {
            isFollowing = false;
            StopFollowing();
        }
        // Si el jugador está a una distancia mayor que 'followDistance', el NPC se detiene y realiza una acción
        else if (distanceToPlayer >= followDistance)
        {
            isFollowing = false;
            StopFollowing();
            timeSinceLastAction += Time.deltaTime;
            
            if(timeSinceLastAction >= actionRepeatInterval)
            {
                PerformAction();
                timeSinceLastAction = 0f;
            }
        }
    }

    void FollowPlayer()
    {
        animator.SetBool("Caminando", true);
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
    }

    void StopFollowing()
    {
        animator.SetBool("Caminando", false);
        // Aquí puedes agregar cualquier lógica adicional cuando el NPC se detiene
        PerformAction();
    }

    void PerformAction()
    {
        // Aquí puedes definir la acción que quieres que realice el NPC
        // Por ejemplo, si quieres que el NPC muestre un mensaje, podrías hacer algo como:
        Debug.Log("El NPC realiza una acción.");
    }
}