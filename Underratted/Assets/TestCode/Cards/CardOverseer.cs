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


}
    
