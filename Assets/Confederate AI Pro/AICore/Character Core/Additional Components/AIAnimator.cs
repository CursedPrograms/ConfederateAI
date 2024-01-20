using UnityEngine;

[DisallowMultipleComponent]
public class AIAnimator : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void isRunning()
    {
        anim.SetTrigger("isRunning");
    }

    public void isWalking()
    {
        anim.SetTrigger("isWalking");
    }

    public void isIdle()
    {
        anim.SetTrigger("isIdle");
    }

    public void isLevel()
    {
        anim.SetTrigger("isLevel");
    }

    public void isAttack01()
    {
        anim.SetTrigger("isAttacking01");
    }

    public void isAttack02()
    {
        anim.SetTrigger("isAttacking02");
    }

    public void isAttack03()
    {
        anim.SetTrigger("isAttacking03");
    }

    public void isDead()
    {
        anim.SetTrigger("isDead");
        anim.enabled = false;
    }
}
