using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public TMPro.TMP_Text hitText;
    // Start is called before the first frame update
    void Start()
    {
    }

    IEnumerator clearText()
    {
        yield return new WaitForSeconds(2);
        hitText.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShootRay();
        }
    }
    
    IEnumerator destroyThis(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        Destroy(obj);
    }

    void ShootRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position + this.transform.forward * 2, this.transform.forward, out hit))
        {

            if (hit.transform.tag == "Target")
            {
                hitText.text = "Hit";
                ParticleSystem ps = hit.transform.GetComponentInChildren<ParticleSystem>();
                if (!ps.isPlaying) {
                    ps.transform.SetParent(null);
                    ps.Play();
                    Destroy(hit.transform.gameObject);
                    StartCoroutine(destroyThis(ps.gameObject));
                }
            }
            else
            {
                hitText.text = "Missed";
            }
            StartCoroutine(clearText());
        }
    }
}
