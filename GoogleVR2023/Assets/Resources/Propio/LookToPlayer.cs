using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToPlayer : MonoBehaviour
{
    public GameObject character;
    public Transform player; // Referencia al jugador
    public float rotationSpeed = 2.0f; // Velocidad de rotación del NPC
    private Animator animator;

    public bool hasToRotate = true;
    private bool isPlayerClose = false;
    private float timeToWait = 2f; // Tiempo que espera (2 segundos)
    private float referenceTime;

    void Start()
    {
       animator = character.GetComponent <Animator>(); 
    }

    void Update()
    {

        if (animator.GetBool("Player_close")) 
        {
            // si ya se alejó espera "timeToWait" segundos para cambiar de animacion
            if(!isPlayerClose) {
                if(Time.time - referenceTime >= timeToWait) {
                    animator.SetBool("Player_close", false);
                }
            }

            LookAtTarget(player.position);
        }
    }

    void LookAtTarget(Vector3 targetPosition)
    {
        if(!hasToRotate) {
            return ;

        }

        // Obtenemos la dirección hacia la que queremos mirar
        Vector3 directionToLook = targetPosition - transform.position;
        directionToLook.y = 0; // Esto evita que el NPC incline su cabeza hacia arriba o abajo, puedes removerlo si prefieres que sí lo haga.

        // Calculamos la rotación necesaria para mirar hacia esa dirección
        Quaternion targetRotation = Quaternion.LookRotation(directionToLook);

        // Suavemente rotamos hacia esa dirección
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            animator.SetBool("Player_close", true);
            isPlayerClose = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            referenceTime = Time.time;
            isPlayerClose = false;
        }
    }
}
