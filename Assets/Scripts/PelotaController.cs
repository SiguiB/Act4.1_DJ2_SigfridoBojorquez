using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
  public Rigidbody rb;
  public float fuerzaImpulso = 3;

  private bool ignoraNextcollision;

  private Vector3 startPosition;

  private void Start()
  {
    startPosition = transform.position;
  }

  private void OnCollisionEnter(Collision collision)
  {

    if(ignoraNextcollision)
    {
        return;
    }
    
    DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
    if (deathPart){

      GameManager.singleton.RestartLevel();
    }

    rb.velocity = Vector3.zero;
    rb.AddForce(Vector3.up*fuerzaImpulso, ForceMode.Impulse);

    ignoraNextcollision = true;
    Invoke("PermitirNextCollision", 0.2f);
  }

  private void PermitirNextCollision()
  {
    ignoraNextcollision = false;
  }

  public void ResetPelota()
  {
    transform.position = startPosition;
  }
}
