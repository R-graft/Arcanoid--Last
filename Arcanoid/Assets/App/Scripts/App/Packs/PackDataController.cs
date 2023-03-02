public class PackDataController
{
	private Pack _currentPack;

    public Pack[] PacksModels { get; private set; }

    private const int _defaultLevel = 0;

	public PackDataController(Pack[] packsModels)
	{
		PacksModels = packsModels;
    }

    public void Load(PackSaveData[] data, int level)
    {
        for (int i = 0; i < PacksModels.Length; i++)
        {
            PacksModels[i].EndedLevel = data[i].EndedLevel;

            PacksModels[i].isEnded = data[i].packIsended;

            PacksModels[i].isOpen = data[i].packIsOpen;

            if (PacksModels[i].startLevel <= level && PacksModels[i].finishLevel >= level)
                _currentPack = PacksModels[i];
        }
    }

    public void Save(PackSaveData[] data)
    {
        for (int i = 0; i < PacksModels.Length; i++)
        {
            data[i].EndedLevel = PacksModels[i].EndedLevel;

            data[i].packIsended = PacksModels[i].isEnded;

            data[i].packIsOpen = PacksModels[i].isOpen;
        }
    }

    public void SetLevelFrowView(int packIndex)
    {
        if (packIndex >= 0 && packIndex <= PacksModels.Length)
        {
            _currentPack = PacksModels[packIndex];

            if (_currentPack.isEnded)
            {
                _currentPack.EndedLevel = _defaultLevel;

                _currentPack.isEnded = false;
            }
        }
    }
    public Pack GetCurrentPack() => _currentPack;

    public int GetCurrentPackLevel() => _currentPack.EndedLevel+1;

    public int GetGlobalLevel() => _currentPack.EndedLevel + _currentPack.startLevel;

    public void LevelPass(int newLevel)
    {
        if (newLevel > _currentPack.finishLevel)
        {
            _currentPack.EndedLevel++;

            _currentPack.isEnded = true;

            _currentPack = PacksModels[_currentPack.packIndex + 1];

            _currentPack.isOpen = true;
        }
        else
        {
            _currentPack.EndedLevel++;
        }
    }
    public void SetPackDataToDefault(GameProgressData datas)
	{
        datas.packsDatas = new PackSaveData[PacksModels.Length];

        for (int i = 0; i < datas.packsDatas.Length; i++)
        {
            datas.packsDatas[i] = new PackSaveData();

            datas.packsDatas[i].packIndex = i;
        }

        foreach (var item in PacksModels)
        {
            item.EndedLevel = 0;
            item.isOpen = false;
            item.isEnded = false;
        }

        _currentPack = PacksModels[0];

        PacksModels[0].isOpen = true;

        PacksModels[0].EndedLevel = _defaultLevel;

        Save(datas.packsDatas);
    }

}
    [System.Serializable]
    public class PackSaveData
    {
        public int packIndex;

        public bool packIsOpen;

        public bool packIsended;

        public int EndedLevel;
    }
