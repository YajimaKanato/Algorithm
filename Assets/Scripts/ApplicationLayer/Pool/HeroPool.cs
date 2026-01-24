using UnityEngine;

public class HeroPool : CharacterPool
{
    [SerializeField] HeroDefaultData _data;

    public override CharacterInput Instantiate(CharacterInput character)
    {
        var go = Instantiate(character, new Vector3(5, 1, 0), Quaternion.identity);
        go.Init(_system, this);
        return go;
    }

    protected override void CreateRuntime(int id)
    {
        if (!_repository.TryGetData<HeroRuntimeData>(id, out _)) return;

        var data = new HeroRuntimeData(_data);
        _repository.RegisterData(id, data);
    }
}
