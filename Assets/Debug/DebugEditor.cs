using System.Collections;
using System.IO;

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(DebugPanel))]
public class DebugEditor : Editor
{
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        DebugPanel debugPanel = (DebugPanel)target;
        if (GUILayout.Button("获取数据")){
            debugPanel.GetData();
        }
        if (GUILayout.Button("设置数据")) {
            debugPanel.Refresh();
        }
    }

    [MenuItem("删档/删除存档")]
    static void DeleteArchive() {
        string []nameList = {"player", "chapter"};
        for(int i=0;i<nameList.Length;i++)
        {
            string path = Path.Combine(Application.persistentDataPath, nameList[i]);
            Debug.Log("path================" + path);
            if (FileUtil.DeleteFileOrDirectory(path))
            {
                Debug.Log("删除成功");
            }
            else
            {
                Debug.Log("删除失败");
            }
        }
    }
    [MenuItem("Tools/打图集")]
    static private void MakeAtlas()
    {
        string spriteDir = Application.dataPath + "/Resources/Sprite";

        DeleteFolder(spriteDir);
        
        if (!Directory.Exists(spriteDir))
        {
            Directory.CreateDirectory(spriteDir);
        }
        
        DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/Atlas");
        foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
        {
            foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories))
            {
                string allPath = pngFile.FullName;
                string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                GameObject go = new GameObject(sprite.name);
                go.AddComponent<SpriteRenderer>().sprite = sprite;
                allPath = spriteDir + "/" + sprite.name + ".prefab";
                string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
                PrefabUtility.CreatePrefab(prefabPath, go);
               // PrefabUtility.SaveAsPrefabAsset(go, prefabPath);
                DestroyImmediate(go);
            }
        }
    }

    public static void DeleteFolder(string dir)
    {
        foreach (string d in Directory.GetFileSystemEntries(dir))
        {
            if (File.Exists(d))
            {
                FileInfo fi = new FileInfo(d);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    fi.Attributes = FileAttributes.Normal;
                File.Delete(d);//直接删除其中的文件  
            }
            else
            {
                DirectoryInfo d1 = new DirectoryInfo(d);
                if (d1.GetFiles().Length != 0)
                {
                    DeleteFolder(d1.FullName);////递归删除子文件夹
                }
                Directory.Delete(d);
            }
        }
    }
    
}
#endif