using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    IngameManager ingameManager;

    [SerializeField]
    PlayerStatus playerStatus;              //player가 가지고있는 Ingame Data
    [SerializeField]
    Rigidbody playerRigid;
    [SerializeField]
    Transform bulletsParent;
    [SerializeField]
    Animator playerAnimator;
    [SerializeField]
    GameObject bulletPrefab;

    //JumpStatus
    int groundLayer = 1 << 8;
    [SerializeField] bool isJumping = false;                 //Jump가 2단 이상으로 되지 않도록 설정하는 변수
    [SerializeField] float jumpPower;
    [SerializeField] float downGravity;

    //Shoot Variable
    [SerializeField] Camera mainCamera;
    bool isShooting = false;

    float maxHp;
    [SerializeField]
    GameObject hpBarParent;
    [SerializeField]
    Image hpBarImage;

    //무적 변수
    [SerializeField]
    GameObject coolTimeBarParent;
    [SerializeField]
    Image CoolTimeBarImage;
    [SerializeField]
    TextMeshProUGUI invincibilityText;
    int invincibilityTime = 5;                              //무적 지속시간
    float nowCoolTime = 0;                                  //무적 쿨타임 재기용 변수
    float invincibilityCoolTime = 30;                       //무적 쿨타임;
    bool isInvincibility = false;                           //무적 변수

    bool isDie = false;

    private void Start()
    {
        SetPlayerStatus();

        StartPlayerMove();
        StartCoroutine(SetCoolTimeBarCoroutine());
    }

    void Update()
    {
        MoveSide();
        Jump();
        Shoot();
    }

    //게임이 시작하면 PlayerInfo에 있는 강화 수치만큼 Status 변경
    void SetPlayerStatus()
    {
        playerStatus = new PlayerStatus();

        playerStatus.hp += 0.1f * GameManager.gameManager.playerInfo.hpReinforcementCount;

        playerStatus.maxForwardSpeed += 0.1f * GameManager.gameManager.playerInfo.speedReinforcementCount;
        playerStatus.maxsideSpeed += 0.1f * GameManager.gameManager.playerInfo.speedReinforcementCount;

        playerStatus.attackDamage += 0.1f * GameManager.gameManager.playerInfo.attackDamageReinforcementCount;

        maxHp = playerStatus.hp;
    }

    public void SetPlayerSpeed()
    {
        playerStatus.maxForwardSpeed += 100;
    }

    #region Move Functions
    //전방으로 이동하기 시작하는 함수
    void StartPlayerMove()
    {
        StartCoroutine(StartPlayerMoveCoroutine());
    }

    IEnumerator StartPlayerMoveCoroutine()
    {
        yield return new WaitForSeconds(1f);
        ingameManager.isStageStart = true;                    //stage가 시작되었으므로 좌우로 이동 가능
        playerAnimator.SetBool("isRun", true);

        while (playerRigid.velocity.z <= playerStatus.maxForwardSpeed)
        {
            playerRigid.AddForce(new Vector3(0, 0, playerStatus.forwardspeed * 3));
            yield return null;
        }

        playerRigid.velocity = new Vector3(playerRigid.velocity.x, playerRigid.velocity.y, playerStatus.maxForwardSpeed);
    }

    //좌우로 이동하는 함수
    private void MoveSide()
    {
        if (isJumping)
            return;

        //Player가 이동하기 시작하면 좌우로 이동 가능하도록 조건을 걸음
        if (ingameManager.isStageStart)
        {
            //a를 누르면 왼쪽으로 이동
            if (Input.GetKey(KeyCode.A))
            {
                if (playerRigid.velocity.x > playerStatus.maxsideSpeed * (-1))
                {
                    if (Input.GetKey(KeyCode.D))
                        return;

                    Debug.Log("Move Left");
                    playerRigid.AddForce(new Vector3(playerStatus.sidespeed * (-1), 0, 0), ForceMode.Impulse);
                }
            }

            //d를 누르면 오른쪽으로 이동
            else if (Input.GetKey(KeyCode.D))
            {
                if (playerRigid.velocity.x < playerStatus.maxsideSpeed)
                {
                    if (Input.GetKey(KeyCode.A))
                        return;

                    Debug.Log("Move Right");
                    playerRigid.AddForce(new Vector3(playerStatus.sidespeed, 0, 0), ForceMode.Impulse);
                }
            }

            //아무것도 누르고 있지 않으면 그대로 직진
            else
            {
                playerRigid.velocity = new Vector3(0, 0, playerStatus.maxForwardSpeed);
            }
        }
    }

    void Jump()
    {
        if (isJumping)
            return;

        if (!ingameManager.isStageStart)
            return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(JumpCoroutine());   
        }
    }

    IEnumerator JumpCoroutine()
    {
        Debug.Log("Jump");
        isJumping = true;
        playerAnimator.Play("Jump_HG01_Anim");

        while (this.transform.position.y <= 7)
        {
            playerRigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            yield return null;
        }
        Debug.Log(this.transform.position);
        yield return new WaitForSeconds(0.1f);

        while (this.transform.position.y >= 0.2)
        {
            playerRigid.AddForce(new Vector3(0, downGravity, 0), ForceMode.Impulse);
            yield return null;
        }

        isJumping = false;
        Debug.Log("End");
    }

    #endregion

    void Shoot()
    {
        if (isShooting)
            return;

        if(Input.GetMouseButtonDown(0))
            StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        //총알 생성 및 위치 설정
        isShooting = true;
        playerAnimator.Play("ShootSingleshot_HG01_Anim");
        GameObject bulletInstance = Instantiate(bulletPrefab);
        bulletInstance.transform.SetParent(bulletsParent);
        bulletInstance.transform.position = this.transform.position;

        //총알 방향벡터 설정 + 데미지 설정
        bulletInstance.GetComponent<Bullet>().ShootBullet(SetBulletMoveDir());
        bulletInstance.GetComponent<Bullet>().attackDamage = playerStatus.attackDamage;

        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    //Return: 총알 방향 벡터
    Vector3 SetBulletMoveDir()
    {
        Vector3 bulletMoveDir = Vector3.zero;

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            bulletMoveDir = hit.point - new Vector3(0,0,transform.position.z);
        }
        
        bulletMoveDir.y = 0;
        bulletMoveDir.z += playerRigid.velocity.z;

        return bulletMoveDir * 1.3f;
    }

    //쿨타임이 지나면 무적상태 돌입
    IEnumerator SetInvincibilityCoroutine()
    {
        isInvincibility = true;
        invincibilityText.gameObject.SetActive(true);

        yield return new WaitForSeconds(invincibilityTime);
        isInvincibility = false;
        invincibilityText.gameObject.SetActive(false);
    }

    IEnumerator SetCoolTimeBarCoroutine()
    {
        yield return new WaitForSeconds(1);
        invincibilityTime += GameManager.gameManager.playerInfo.speedReinforcementCount;

        while (!ingameManager.isStageEnd)
        {
            //무적 상태가 아닐때 쿨타임이 돈다.
            if (!isInvincibility)
            {
                nowCoolTime += Time.fixedDeltaTime;

                if (nowCoolTime / invincibilityCoolTime < 1)
                    CoolTimeBarImage.fillAmount = nowCoolTime / invincibilityCoolTime;
                else
                {
                    nowCoolTime = 0;
                    CoolTimeBarImage.fillAmount = 0;
                    StartCoroutine(SetInvincibilityCoroutine());
                }
            }
            yield return null;
        }
    }

    public float ReturnAttackDamage()
    {
        return playerStatus.attackDamage;
    }

    public void GetDamaged(float getDamaged)
    {
        //무적이면 데미지 안받음
        if (isInvincibility)
            return;

        playerStatus.hp -= getDamaged;
        hpBarImage.fillAmount = playerStatus.hp / maxHp;

        if (playerStatus.hp <=0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDie)
            return;

        isDie = true;
        playerAnimator.SetBool("isDie", true);
        StopAllCoroutines();
        Time.timeScale = 0;

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            playerAnimator.speed = 0;
        }

        playerRigid.velocity = Vector3.zero;

        ingameManager.GameEnd();
    }
}
