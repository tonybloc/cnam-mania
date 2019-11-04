using cnam_mania.Model.Episodes;
using cnam_mania.Settings;
using Monopoly.Service.Xml;

public class VisualNovelManager
{
    #region Variables
    /// <summary>
    /// VisualNovelManager instance
    /// </summary>
    private static VisualNovelManager _instance = null;

    /// <summary>
    /// EpisodeManager instance
    /// </summary>
    public EpisodeManager episodeManager;

    /// <summary>
    /// Creation of the VisualNovelManager
    /// </summary>
    private VisualNovelManager()
    {
        this.episodeManager = EpisodeManager.Instance;
    }

    /// <summary>
    /// Reset instance
    /// </summary>
    public static void Reset()
    {
        _instance = null;
    }

    /// <summary>
    /// Return visual novel manager instance
    /// </summary>
    public static VisualNovelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new VisualNovelManager();
            }
            return _instance;
        }
    }
    #endregion

}