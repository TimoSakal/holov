using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    [SerializeField] GameObject objToMove, ropeStart;
    [SerializeField] GameObject leverArm;
    [SerializeField] LeverPlatform leverPlatform;
    bool canUse = true;
    [SerializeField] int limit = 2 ;
    [SerializeField] float moveDistance = 1.2f;
    bool reverse = false;
    [SerializeField] bool zmove, xmove, upmove;
    int counter;
    private void Start()
    {
        ropeStart.transform.SetParent(objToMove.transform);
    }
    private void OnMouseDown()
    {
        if (canUse && leverPlatform.canMove)
        {
            canUse = false;

            if (reverse == false)
            {

                MovePlatform(moveDistance);
            }
            else if (reverse == true)
            {
                MovePlatform(-moveDistance);
            }

           
            RotateLeverArm();

            StartCoroutine(LeverCD());
            counter++;
            if(counter>limit)
            {
                reverse = !reverse;
                counter = 0;
            }
        }
    }
    
    void MovePlatform(float moveTo)
    {
        if(upmove)
        {

        LeanTween.move(objToMove, new Vector3(objToMove.transform.position.x, objToMove.transform.position.y + moveTo, objToMove.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutCubic);
        }
        else if(xmove)
        {
        LeanTween.move(objToMove, new Vector3(objToMove.transform.position.x + moveTo, objToMove.transform.position.y , objToMove.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutCubic);

        }
        else if(zmove)
        {

        LeanTween.move(objToMove, new Vector3(objToMove.transform.position.x, objToMove.transform.position.y , objToMove.transform.position.z + moveTo), 0.5f).setEase(LeanTweenType.easeOutCubic);
        }
        if (leverPlatform.transmitter != null)
        {
            if(upmove)
            {
            LeanTween.move(leverPlatform.transmitter.transform.parent.gameObject, new Vector3(leverPlatform.transmitter.transform.parent.transform.position.x, leverPlatform.transmitter.transform.parent.transform.position.y + moveTo, leverPlatform.transmitter.transform.parent.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutCubic);

            }
            else if(xmove)
            {
            LeanTween.move(leverPlatform.transmitter.transform.parent.gameObject, new Vector3(leverPlatform.transmitter.transform.parent.transform.position.x + moveTo, leverPlatform.transmitter.transform.parent.transform.position.y , leverPlatform.transmitter.transform.parent.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutCubic);

            }
            else if (zmove)
            {
                LeanTween.move(leverPlatform.transmitter.transform.parent.gameObject, new Vector3(leverPlatform.transmitter.transform.parent.transform.position.x, leverPlatform.transmitter.transform.parent.transform.position.y, leverPlatform.transmitter.transform.parent.transform.position.z + moveTo), 0.5f).setEase(LeanTweenType.easeOutCubic);

            }
        }
    }
    void RotateLeverArm()
    {
        LeanTween.rotateAroundLocal(leverArm, Vector3.right, 90, 0.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() => {

            LeanTween.rotateAroundLocal(leverArm, Vector3.right, -90, 0.5f).setEase(LeanTweenType.easeOutBounce);
        });
    }
    IEnumerator LeverCD()
    {
        yield return new WaitForSeconds(1);
        canUse = true;
    }

}
