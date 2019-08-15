using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour {

    Rigidbody2D rb2d;
    Animator animator;
    float angle;
    bool isDead;

    int jumpNum = 0;
 
    public float maxHeight;
    public float jumpVelocity;
    public float relativeVelocityX;
    public GameObject sprite;

 //   public AudioClip SoundJump;
    AudioSource SourceJump;
    public AudioClip AudioJump;
    public AudioClip AudioDead;

    public LoopScript ControllerHC;
    public GameObject ObjectHC;
    bool HumanStateHC;

    public bool IsDead()
    {
        return isDead;
    }

	// Use this for initialization
	void Awake () {

        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();

	}

    private void Start()
    {
        SourceJump = GetComponent<AudioSource>();
        ObjectHC = GameObject.Find("LoopBGM");
        ControllerHC = ObjectHC.GetComponent<LoopScript>();        
    }

    // Update is called once per frame
    void Update () {

        HumanStateHC = ControllerHC.GetComponent<LoopScript>().HumanStateRS;

        if(Input.GetButtonDown("Fire1") && HumanStateHC == true && transform.position.y < maxHeight && jumpNum <= 1)
        {
            Jump();

            jumpNum++;

            animator.SetBool("jump", true);
        }

        ApplyAngle();

        if (jumpNum == 0) {
            animator.SetBool("jump", false);
        }
    }

    public void Jump()
    {

        if(isDead)return;

        if (rb2d.isKinematic) return;

        SourceJump.PlayOneShot(AudioJump);

        rb2d.velocity = new Vector2(0.0f, jumpVelocity);

    }

    void ApplyAngle()
    {

        float targetAngle;
            

        if (isDead)
        {
            targetAngle = -90.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
        }

        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        jumpNum = 0;

        if(collision.gameObject.tag == "Side")
        {
            Camera.main.SendMessage("Clash");
            animator.SetBool("jump", true);

            SourceJump.PlayOneShot(AudioDead);

            isDead = true;
        }


    }

    public void SetSteerActive(bool active)
    {
        rb2d.isKinematic = !active;
    }
}
