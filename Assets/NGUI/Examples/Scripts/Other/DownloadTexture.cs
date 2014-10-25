//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script that shows how to download a remote texture and assign it to be used by a UITexture.
/// </summary>

[RequireComponent(typeof(UITexture))]
public class DownloadTexture : MonoBehaviour
{
	public string url = "http://www.tasharen.com/misc/logo.png";

	Material mMat;
	Texture2D mTex;

	IEnumerator Start ()
	{
		WWW www = new WWW(url);
		yield return www;
		mTex = www.texture;

		if (mTex != null)
		{
			UITexture ut = GetComponent<UITexture>();

			if (ut.material == null)
			{
				mMat = new Material(Shader.Find("Unlit/Transparent Colored"));
			}
			else
			{
				mMat = new Material(ut.material);
			}
			ut.material = mMat;
			mMat.mainTexture = mTex;
			ut.MakePixelPerfect();
		}
		www.Dispose();
	}

	void OnDestroy ()
	{
		if (mMat != null) Destroy(mMat);
		if (mTex != null) Destroy(mTex);
	}
}