using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
	private int shooter;
	public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.Space();

        if (GUILayout.Button("Fire Bullet"))
        {
			((Weapon)target).Shoot(shooter);
        }
    }
}
