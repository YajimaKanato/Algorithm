using UnityEngine;

[CreateAssetMenu(fileName = "EyeBallDefaultData", menuName = "Enemy/EyeBallDefaultData")]
public class EyeBallDefaultData : CharacterDefaultData
{
    public override void CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<EyeBallRuntimeData>(id, out _)) return;

        var data = new EyeBallRuntimeData(this);
        repository.RegisterData(id, data);
    }
}
