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
    public PlayerStatus playerStatus;              //player가 가지고있는 Ingame Data
    [SerializeField]
    Rigidbody playerRigid;
    [SerializeField]
    Transform bulletsParent;
    [SerializeField]
    Animator playerAnimator;
    [SerializeField]
    GameObject bulletPrefab;

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
    float invincibilityTime = 5;                              //무적 지속시간
    float nowCoolTime = 0;                                  //무적 쿨타임 재기용 변수
    float invincibilityCoolTime = 30;                       //무적 쿨타임;
    bool isInvincibility = false;                           //무적 변수

    bool isDie = false;

    float leftMax = -GroundSpawner.roadWidth / 2;
    float rightMax = GroundSpawner.roadWidth / 2;

    private void Start()
    {
        SetPlayerStatus();

        StartPlayerMove();
        StartCoroutine(SetCoolTimeBarCoroutine());
    }

    void Update()
    {
        //Debug.Log(playerRigid.velocity);
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

        playerStatus.attackDamage += 0.1f * GameManager.gameManager.playerInfo.attackDamageReinforcementCount;

        maxHp = playerStatus.hp;
    }

    //플레이어가 일정 거리 이상을 달렸을 경우 이동속도를 증가시켜 난이도를 증가시킴
    public void SetPlayerSpeed()
    {
        playerStatus.maxForwardSpeed += 50;
        StartCoroutine(UpdateMoveSpeed());
    }

    #region Move Functions
    //전방으로 이동하기 시작하는 함수
    void StartPlayerMove()
    {
        StartCoroutine(StartPlayerMoveCoroutine());
    }

    //플레이어가 게임을 시작하고 1초 뒤에 이동 속도가 증가하도록 하는 함수
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
        Debug.Log("final : " + playerRigid.velocity);
        playerRigid.velocity = new Vector3(playerRigid.velocity.x, playerRigid.velocity.y, playerStatus.maxForwardSpeed);
    }

    //플레이어가 이동 거리에 따라 속도를 갱신하기 위해 만든 함수
    IEnumerator UpdateMoveSpeed()
    {
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

                    playerRigid.AddForce(new Vector3(playerStatus.sidespeed, 0, 0), ForceMode.Impulse);
                }
            }

            //아무것도 누르고 있지 않으면 그대로 직진
            else
            {
                playerRigid.velocity = new Vector3(0, 0, playerStatus.maxForwardSpeed);
            }

            // 추가: 좌우 이동 범위 제한
            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x, leftMax, rightMax);
            transform.position = newPosition;

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
        isJumping = true;
        playerAnimator.Play("Jump_HG01_Anim");

        while (this.transform.position.y <= 6)
        {
            playerRigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

        while (this.transform.position.y >= 0.2)
        {
            playerRigid.AddForce(new Vector3(0, downGravity, 0), ForceMode.Impulse);
            yield return null;
        }

        isJumping = false;
    }
    #endregion

    #region Action Functions(Shoot, invincibility , GetDamaged, DIe)
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
            bulletMoveDir = hit.point;
        }
        return bulletMoveDir;
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
        invincibilityTime += (float)GameManager.gameManager.playerInfo.speedReinforcementCount * 0.1f;

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
    #endregion
}
