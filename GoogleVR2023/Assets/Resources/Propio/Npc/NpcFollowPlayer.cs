using System.Collections;
using UnityEngine;
using DialogueEditor;

public class NpcFollowPlayer : MonoBehaviour
{
    public Transform character;
    public Transform player; // Referencia al jugador
    public float followDistance = 7.0f; // Distancia a la que el NPC comenzará a seguir al jugador
    public float stopDistance = 3.0f; // Distancia a la que el NPC se detendrá antes de alcanzar al jugador

    public NPCConversation conversacionAlAlejarse;

    private bool isFollowing = false;

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
        // Si el jugador está a una distancia mayor que 'followDistance', el NPC se detiene
        else if (distanceToPlayer >= followDistance)
        {
            isFollowing = false;
            StopFollowing();
            
        }
    }

    void FollowPlayer()
    {
        if( player.GetComponent<ActManager>().actNumber != 0) {
            isFollowing = false;
            return;
        }

        animator.SetBool("Caminando", true);
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
    }

    void StopFollowing()
    {
        animator.SetBool("Caminando", false);
    }

}