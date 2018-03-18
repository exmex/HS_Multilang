using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Version {
    public const int BUILD_DATE = 1521378748;
    public const int BUILD_VER_MAJOR = 0;
    public const int BUILD_VER_MINOR = 1;
    public const int BUILD_VER_PATCH = 0;
    
    /**
     * Possible values:
     * - DEBUG
     * - ALPHA
     * - BETA
     * - RELEASE
     */
    public const string BUILD_TYPE = "DEBUG";

    public static string GetVersionString()
    {
        return BUILD_VER_MAJOR + "." + BUILD_VER_MINOR + "." + BUILD_VER_PATCH;
    }

    public static DateTime GetVersionTime()
    {
        //Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(BUILD_DATE);
    }
}
