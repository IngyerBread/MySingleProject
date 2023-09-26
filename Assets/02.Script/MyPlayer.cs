using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    // �⺻ �ɷ�ġ
    public int playerLevel; //����

    public int playerBasicHP; //ü��
    public float playerBasicAttackRange; //��Ÿ�
    public int playerBasicAtk; //���ݷ�
    public int playerBasicAtkSpeed;//���ݼӵ�
    public int playerBasicSpeed;//�̵��ӵ�
    public int playerBasicCritChance;//ũ��Ƽ��Ȯ��
    public int playerBasicCritDamage;//ũ��Ƽ�õ�����
    public int playerBasicCritResistance;//ũ��Ƽ������
    public int playerBasicMissChance;//ȸ��
    public int playerBasicDefense;//����

    // ���� �ɷ�ġ
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
    // ���ݽ� ���ݷ��� �������? �׿��� ������ ������ ���� �����غ� ��
    // �̵����� ��� ©��..?
    // ���� ������..?

    // �̷ο� ȿ���� ���� -----------------------------------------------------------------------------------------------------------------------------------------------------
    public void GetBuffHP_M(float _buffHP, float _duration) //�ִ�ü�� ���� ���� (������, ���ӽð�)
    {
        StartCoroutine(GetBuffHP_C(_buffHP, _duration));
    }

    IEnumerator GetBuffHP_C(float _buffHP, float _duration) //�������� ������ �ٲٰ� ���ѵ�, ���ӽð��� ������ �ʱ� ��ġ�� ������ �ٸ� �ʱ��ġ�� ���ư�����, ����ü���� �ִ�ü���� ���ų� �Ѿ�����ٸ� ����ü���� �ִ�ü���� �ȴ�.
    {
        playerBasicHP = playerBasicHP + ((int)_buffHP);
        yield return new WaitForSeconds(_duration);
        playerBasicHP = playerBasicHP - ((int)_buffHP);

        if (playerHp >= playerBasicHP)
        {
            playerHp = playerBasicHP;
        }
    }

    public void GetHealHP(float _buffHP) // ü��ȸ�� �Լ� (ȸ����) / ����ü�� + ȸ������ ������, �ִ�ü���� ���ų� �Ѿ�����ٸ� ����ü���� �ִ�ü���� �ȴ�. �ƴ� ��쿣 ����ü�¿� ȸ������ ���Ѵ�.
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

    public void GetBuffAttRange_M(float _buffRange, float _duration) //��Ÿ� ���� ���� (������, ���ӽð�)
    {
        StartCoroutine(GetBuffAttRange_C(_buffRange, _duration));
    }

    IEnumerator GetBuffAttRange_C(float _buffRange, float _duration) //��Ÿ� ���� �ڷ�ƾ. ���� ��Ÿ��� ��������ŭ ��Ÿ��� ���� ��Ű��, ���ӽð���ŭ ��ٸ� �� ����ġ��ŭ �ٽ� �����Ѵ�.
    {
        playerAttackRange = playerAttackRange + _buffRange;
        yield return new WaitForSeconds(_duration);
        playerAttackRange = playerAttackRange - _buffRange;
    }

    public void GetBuffAtk_M(float _buffAtk, float _duration) // ���ݷ� ���� �ڷ�ƾ. ���� ���ݷ¿� ��������ŭ ���Ѵ�.
    {
        StartCoroutine(GetBuffAtk_C(_buffAtk, _duration));
    }

    IEnumerator GetBuffAtk_C(float _buffAtk, float _duration) // ���ݷ����� �ڷ�ƾ, ���� ���ݷ¿� �������� ���ϰ�, ���ӽð���ŭ ��ٸ� ��, ������ ���Ѹ�ŭ �����Ѵ�.
    {
        playerAtk = playerAtk + ((int)_buffAtk);
        yield return new WaitForSeconds(_duration);
        playerAtk = playerAtk - ((int)_buffAtk);

    }

    public void GetBuffAtkSpeed_M(float _buffAtkSpeed, float _duration) //���ݼӵ� ���� �Լ�, (������, ���ӽð�)
    {
        StartCoroutine(GetBuffAtkSpeed_C(_buffAtkSpeed, _duration));
    }

    IEnumerator GetBuffAtkSpeed_C(float _buffAtkSpeed, float _duration) //���ݼӵ� ���� �ڷ�ƾ. ���� ���ݼӵ��� ��������ŭ ���ϰ� ���ӽð���ŭ ��ٸ� �� ���Ѹ�ŭ �����Ѵ�.
    {
        playerAtkSpeed = playerAtkSpeed + ((int)_buffAtkSpeed);
        yield return new WaitForSeconds(_duration);
        playerAtkSpeed = playerAtkSpeed - ((int)_buffAtkSpeed);
    }

    public void GetBuffSpeed_M(float _buffSpeed, float _duration) // �̵��ӵ� ���� �Լ�. (������, ���ӽð�)
    {
        StartCoroutine(GetBuffSpeed_C(_buffSpeed, _duration));
    }

    IEnumerator GetBuffSpeed_C(float _buffSpeed, float _duration) //�̵��ӵ� ���� �ڷ�ƾ. ���� �̵��ӵ��� ��������ŭ ���� �� ���ӽð���ŭ ��ٸ� �� ���Ѹ�ŭ �����Ѵ�.
    {
        playerSpeed = playerSpeed + ((int)_buffSpeed);
        yield return new WaitForSeconds(_duration);
        playerSpeed = playerSpeed - ((int)_buffSpeed);
    }

    public void GetBuffCritChance_M(float _buffCritChance, float _duration) // ġ��ŸȮ�� ���� �Լ�. (������, ���ӽð�)
    {
        StartCoroutine(GetBuffCritChance_C(_buffCritChance, _duration));
    }

    IEnumerator GetBuffCritChance_C(float _buffCritChance, float _duration) // ġ��ŸȮ�� ���� �ڷ�ƾ. ���� ġ��ŸȮ���� ��������ŭ ���� �� ���ӽð���ŭ ��ٸ� �� ��������ŭ �����Ѵ�.
    {
        playerCritChance = playerCritChance + ((int)_buffCritChance);
        yield return new WaitForSeconds(_duration);
        playerCritChance = playerCritChance - ((int)_buffCritChance);
    }

    public void GetBuffCritDamage_M(float _buffCritDamage, float _duration) // ġ��Ÿ ������ ���� �Լ�. (������, ���ӽð�)
    {
        StartCoroutine(GetBuffCritDamage_C(_buffCritDamage, _duration));
    }

    IEnumerator GetBuffCritDamage_C(float _buffCritDamage, float _duration) // ġ��Ÿ ������ ���� �ڷ�ƾ. ���� ġ��Ÿ �������� ��������ŭ ���� �� ���ӽð���ŭ ��ٸ� �� ���Ѹ�ŭ �����Ѵ�.
    {
        playerCritDamage = playerCritDamage + ((int)_buffCritDamage);
        yield return new WaitForSeconds(_duration);
        playerCritDamage = playerCritDamage - ((int)_buffCritDamage);
    }

    public void GetBuffCritResistance_M(float _buffCritResistance, float _duration) //ġ��Ÿ���� ���� �Լ�. (������, ���ӽð�)
    {
        StartCoroutine(GetBuffCritResistance_C(_buffCritResistance, _duration));
    }

    IEnumerator GetBuffCritResistance_C(float _buffCritResistance, float _duration) //ġ��Ÿ���� ���� �ڷ�ƾ. ���� ġ��Ÿ ���׿� ��������ŭ ���� �� ���ӽð���ŭ ��ٸ� �� ������ ��ŭ �����Ѵ�.
    {
        playerCritResistance = playerCritResistance + ((int)_buffCritResistance);
        yield return new WaitForSeconds(_duration);
        playerCritResistance = playerCritResistance - ((int)_buffCritResistance);
    }

    public void GetBuffMissChance_M(float _buffMissChance, float _duration) //ȸ��Ȯ�� ���� �Լ�. (������, ���ӽð�)
    {
        StartCoroutine(GetBuffMissChance_C(_buffMissChance, _duration));
    }

    IEnumerator GetBuffMissChance_C(float _buffMissChance, float _duration) //ȸ��Ȯ�� ���� �ڷ�ƾ ���� ȸ��Ȯ���� ��������ŭ ���� �� ���ӽð���ŭ ��ٸ� �� ��������ŭ �����Ѵ�.
    {
        playerMissChance = playerMissChance + ((int)_buffMissChance);
        yield return new WaitForSeconds(_duration);
        playerMissChance = playerMissChance - ((int)_buffMissChance);
    }

    public void GetBuffDefense_M(float _buffDefense, float _duration) //���� ���� �Լ�. (������, ���ӽð�)
    {
        StartCoroutine(GetBuffDefense_C(_buffDefense, _duration));
    }

    IEnumerator GetBuffDefense_C(float _buffDefense, float _duration) //���� ���� �ڷ�ƾ. ���� ���¿� ��������ŭ ���� �� ���ӽð���ŭ ��ٸ� �� ��������ŭ �����Ѵ�.
    {
        playerDefense = playerDefense + ((int)_buffDefense);
        yield return new WaitForSeconds(_duration);
        playerDefense = playerDefense - ((int)_buffDefense);
    }

    // �̷ο� ȿ���� ���� -----------------------------------------------------------------------------------------------------------------------------------------------------

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
        //������ ����� ��� �ұ� / �޴��ʿ��� ����?

        if (playerHp >= 0)
        {
            DownAction();
        }
    }

    public void DownAction()
    {

    }
}
