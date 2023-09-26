using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    // 기본 능력치
    public int playerLevel; //레벨

    public int playerBasicHP; //체력
    public float playerBasicAttackRange; //사거리
    public int playerBasicAtk; //공격력
    public int playerBasicAtkSpeed;//공격속도
    public int playerBasicSpeed;//이동속도
    public int playerBasicCritChance;//크리티컬확률
    public int playerBasicCritDamage;//크리티컬데미지
    public int playerBasicCritResistance;//크리티컬저항
    public int playerBasicMissChance;//회피
    public int playerBasicDefense;//방어력

    // 현재 능력치
    public int playerHp;
    public float playerAttackRange;
    public int playerAtk;
    public int playerAtkSpeed;
    public int playerSpeed;
    public int playerCritChance;
    public int playerCritDamage;
    public int playerCritResistance;
    public int playerMissChance;
    public int playerDefense;


    private void Awake()
    {
        playerHp = playerBasicHP;
        playerAtk = playerBasicAtk;
        playerAtkSpeed = playerBasicAtkSpeed;
        playerSpeed = playerBasicSpeed;
        playerCritChance = playerBasicCritChance;
        playerCritDamage = playerBasicCritDamage;
        playerCritResistance = playerBasicCritResistance;
        playerMissChance = playerBasicMissChance;
        playerDefense = playerBasicDefense;
    }
    // 공격시 공격력이 음수라면? 그외의 스탯이 음수일 때도 생각해볼 것
    // 이동로직 어떻게 짤거..?
    // 장착 아이템..?

    // 이로운 효과를 받음 -----------------------------------------------------------------------------------------------------------------------------------------------------
    public void GetBuffHP_M(float _buffHP, float _duration) //최대체력 증가 버프 (버프량, 지속시간)
    {
        StartCoroutine(GetBuffHP_C(_buffHP, _duration));
    }

    IEnumerator GetBuffHP_C(float _buffHP, float _duration) //버프량은 정수로 바꾸고 더한뒤, 지속시간이 끝나면 초기 수치로 돌린다 다만 초기수치로 돌아갔을때, 현재체력이 최대체력을 같거나 넘어버린다면 현재체력은 최대체력이 된다.
    {
        playerBasicHP = playerBasicHP + ((int)_buffHP);
        yield return new WaitForSeconds(_duration);
        playerBasicHP = playerBasicHP - ((int)_buffHP);

        if (playerHp >= playerBasicHP)
        {
            playerHp = playerBasicHP;
        }
    }

    public void GetHealHP(float _buffHP) // 체력회복 함수 (회복량) / 현재체력 + 회복량을 했을때, 최대체력이 같거나 넘어버린다면 현재체력은 최대체력이 된다. 아닐 경우엔 현재체력에 회복량을 더한다.
    {
        if (playerHp + ((int)_buffHP) >= playerBasicHP)
        {
            playerHp = playerBasicHP;
        }

        else
        {
            playerHp = playerHp + ((int)_buffHP);
        }
    }

    public void GetBuffAttRange_M(float _buffRange, float _duration) //사거리 증가 버프 (버프량, 지속시간)
    {
        StartCoroutine(GetBuffAttRange_C(_buffRange, _duration));
    }

    IEnumerator GetBuffAttRange_C(float _buffRange, float _duration) //사거리 증가 코루틴. 현재 사거리에 버프량만큼 사거리를 증가 시키고, 지속시간만큼 기다린 뒤 증가치만큼 다시 감소한다.
    {
        playerAttackRange = playerAttackRange + _buffRange;
        yield return new WaitForSeconds(_duration);
        playerAttackRange = playerAttackRange - _buffRange;
    }

    public void GetBuffAtk_M(float _buffAtk, float _duration) // 공격력 증가 코루틴. 현재 공격력에 버프량만큼 더한다.
    {
        StartCoroutine(GetBuffAtk_C(_buffAtk, _duration));
    }

    IEnumerator GetBuffAtk_C(float _buffAtk, float _duration) // 공격력증가 코루틴, 현재 공격력에 버프량을 더하고, 지속시간만큼 기다린 뒤, 끝나면 더한만큼 감소한다.
    {
        playerAtk = playerAtk + ((int)_buffAtk);
        yield return new WaitForSeconds(_duration);
        playerAtk = playerAtk - ((int)_buffAtk);

    }

    public void GetBuffAtkSpeed_M(float _buffAtkSpeed, float _duration) //공격속도 증가 함수, (버프량, 지속시간)
    {
        StartCoroutine(GetBuffAtkSpeed_C(_buffAtkSpeed, _duration));
    }

    IEnumerator GetBuffAtkSpeed_C(float _buffAtkSpeed, float _duration) //공격속도 증가 코루틴. 현재 공격속도에 버프량만큼 더하고 지속시간만큼 기다린 뒤 더한만큼 감소한다.
    {
        playerAtkSpeed = playerAtkSpeed + ((int)_buffAtkSpeed);
        yield return new WaitForSeconds(_duration);
        playerAtkSpeed = playerAtkSpeed - ((int)_buffAtkSpeed);
    }

    public void GetBuffSpeed_M(float _buffSpeed, float _duration) // 이동속도 증가 함수. (버프량, 지속시간)
    {
        StartCoroutine(GetBuffSpeed_C(_buffSpeed, _duration));
    }

    IEnumerator GetBuffSpeed_C(float _buffSpeed, float _duration) //이동속도 증가 코루틴. 현재 이동속도에 버프량만큼 더한 뒤 지속시간만큼 기다린 뒤 더한만큼 감소한다.
    {
        playerSpeed = playerSpeed + ((int)_buffSpeed);
        yield return new WaitForSeconds(_duration);
        playerSpeed = playerSpeed - ((int)_buffSpeed);
    }

    public void GetBuffCritChance_M(float _buffCritChance, float _duration) // 치명타확률 증가 함수. (버프량, 지속시간)
    {
        StartCoroutine(GetBuffCritChance_C(_buffCritChance, _duration));
    }

    IEnumerator GetBuffCritChance_C(float _buffCritChance, float _duration) // 치명타확률 증가 코루틴. 현재 치명타확률에 버프량만큼 더한 뒤 지속시간만큼 기다린 뒤 증가량만큼 감소한다.
    {
        playerCritChance = playerCritChance + ((int)_buffCritChance);
        yield return new WaitForSeconds(_duration);
        playerCritChance = playerCritChance - ((int)_buffCritChance);
    }

    public void GetBuffCritDamage_M(float _buffCritDamage, float _duration) // 치명타 데미지 증가 함수. (버프량, 지속시간)
    {
        StartCoroutine(GetBuffCritDamage_C(_buffCritDamage, _duration));
    }

    IEnumerator GetBuffCritDamage_C(float _buffCritDamage, float _duration) // 치명타 데미지 증가 코루틴. 현재 치명타 데미지에 버프량만큼 더한 뒤 지속시간만큼 기다린 뒤 더한만큼 감소한다.
    {
        playerCritDamage = playerCritDamage + ((int)_buffCritDamage);
        yield return new WaitForSeconds(_duration);
        playerCritDamage = playerCritDamage - ((int)_buffCritDamage);
    }

    public void GetBuffCritResistance_M(float _buffCritResistance, float _duration) //치명타저항 증가 함수. (증가량, 지속시간)
    {
        StartCoroutine(GetBuffCritResistance_C(_buffCritResistance, _duration));
    }

    IEnumerator GetBuffCritResistance_C(float _buffCritResistance, float _duration) //치명타저항 증가 코루틴. 현재 치명타 저항에 버프량만큼 더한 뒤 지속시간만큼 기다린 후 증가량 만큼 감소한다.
    {
        playerCritResistance = playerCritResistance + ((int)_buffCritResistance);
        yield return new WaitForSeconds(_duration);
        playerCritResistance = playerCritResistance - ((int)_buffCritResistance);
    }

    public void GetBuffMissChance_M(float _buffMissChance, float _duration) //회피확률 증가 함수. (버프량, 지속시간)
    {
        StartCoroutine(GetBuffMissChance_C(_buffMissChance, _duration));
    }

    IEnumerator GetBuffMissChance_C(float _buffMissChance, float _duration) //회피확률 증가 코루틴 현재 회피확률에 버프량만큼 더한 뒤 지속시간만큼 기다린 후 증가량만큼 감소한다.
    {
        playerMissChance = playerMissChance + ((int)_buffMissChance);
        yield return new WaitForSeconds(_duration);
        playerMissChance = playerMissChance - ((int)_buffMissChance);
    }

    public void GetBuffDefense_M(float _buffDefense, float _duration) //방어력 증가 함수. (버프량, 지속시간)
    {
        StartCoroutine(GetBuffDefense_C(_buffDefense, _duration));
    }

    IEnumerator GetBuffDefense_C(float _buffDefense, float _duration) //방어력 증가 코루틴. 현재 방어력에 버프량만큼 더한 뒤 지속시간만큼 기다린 후 증가량만큼 감소한다.
    {
        playerDefense = playerDefense + ((int)_buffDefense);
        yield return new WaitForSeconds(_duration);
        playerDefense = playerDefense - ((int)_buffDefense);
    }

    // 이로운 효과를 받음 -----------------------------------------------------------------------------------------------------------------------------------------------------

    private void PlayerBasicAttackAction()
    {                                     
                                          
    }                                     
                                          
    protected virtual void PlayerUltiSkillAction()
    {

    }

    protected virtual void PlayerNormalSkillAction()
    {

    }

    protected virtual void PlayerUpgradeSkillAction()
    {

    }

    protected virtual void PlayerPassiveAction()
    {

    }

    public void GetDamage(float _damage)
    {
        //데미지 계산을 어디서 할까 / 받는쪽에서 하죠?

        if (playerHp >= 0)
        {
            DownAction();
        }
    }

    public void DownAction()
    {

    }
}
