using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float speed;
    public float force;
    public Rigidbody2D rigidbody;
    public GroundDetector groundDetector;
    private Vector3 direction;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool isJumping;
    public GameObject magicPiece;
    public Transform spawnMagic;
    public bool isReadyToAttack;
    public float interval;

    void FixedUpdate()
    {
        animator.SetBool("isGrounded",groundDetector.isGrounded);
        if(!isJumping&&!groundDetector.isGrounded)
            animator.SetTrigger("Fall");
        isJumping=isJumping&&!groundDetector.isGrounded;
        direction = Vector3.zero;
        if(Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
        }
        if(Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
        }
        direction*=speed;
        direction.y = rigidbody.velocity.y;
        rigidbody.velocity = direction;
        if(Input.GetKeyDown(KeyCode.Space)&&groundDetector.isGrounded==true)
        {
            rigidbody.AddForce(Vector2.up*force,ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            isJumping=true;
        }
        if(direction.x<0)
            spriteRenderer.flipX=true;
         if(direction.x>0)
            spriteRenderer.flipX=false;
        animator.SetFloat("speed",Mathf.Abs(direction.x));
    }

    void Update() 
    {
        if(Input.GetMouseButtonDown(0)&&groundDetector.isGrounded==true&&isReadyToAttack==true)
        {
            animator.SetTrigger("Attack");
            isReadyToAttack=false;
            StartCoroutine(ReadyToAttack());
        }
    }
    private void OnTriggerEnter2D(Collider2D coll) 
    {
        if(coll.gameObject.tag=="Coin")
        {
            Inventary.Instance.AddCoins();
            Destroy(coll.gameObject);
        }
    }
    IEnumerator ReadyToAttack()
    {
        yield return new WaitForSeconds(0.45f);
        Instantiate(magicPiece,spawnMagic.position,Quaternion.identity);
        yield return new WaitForSeconds(interval);
        isReadyToAttack=true;
    }

}
