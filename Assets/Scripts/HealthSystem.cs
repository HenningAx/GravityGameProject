using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class HealthSystem : MonoBehaviour {

    public float FdefaultHealth = 100.0f;
    public float FmaxDamage = 20.0f;
    public float FdamageMultiplier = 1.0f;
    public float FcollisionCooldown = 0.5f;
    public float FvelocityThreshold = 2.0f;
    public float FhealTime = 5.0f;
    public float FflashIntensity = 0.3f;
    public float FoverlayFadeSpeed = 1.0f;
    public GameObject GdeathParent;
    public Color flashColor;

    public GameObject GdamageUI;

    float FcurrentHealth;
    bool BonCooldown = false;
    Image damageOverlayImage;
    Animator damageUIAni;
    Texture test;
	// Use this for initialization
	void Start () {
        damageOverlayImage = GdamageUI.transform.FindChild("DamageOverlay").GetComponent<Image>();
        FcurrentHealth = FdefaultHealth;
        damageUIAni = GdamageUI.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "PickUp" || col.collider.tag == "DamagePlayer")
        {
            if (!BonCooldown)
            {
                if (col.rigidbody.velocity.sqrMagnitude > FvelocityThreshold * FvelocityThreshold && col.rigidbody.useGravity)
                {
                    float damage = Vector3.Dot(col.contacts[0].normal, col.relativeVelocity) * col.rigidbody.mass * FdamageMultiplier;
                    Debug.Log("Acctual Damage = " + damage);
                    float clampedDamage = Mathf.Clamp(damage, 0.0f, FmaxDamage);
                    TakeDamage(clampedDamage);
                } else
                {
                    Debug.Log("NotEnoughVelocity");
                }
            } else
            {
                Debug.Log("OnCooldown");
            }
        }
    }

    IEnumerator ResetCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        BonCooldown = false;
    }

    IEnumerator Heal(float delay)
    {
        yield return new WaitForSeconds(delay * 0.8f);
        float FstartTime = Time.time;
        float FfadeSpeed = damageOverlayImage.color.a / (delay * 0.2f);
        float FstartValue = damageOverlayImage.color.a;
        bool BisFading = true;

        while(BisFading)
        {
            float distCovered = (Time.time - FstartTime) * FfadeSpeed;
            print(distCovered);
            Color overlayColor = damageOverlayImage.color;
            overlayColor.a = Mathf.SmoothStep(FstartValue, 0.0f, distCovered * (1 / FstartValue));
            damageOverlayImage.color = overlayColor;
            if(distCovered >= FstartValue)
            {
                BisFading = false;
            }
            yield return null;
        }
        FcurrentHealth = FdefaultHealth;
        Debug.Log("healed");
    }

    public void TakeDamage(float damage)
    {
        if (!BonCooldown)
        {
            FcurrentHealth -= Mathf.Round(damage);
            StopAllCoroutines();
            BonCooldown = true;
            StartCoroutine(ResetCooldown(FcollisionCooldown));
            StartCoroutine(Heal(FhealTime));
            Color overlayColor = damageOverlayImage.color;
            overlayColor.a = (100 - FcurrentHealth) / 100 * 0.5f;
            damageOverlayImage.color = overlayColor;
            damageUIAni.SetTrigger("Flash");
            if(FcurrentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        GdeathParent.SetActive(true);
        Camera.main.transform.parent = GdeathParent.transform;
        GdeathParent.transform.parent = null;
        GdeathParent.GetComponent<Rigidbody>().AddTorque(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10), ForceMode.Impulse);
        GdeathParent.GetComponent<Rigidbody>().AddForce(Random.Range(0, 20), Random.Range(0, 20), Random.Range(0, 20), ForceMode.Impulse);
        Destroy(Camera.main.GetComponent<HeadBob>());
        Destroy(this.gameObject);
    }
}
