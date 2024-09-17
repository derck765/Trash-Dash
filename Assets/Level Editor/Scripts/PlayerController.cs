using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClearSky
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float movePower = 10f;
        [SerializeField]
        float KickBoardMovePower = 15f;
        [SerializeField]
        float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5
        [SerializeField]
        int lifeCount = 3;
        [SerializeField]
        string sceneName;
        [SerializeField]
        AudioClip hurt;
        [SerializeField]
        AudioClip jump;

        Transitions temp;

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        private bool isKickboard = false;

        void Start()
        {
            temp = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<Transitions>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            lifeCount = 3;
        }

        private void Update()
        {
            if (alive)
            {
                Attack();
                Jump();
                Run();
                Restart();
                Quit();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            anim.SetBool("isJump", false);
            if (collision.gameObject.tag == "Enemy")
            {
                Hurt();
                Die();
            }
        }
        void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && isKickboard)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !isKickboard)
            {
                isKickboard = true;
                anim.SetBool("isKickBoard", true);
            }

        }

        void Run()
        {
            if (!isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                anim.SetBool("isRun", false);


                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 1, 1);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 1, 1);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                }
                transform.position += moveVelocity * movePower * Time.deltaTime;

            }
            if (isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 1, 1);
                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 1, 1);
                }
                transform.position += moveVelocity * KickBoardMovePower * Time.deltaTime;
            }
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                AudioSource.PlayClipAtPoint(jump, transform.position);
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("attack");
            }
        }
        void Hurt()
        {
            anim.SetTrigger("hurt");
            if (direction == 1 && lifeCount > 0)
            {
                AudioSource.PlayClipAtPoint(hurt, transform.position);
                lifeCount -= 1;
                rb.velocity = Vector2.zero;

                Vector2 jumpVelocity = new Vector2(0, 10f);
                rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

                isJumping = false;
                rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            }
            else
            if (lifeCount > 0)
            {
                AudioSource.PlayClipAtPoint(hurt, transform.position);
                lifeCount -= 1;
                rb.velocity = Vector2.zero;

                Vector2 jumpVelocity = new Vector2(0, 10f);
                rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

                isJumping = false;
                rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (lifeCount == 0)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");
                alive = false;
                temp.LoadScene(sceneName);
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                temp.ReloadScene();
            }
        }

        void Quit()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                temp.Exit();
            }
        }
    }
}

