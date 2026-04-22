using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class balaController : MonoBehaviour
{

    public GameObject prefabTiro;

    Transform spawnCima;
    Transform spawnBaixo;
    Transform spawnEsquerda;
    Transform spawnDireita;
    
    Transform tiroSpawn;

    Vector2 tiroDirecaoVector;

    bool canShoot = true;

    private IEnumerator startTiro;
    public float tiroSpeed = 20f;
    public float tiroCooldown = 0.5f;
    public float tiroVida = 3f;

    public void Start()
    {
        spawnCima = GameObject.Find("spawnCima").GetComponent<Transform>();
        spawnBaixo = GameObject.Find("spawnBaixo").GetComponent<Transform>();
        spawnEsquerda = GameObject.Find("spawnEsquerda").GetComponent<Transform>();
        spawnDireita = GameObject.Find("spawnDireita").GetComponent<Transform>();
    }

    public void Tiro(InputAction.CallbackContext context)
    {
        tiroDirecaoVector = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);

        if(canShoot){

            switch ((tiroDirecaoVector.x, tiroDirecaoVector.y)){
                case (0, 1):
                    tiroSpawn = spawnCima;

                    break;
                
                case (0, -1):
                    tiroSpawn = spawnBaixo;

                    break;

                case (1, 0):
                    tiroSpawn = spawnDireita;

                    break;
                
                case (-1, 0):
                    tiroSpawn = spawnEsquerda;

                    break;
            }

            //Debug.Log(tiroSpawn.position);

            startTiro = Atirar(tiroSpawn);
            StartCoroutine(startTiro);
        }
    }

    IEnumerator Atirar(Transform tiroSpawn){

        GameObject tiroClone;

        canShoot = false;

        tiroClone = Instantiate(prefabTiro, tiroSpawn.position, tiroSpawn.rotation);
        tiroClone.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(tiroSpawn.localPosition.x * tiroSpeed, tiroSpawn.localPosition.y * tiroSpeed);

        yield return new WaitForSeconds(tiroCooldown);

        canShoot = true;

        yield return new WaitForSeconds(tiroVida);

        Destroy(tiroClone);
    }
}
