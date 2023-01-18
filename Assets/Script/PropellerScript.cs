using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerScript : MonoBehaviour
{
    public Animator Anime;
    public float WaitSeconds;
    public BoxCollider WindArea;
    public void AnimationRunIt(string runit)
    {
        if (runit == "true")
        {
            Anime.SetBool("RunIt", true);
            WindArea.enabled = true;
        }
        else
        {
            Anime.SetBool("RunIt", false);
            StartCoroutine(AnimationTriggerIt());
            WindArea.enabled = false;
        }
    }
    IEnumerator AnimationTriggerIt()
    {
        yield return new WaitForSeconds(WaitSeconds);
        AnimationRunIt("true");
    }

}
