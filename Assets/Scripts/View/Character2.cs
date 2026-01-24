using UnityEngine;

public class Character2 : CharacterInput
{
    public override void TargetSetting()
    {
        _target = GameObject.FindWithTag("Enemy").transform.position;
    }
}
