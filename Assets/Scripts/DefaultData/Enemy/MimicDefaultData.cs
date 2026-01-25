using UnityEngine;

[CreateAssetMenu(fileName = "MimicDefaultData", menuName = "Enemy/MimicDefaultData")]
public class MimicDefaultData : CharacterDefaultData
{
    public override void CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<MimicRuntimeData>(id, out _)) return;

        var data = new MimicRuntimeData(this);
        repository.RegisterData(id, data);
    }
}
