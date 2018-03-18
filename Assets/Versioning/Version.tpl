using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Version {
    public const int BUILD_DATE = $TIMESTAMP$;
    public const int BUILD_VER_MAJOR = $MAJOR$;
    public const int BUILD_VER_MINOR = $MINOR$;
    public const int BUILD_VER_PATCH = $PATCH$;
    
    /**
     * Possible values:
     * - DEBUG
     * - ALPHA
     * - BETA
     * - RELEASE
     */
    public const string BUILD_TYPE = "$TYPE$";

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
