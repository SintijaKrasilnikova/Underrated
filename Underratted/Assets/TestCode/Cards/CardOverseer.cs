using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardOverseer : ScriptableObject
{
    //Health
    [SerializeField]

	private bool _HealthHealth;

	public bool HealthHealth
    {
		get { return _HealthHealth; }
		set { _HealthHealth = value; }
	}

    [SerializeField]
    private bool _HealthAttack;

    public bool HealthAttack
    {
        get { return _HealthAttack; }
        set { _HealthAttack = value; }
    }

    [SerializeField]
    private bool _HealthSpeed;

	public bool HealthSpeed
	{
		get { return _HealthSpeed; }
		set { _HealthSpeed = value; }
	}

    //Attack

    [SerializeField]
    private bool _AttackAttack;

	public bool AttackAttack
	{
		get { return _AttackAttack; }
		set { _AttackAttack = value; }
	}

    [SerializeField]
    private bool _AttackSpeed;

    public bool AttackSpeed
    {
        get { return _AttackSpeed; }
        set { _AttackSpeed = value; }
    }

    //Speed
    [SerializeField]
    private bool _SpeedSpeed;

    public bool SpeedSpeed
    {
        get { return _SpeedSpeed; }
        set { _SpeedSpeed = value; }
    }

    //dodge
    [SerializeField]
    private bool _Dodge;

    public bool DodgeActive
    {
        get { return _Dodge; }
        set { _Dodge = value; }
    }

    //Current Health
    [SerializeField]

    private int _CurrentHealth;

    public int CurrentHealth
    {
        get { return _CurrentHealth; }
        set { _CurrentHealth = value; }
    }

    ////Current Health

    //private bool _StartHealthSet = false;

    //public bool StartHealthSet
    //{
    //    get { return _StartHealthSet; }
    //    set { _StartHealthSet = value; }
    //}

    public List<int> halfCards = new List<int>();
    public List<int> fullCards = new List<int>();
    public List<int> loadoutCards = new List<int>();
    public List<int> loadoutCardUse = new List<int>();
    public float rechargeAmount;
    public List<float> loadoutCardRecharge = new List<float>();
    public bool firstRun = false;

    public int cardsEquippedInLoadout = 0;

    public void rechargeCards()
    {
        loadoutCardRecharge[0] += rechargeAmount;
        loadoutCardRecharge[1] += rechargeAmount;
        loadoutCardRecharge[2] += rechargeAmount;
        loadoutCardRecharge[3] += rechargeAmount;
        loadoutCardRecharge[4] += rechargeAmount;
        loadoutCardRecharge[5] += rechargeAmount;

    }
}
    
