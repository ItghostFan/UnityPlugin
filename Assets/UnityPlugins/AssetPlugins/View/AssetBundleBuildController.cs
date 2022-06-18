
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityPlugins.AssetBundle {
    public class AssetBundleBuildController : EditorWindow
    {
        [MenuItem("Asset Plugins/Build Asset Bundle")]
        private static void OnMenuClicked()
        {
            if (HasOpenInstances<AssetBundleBuildController>()) {
                return;
            }

            const int width = 800;
            const int height = 450;
            Rect frame = new Rect(
                300,
                300,
                width,
                height
            );
            
            AssetBundleBuildController controller = 
            GetWindow<AssetBundleBuildController>("Select Assets Build", true);
            controller.position = frame;
            controller.minSize = new Vector2(width, height);
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            {
                EditorGUILayout.BeginHorizontal(GUILayout.Width(position.width), GUILayout.Height(position.height));
                {
                    GUILayout.Space(2f);

                    // 所有Asset Bundle列表
                    EditorGUILayout.BeginVertical(GUILayout.Width(position.width * 0.5f));
                    {
                        GUILayout.Space(5);
                        EditorGUILayout.LabelField(string.Format("All Asset Bundles ({0})", AssetDatabase.GetAllAssetBundleNames().Length, EditorStyles.boldLabel));
                        EditorGUILayout.BeginHorizontal("box", GUILayout.Height(position.height - 60f));
                        {
                            m_AllAssetsScrollViewFrame = EditorGUILayout.BeginScrollView(m_AllAssetsScrollViewFrame);
                            MakeAssetBundlesView();
                            EditorGUILayout.EndScrollView();
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndVertical();

                    // 已打包过的Asset Bundle列表
                    EditorGUILayout.BeginVertical(GUILayout.Width(position.width));
                    {
                        GUILayout.Space(5);
                        EditorGUILayout.LabelField(string.Format("Selected Assets ({0})", 100f, EditorStyles.boldLabel));
                        EditorGUILayout.BeginHorizontal("box", GUILayout.Height(position.height - 60f));
                        {
                            m_SelectAssetsScrollViewFrame = EditorGUILayout.BeginScrollView(m_SelectAssetsScrollViewFrame);
                            EditorGUILayout.EndScrollView();
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                {
                    GUILayout.Button(string.Format("Build {0} Assets", 99f));
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }

        private void MakeAssetBundlesView()
        {
            foreach (string assetBundle in AssetDatabase.GetAllAssetBundleNames()) {
                GUILayout.Label(assetBundle);
            }
        }

        private Vector2 m_AllAssetsScrollViewFrame = Vector2.zero;
        private Vector2 m_SelectAssetsScrollViewFrame = Vector2.zero;
    }
}
