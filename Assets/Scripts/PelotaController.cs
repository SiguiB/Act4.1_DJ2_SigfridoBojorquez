using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
  public Rigidbody rb;
  public float fuerzaImpulso = 3f;

  private bool ignoraNextcollision;

  private Vector3 startPosition;

[HideInInspector]
  public int perfectPass;

  public float superSpeed = 8;

  private bool esSuperSpeedActiva;

  public int perfectPassCount = 1;

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
    if(esSuperSpeedActiva && !collision.transform.GetComponent<MetaController>())
    {
      Destroy(collision.transform.parent.gameObject,0.2f);
    }
    else
    {
      DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
      if (deathPart){

        GameManager.singleton.RestartLevel();
      }
    }

    rb.velocity = Vector3.zero;
    rb.AddForce(Vector3.up*fuerzaImpulso, ForceMode.Impulse);

    ignoraNextcollision = true;
    Invoke("PermitirNextCollision", 0.2f);

    perfectPass = 0;
    esSuperSpeedActiva = false;
  }

  private void Update()
  {
    if(perfectPass>=perfectPassCount && !esSuperSpeedActiva)
    {
      esSuperSpeedActiva = true;

      rb.AddForce(Vector3.down*superSpeed,ForceMode.Impulse);
    }
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
