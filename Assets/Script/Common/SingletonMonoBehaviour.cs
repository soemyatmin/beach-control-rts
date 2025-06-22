using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    protected static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                if (m_IsQuit)
                    return null;
                instance = GameObject.FindObjectOfType<T>();
                if (instance == null)
                {
                   
#if UNITY_EDITOR
                    if (!(UnityEditor.EditorApplication.isPlaying))
                    {
                        m_IsQuit = false;
                        return null;
                    }
#endif
                    GameObject obj = new GameObject(typeof(T).ToString());
                    instance = obj.AddComponent<T>();
                }
                else
                {
                    instance.ForceAwake();
                }
            }
            return (T)instance;
        }
    }
    
    public static T GetInstance()
    {
        return Instance;
    }

    protected static bool m_IsQuit = false;
    public static bool IsQuit
    {
        get { return m_IsQuit; }
    }

    public static bool IsExist
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();
            }
            return (instance != null);
        }
    }

    public static bool IsExistNoCreate
    {
        get
        {
            return (instance != null);
        }
    }

    protected bool m_IsAwake = false;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject.GetComponent<T>();
        }
        if (instance != this)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }

        ForceAwake();
    }

    void ForceAwake()
    {
        if (this.m_IsAwake)
            return;

        Initialize();
        this.m_IsAwake = true;
    }

    protected void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            Release();
        }
    }

    protected virtual void OnApplicationQuit()
    {
        m_IsQuit = true;
    }

    protected virtual void Initialize()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    protected virtual void Release()
    {
        if (instance == this)
        {
            Debug.Log($" Release singleton {nameof(T)}");
            instance = null;
            Destroy(this.gameObject);
        }
    }
}


