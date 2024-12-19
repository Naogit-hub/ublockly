public interface IProgrammable
{
    /// <summary>
    /// 関連づいたワークスペースを表示させる。
    /// </summary>
    public void ShowWorkspace();

    /// <summary>
    /// 関連づいたワークスペースを非表示にする。
    /// </summary>
    public void DeleteWorkspace();

    /// <summary>
    /// オブジェクトを初期配置に戻す。
    /// </summary>
    public void Reset();
}