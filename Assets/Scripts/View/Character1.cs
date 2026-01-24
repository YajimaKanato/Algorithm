using UnityEngine;

public class Character1 : CharacterInput
{
    public override void TargetSetting()
    {
        _targets = FindObjectsByType<Node>(FindObjectsSortMode.None);
        _target = _targets[Random.Range(0, _targets.Length)].transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character2>())
        {
            TargetSetting();
            MoveSetting();
        }
    }
}
