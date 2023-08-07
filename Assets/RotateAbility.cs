using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAbility : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject thisGM;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Transmitter"))
        {
            other.gameObject.GetComponent<ObjectInteraction>().oneSideRotate = false;
            other.gameObject.GetComponent<ObjectInteraction>().MakeBlue();
            Instantiate(particle, transform.position, Quaternion.identity);
            Sound.Instance.ability.Play();
            Destroy(thisGM);
        }
    }
}
