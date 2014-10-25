using UnityEngine;

/// <summary>
/// Change the shader level-of-detail to match the quality settings.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Examples/Shader Quality")]
public class ShaderQuality : MonoBehaviour
{
	int mCurrent = 600;

	void Update ()
	{
#if UNITY_3_4
		int current = ((int)QualitySettings.currentLevel + 1) * 100;
#else
		int current = (QualitySettings.GetQualityLevel() + 1) * 100;
#endif

		if (mCurrent != current)
		{
			mCurrent = current;
			Shader.globalMaximumLOD = mCurrent;
		}
	}
}