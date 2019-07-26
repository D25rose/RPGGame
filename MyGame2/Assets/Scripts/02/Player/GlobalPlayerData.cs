/// <summary>
/// 玩家全局属性管理类
/// </summary>
public class GlobalPlayerData {

    public static event GlobalParamters.del_VoidInt eventUpdateGoldNum;

    #region 单例
    private static GlobalPlayerData instance;
     
    public static GlobalPlayerData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GlobalPlayerData();
            }
            return instance;
        }
    }
    #endregion

    private int goldNum = 300;            //玩家拥有的金钱数
	
    public int GoldNum
    {
        get { return goldNum; }
        set { goldNum = value;
        }
    }

    private GlobalPlayerData() { }

    public void LoadGoldNumData(int num)
    {
        GoldNum = num;
    }

    /// <summary>
    /// 增加金钱（在UI场景中调用）
    /// </summary>
    public void AddGold( int num )
    {
        GoldNum += num;
        eventUpdateGoldNum(goldNum);
    }

    /// <summary>
    /// 增加金钱（在非UI场景中调用）
    /// </summary>
    public void AddGoldInOtherScene(int num)
    {
        GoldNum += num;
    }

    /// <summary>
    /// 消耗金钱
    /// </summary>
    public void ConsumGold( int num )
    {
        GoldNum -= num;
    }

}
