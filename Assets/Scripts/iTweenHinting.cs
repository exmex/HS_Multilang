/// <summary>
/// iTweenHinting (iT) - An iTween(http://itween.pixelplacement.com) helper class that store all parameters of all tweening function to allow for code hinting/discovery.
///				         Tested compatibility with iTween Version: 2.0.37
/// </summary>
//
// released under MIT License
// http://www.opensource.org/licenses/mit-license.php
//
//@author		Devin Reimer
//@website 		http://blog.almostlogical.com
/*
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
public static class iT
{
    /// <summary>Instantly changes the amount(transparency) of a camera fade and then returns it back over time with FULL customization options.</summary>
    public static class CameraFadeFrom
    {
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for how transparent the Texture2D that the camera fade uses is.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Changes the amount(transparency) of a camera fade over time with FULL customization options.</summary>
    public static class CameraFadeTo
    {
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for how transparent the Texture2D that the camera fade uses is.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Returns a value to an 'oncallback' method interpolated between the supplied 'from' and 'to' values for application as desired.  Requires an 'onupdate' callback that accepts the same type as the supplied 'from' and 'to' properties.</summary>
    public static class ValueTo
    {
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> or <see cref="Vector3"/> or <see cref="Vector2"/> or <see cref="Color"/> or <see cref="Rect"/> for the starting value.</summary>
        public const string from = "from";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> or <see cref="Vector3"/> or <see cref="Vector2"/> or <see cref="Color"/> or <see cref="Rect"/> for the ending value.</summary>
        public const string to = "to";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed (only works with Vector2, Vector3, and Floats)</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Changes a GameObject's alpha value instantly then returns it to the provided alpha over time with FULL customization options.  If a GUIText or GUITexture component is attached, it will become the target of the animation. Identical to using ColorFrom and using the "a" parameter.</summary>
    public static class FadeFrom
    {
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the initial alpha value of the animation.</summary>
        public const string alpha = "alpha";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the initial alpha value of the animation.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Boolean"/> for whether or not to include children of this GameObject. True by default.</summary>
        public const string includechildren = "includechildren";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Changes a GameObject's alpha value over time with FULL customization options.  If a GUIText or GUITexture component is attached, it will become the target of the animation. Identical to using ColorTo and using the "a" parameter.</summary>
    public static class FadeTo
    {
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the final alpha value of the animation.</summary>
        public const string alpha = "alpha";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the final alpha value of the animation.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Boolean"/> for whether or not to include children of this GameObject. True by default.</summary>
        public const string includechildren = "includechildren";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Changes a GameObject's color values instantly then returns them to the provided properties over time with FULL customization options.  If a GUIText or GUITexture component is attached, it will become the target of the animation.</summary>
    public static class ColorFrom
    {
        /// <summary>A <see cref="Color"/> to change the GameObject's color to.</summary>
        public const string color = "color";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the color red.</summary>
        public const string r = "r";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the color green.</summary>
        public const string g = "g";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the color green.</summary>
        public const string b = "b";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the alpha.</summary>
        public const string a = "a";
        /// <summary>A <see cref="NamedColorValue"/> or <see cref="System.String"/> for the individual setting of the alpha.</summary>
        public const string namedcolorvalue = "namedcolorvalue";
        /// <summary>A <see cref="System.Boolean"/> for whether or not to include children of this GameObject. True by default.</summary>
        public const string includechildren = "includechildren";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Changes a GameObject's color values over time with FULL customization options.  If a GUIText or GUITexture component is attached, they will become the target of the animation.</summary>
    public static class ColorTo
    {
        /// <summary>A <see cref="Color"/> to change the GameObject's color to.</summary>
        public const string color = "color";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the color red.</summary>
        public const string r = "r";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the color green.</summary>
        public const string g = "g";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the color green.</summary>
        public const string b = "b";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the alpha.</summary>
        public const string a = "a";
        /// <summary>A <see cref="NamedColorValue"/> or <see cref="System.String"/> for the individual setting of the alpha.</summary>
        public const string namedcolorvalue = "namedcolorvalue";
        /// <summary>A <see cref="System.Boolean"/> for whether or not to include children of this GameObject. True by default.</summary>
        public const string includechildren = "includechildren";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Instantly changes an AudioSource's volume and pitch then returns it to it's starting volume and pitch over time with FULL customization options. Default AudioSource attached to GameObject will be used (if one exists) if not supplied. </summary>
    public static class AudioFrom
    {
        /// <summary>A <see cref="AudioSource"/> for which AudioSource to use.</summary>
        public const string audiosource = "audiosource";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the target level of volume.</summary>
        public const string volume = "volume";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the target pitch.</summary>
        public const string pitch = "pitch";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Fades volume and pitch of an AudioSource with FULL customization options.  Default AudioSource attached to GameObject will be used (if one exists) if not supplied. </summary>
    public static class AudioTo
    {
        /// <summary>A <see cref="AudioSource"/> for which AudioSource to use.</summary>
        public const string audiosource = "audiosource";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the target level of volume.</summary>
        public const string volume = "volume";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the target pitch.</summary>
        public const string pitch = "pitch";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Plays an AudioClip once based on supplied volume and pitch and following any delay with FULL customization options. AudioSource is optional as iTween will provide one.</summary>
    public static class Stab
    {
        /// <summary>A <see cref="AudioClip"/> for a reference to the AudioClip to be played.</summary>
        public const string audioclip = "audioclip";
        /// <summary>A <see cref="AudioSource"/> for which AudioSource to use</summary>
        public const string audiosource = "audiosource";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the target level of volume.</summary>
        public const string volume = "volume";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the target pitch.</summary>
        public const string pitch = "pitch";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the action will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Instantly rotates a GameObject to look at a supplied Transform or Vector3 then returns it to it's starting rotation over time with FULL customization options. </summary>
    public static class LookFrom
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.String"/>. Restricts rotation to the supplied axis only.</summary>
        public const string axis = "axis";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Rotates a GameObject to look at a supplied Transform or Vector3 over time with FULL customization options.</summary>
    public static class LookTo
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.String"/>. Restricts rotation to the supplied axis only.</summary>
        public const string axis = "axis";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Changes a GameObject's position over time to a supplied destination with FULL customization options.</summary>
    public static class MoveTo
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for a point in space the GameObject will animate to.</summary>
        public const string position = "position";
        /// <summary>A <see cref="Transform[]"/> or <see cref="Vector3[]"/> for a list of points to draw a Catmull-Rom through for a curved animation path.</summary>
        public const string path = "path";
        /// <summary>A <see cref="System.Boolean"/> for whether to automatically generate a curve from the GameObject's current position to the beginning of the path. True by default.</summary>
        public const string movetopath = "movetopath";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Boolean"/> for whether or not the GameObject will orient to its direction of travel.  False by default.</summary>
        public const string orienttopath = "orienttopath";
        /// <summary>A <see cref="Vector3"/> or A <see cref="Transform"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the object will take to look at either the "looktarget" or "orienttopath".</summary>
        public const string looktime = "looktime";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for how much of a percentage to look ahead on a path to influence how strict "orientopath" is.</summary>
        public const string lookahead = "lookahead";
        /// <summary>A <see cref="System.String"/>. Restricts rotation to the supplied axis only.</summary>
        public const string axis = "axis";
        /// <summary>A <see cref="System.Boolean"/> for whether to animate in world space or relative to the parent. False by default.</summary>
        public const string islocal = "islocal";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Instantly changes a GameObject's position to a supplied destination then returns it to it's starting position over time with FULL customization options.</summary>
    public static class MoveFrom
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for a point in space the GameObject will animate to.</summary>
        public const string position = "position";
        /// <summary>A <see cref="Transform[]"/> or <see cref="Vector3[]"/> for a list of points to draw a Catmull-Rom through for a curved animation path.</summary>
        public const string path = "path";
        /// <summary>A <see cref="System.Boolean"/> for whether to automatically generate a curve from the GameObject's current position to the beginning of the path. True by default.</summary>
        public const string movetopath = "movetopath";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Boolean"/> for whether or not the GameObject will orient to its direction of travel.  False by default.</summary>
        public const string orienttopath = "orienttopath";
        /// <summary>A <see cref="Vector3"/> or A <see cref="Transform"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the object will take to look at either the "looktarget" or "orienttopath".</summary>
        public const string looktime = "looktime";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for how much of a percentage to look ahead on a path to influence how strict "orientopath" is.</summary>
        public const string lookahead = "lookahead";
        /// <summary>A <see cref="System.Boolean"/> for whether to animate in world space or relative to the parent. False by default.</summary>
        public const string islocal = "islocal";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Translates a GameObject's position over time with FULL customization options.</summary>
    public static class MoveAdd
    {
        /// <summary>A <see cref="Vector3"/> for the amount of change in position to move the GameObject.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Boolean"/> for whether or not the GameObject will orient to its direction of travel.  False by default.</summary>
        public const string orienttopath = "orienttopath";
        /// <summary>A <see cref="Vector3"/> or A <see cref="Transform"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the object will take to look at either the "looktarget" or "orienttopath".</summary>
        public const string looktime = "looktime";
        /// <summary>A <see cref="System.String"/>. Restricts rotation to the supplied axis only.</summary>
        public const string axis = "axis";
        /// <summary>A <see cref="Space"/> or <see cref="System.String"/> for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.</summary>
        public const string space = "space";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Adds the supplied coordinates to a GameObject's position with FULL customization options.</summary>
    public static class MoveBy
    {
        /// <summary>A <see cref="Vector3"/> for the amount of change in position to move the GameObject.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Boolean"/> for whether or not the GameObject will orient to its direction of travel.  False by default.</summary>
        public const string orienttopath = "orienttopath";
        /// <summary>A <see cref="Vector3"/> or A <see cref="Transform"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the object will take to look at either the "looktarget" or "orienttopath".</summary>
        public const string looktime = "looktime";
        /// <summary>A <see cref="System.String"/>. Restricts rotation to the supplied axis only.</summary>
        public const string axis = "axis";
        /// <summary>A <see cref="Space"/> or <see cref="System.String"/> for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.</summary>
        public const string space = "space";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Changes a GameObject's scale over time with FULL customization options.</summary>
    public static class ScaleTo
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for the final scale.</summary>
        public const string scale = "scale";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Instantly changes a GameObject's scale then returns it to it's starting scale over time with FULL customization options.</summary>
    public static class ScaleFrom
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for the final scale.</summary>
        public const string scale = "scale";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Adds to a GameObject's scale over time with FULL customization options.</summary>
    public static class ScaleAdd
    {
        /// <summary>A <see cref="Vector3"/> for the amount to be added to the GameObject's current scale.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Multiplies a GameObject's scale over time with FULL customization options.</summary>
    public static class ScaleBy
    {
        /// <summary>A <see cref="Vector3"/> for the amount to be multiplied to the GameObject's current scale.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Rotates a GameObject to the supplied Euler angles in degrees over time with FULL customization options.</summary>
    public static class RotateTo
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for the target Euler angles in degrees to rotate to.</summary>
        public const string rotation = "rotation";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Boolean"/> for whether to animate in world space or relative to the parent. False by default.</summary>
        public const string islocal = "islocal";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Instantly changes a GameObject's Euler angles in degrees then returns it to it's starting rotation over time (if allowed) with FULL customization options.</summary>
    public static class RotateFrom
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for the target Euler angles in degrees to rotate to.</summary>
        public const string rotation = "rotation";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Boolean"/> for whether to animate in world space or relative to the parent. False by default.</summary>
        public const string islocal = "islocal";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Adds supplied Euler angles in degrees to a GameObject's rotation over time with FULL customization options.</summary>
    public static class RotateAdd
    {
        /// <summary>A <see cref="Vector3"/> for the amount of Euler angles in degrees to add to the current rotation of the GameObject.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="Space"/> or <see cref="System.String"/> for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.</summary>
        public const string space = "space";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Multiplies supplied values by 360 and rotates a GameObject by calculated amount over time with FULL customization options.</summary>
    public static class RotateBy
    {
        /// <summary>A <see cref="Vector3"/> for the amount to be multiplied by 360 to rotate the GameObject.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="Space"/> or <see cref="System.String"/> for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.</summary>
        public const string space = "space";
        /// <summary>A <see cref="System.Boolean"/> for whether to animate in world space or relative to the parent. False by default.</summary>
        public const string islocal = "islocal";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> can be used instead of time to allow animation based on speed</summary>
        public const string speed = "speed";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="EaseType"/> or <see cref="System.String"/> for the shape of the easing curve applied to the animation.</summary>
        public const string easetype = "easetype";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed.</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Randomly shakes a GameObject's position by a diminishing amount over time with FULL customization options.</summary>
    public static class ShakePosition
    {
        /// <summary>A <see cref="Vector3"/> for the magnitude of shake.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x magnitude.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y magnitude.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z magnitude.</summary>
        public const string z = "z";
        /// <summary>A <see cref="Space"/> for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.</summary>
        public const string space = "space";
        /// <summary>A <see cref="System.Boolean"/> for whether or not the GameObject will orient to its direction of travel.  False by default.</summary>
        public const string orienttopath = "orienttopath";
        /// <summary>A <see cref="Vector3"/> or A <see cref="Transform"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the object will take to look at either the "looktarget" or "orienttopath".</summary>
        public const string looktime = "looktime";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed. (only "loop" is allowed with shakes)</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Randomly shakes a GameObject's scale by a diminishing amount over time with FULL customization options.</summary>
    public static class ShakeScale
    {
        /// <summary>A <see cref="Vector3"/> for the magnitude of shake.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x magnitude.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y magnitude.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z magnitude.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed. (only "loop" is allowed with shakes)</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Randomly shakes a GameObject's rotation by a diminishing amount over time with FULL customization options.</summary>
    public static class ShakeRotation
    {
        /// <summary>A <see cref="Vector3"/> for the magnitude of shake.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x magnitude.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y magnitude.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z magnitude.</summary>
        public const string z = "z";
        /// <summary>A <see cref="Space"/> for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.</summary>
        public const string space = "space";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed. (only "loop" is allowed with shakes)</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Applies a jolt of force to a GameObject's position and wobbles it back to its initial position with FULL customization options.</summary>
    public static class PunchPosition
    {
        /// <summary>A <see cref="Vector3"/> for the magnitude of shake.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x magnitude.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y magnitude.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z magnitude.</summary>
        public const string z = "z";
        /// <summary>A <see cref="Space"/> for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.</summary>
        public const string space = "space";
        /// <summary>A <see cref="Vector3"/> or A <see cref="Transform"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the object will take to look at either the "looktarget".</summary>
        public const string looktime = "looktime";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed. (only "loop" is allowed with punches)</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Applies a jolt of force to a GameObject's rotation and wobbles it back to its initial rotation with FULL customization options.</summary>
    public static class PunchRotation
    {
        /// <summary>A <see cref="Vector3"/> for the magnitude of shake.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x magnitude.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y magnitude.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z magnitude.</summary>
        public const string z = "z";
        /// <summary>A <see cref="Space"/> for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.</summary>
        public const string space = "space";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed. (only "loop" is allowed with punches)</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Applies a jolt of force to a GameObject's scale and wobbles it back to its initial scale with FULL customization options.</summary>
    public static class PunchScale
    {
        /// <summary>A <see cref="Vector3"/> for the magnitude of shake.</summary>
        public const string amount = "amount";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x magnitude.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y magnitude.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z magnitude.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will wait before beginning.</summary>
        public const string delay = "delay";
        /// <summary>A <see cref="LoopType"/> or <see cref="System.String"/> for the type of loop to apply once the animation has completed. (only "loop" is allowed with punches)</summary>
        public const string looptype = "looptype";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the beginning of the animation.</summary>
        public const string onstart = "onstart";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onstart" method.</summary>
        public const string onstarttarget = "onstarttarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onstart" method.</summary>
        public const string onstartparams = "onstartparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch on every step of the animation.</summary>
        public const string onupdate = "onupdate";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "onupdate" method.</summary>
        public const string onupdatetarget = "onupdatetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "onupdate" method.</summary>
        public const string onupdateparams = "onupdateparams";
        /// <summary>A <see cref="System.String"/> for the name of a function to launch at the end of the animation.</summary>
        public const string oncomplete = "oncomplete";
        /// <summary>A <see cref="GameObject"/> for a reference to the GameObject that holds the "oncomplete" method.</summary>
        public const string oncompletetarget = "oncompletetarget";
        /// <summary>A <see cref="System.Object"/> for arguments to be sent to the "oncomplete" method.</summary>
        public const string oncompleteparams = "oncompleteparams";
    }
    /// <summary>Similar to FadeTo but incredibly less expensive for usage inside the Update function or similar looping situations involving a "live" set of changing values with FULL customization options. Does not utilize an EaseType. </summary>
    public static class FadeUpdate
    {
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the final alpha value of the animation.</summary>
        public const string alpha = "alpha";
        /// <summary>A <see cref="System.Boolean"/> for whether or not to include children of this GameObject. True by default.</summary>
        public const string includechildren = "includechildren";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
    }
    /// <summary>Similar to ColorTo but incredibly less expensive for usage inside the Update function or similar looping situations involving a "live" set of changing values with FULL customization options. Does not utilize an EaseType. </summary>
    public static class ColorUpdate
    {
        /// <summary>A <see cref="Color"/> to change the GameObject's color to.</summary>
        public const string color = "color";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the color red.</summary>
        public const string r = "r";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the color green.</summary>
        public const string g = "g";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the color green.</summary>
        public const string b = "b";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the alpha.</summary>
        public const string a = "a";
        /// <summary>A <see cref="NamedColorValue"/> or <see cref="System.String"/> for the individual setting of the alpha.</summary>
        public const string namedcolorvalue = "namedcolorvalue";
        /// <summary>A <see cref="System.Boolean"/> for whether or not to include children of this GameObject. True by default.</summary>
        public const string includechildren = "includechildren";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
    }
    /// <summary>Similar to AudioTo but incredibly less expensive for usage inside the Update function or similar looping situations involving a "live" set of changing values with FULL customization options. Does not utilize an EaseType. </summary>
    public static class AudioUpdate
    {
        /// <summary>A <see cref="AudioSource"/> for which AudioSource to use.</summary>
        public const string audiosource = "audiosource";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the target level of volume.</summary>
        public const string volume = "volume";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the target pitch.</summary>
        public const string pitch = "pitch";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
    }
    /// <summary>Similar to RotateTo but incredibly less expensive for usage inside the Update function or similar looping situations involving a "live" set of changing values with FULL customization options. Does not utilize an EaseType. </summary>
    public static class RotateUpdate
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for the target Euler angles in degrees to rotate to.</summary>
        public const string rotation = "rotation";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Boolean"/> for whether to animate in world space or relative to the parent. False by default.</summary>
        public const string islocal = "islocal";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
    }
    /// <summary>Similar to ScaleTo but incredibly less expensive for usage inside the Update function or similar looping situations involving a "live" set of changing values with FULL customization options.  Does not utilize an EaseType. </summary>
    public static class ScaleUpdate
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for the final scale.</summary>
        public const string scale = "scale";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
    }
    /// <summary>Similar to MoveTo but incredibly less expensive for usage inside the Update function or similar looping situations involving a "live" set of changing values with FULL customization options. Does not utilize an EaseType. </summary>
    public static class MoveUpdate
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for a point in space the GameObject will animate to.</summary>
        public const string position = "position";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the x axis.</summary>
        public const string x = "x";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the y axis.</summary>
        public const string y = "y";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the individual setting of the z axis.</summary>
        public const string z = "z";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
        /// <summary>A <see cref="System.Boolean"/> for whether to animate in world space or relative to the parent. False be default.</summary>
        public const string islocal = "islocal";
        /// <summary>A <see cref="System.Boolean"/> for whether or not the GameObject will orient to its direction of travel.  False by default.</summary>
        public const string orienttopath = "orienttopath";
        /// <summary>A <see cref="Vector3"/> or A <see cref="Transform"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the object will take to look at either the "looktarget" or "orienttopath".</summary>
        public const string looktime = "looktime";
        /// <summary>A <see cref="System.String"/>. Restricts rotation to the supplied axis only.</summary>
        public const string axis = "axis";
    }
    /// <summary>Similar to LookTo but incredibly less expensive for usage inside the Update function or similar looping situations involving a "live" set of changing values with FULL customization options. Does not utilize an EaseType. </summary>
    public static class LookUpdate
    {
        /// <summary>A <see cref="Transform"/> or <see cref="Vector3"/> for a target the GameObject will look at.</summary>
        public const string looktarget = "looktarget";
        /// <summary>A <see cref="System.String"/>. Restricts rotation to the supplied axis only.</summary>
        public const string axis = "axis";
        /// <summary>A <see cref="System.Single"/> or <see cref="System.Double"/> for the time in seconds the animation will take to complete.</summary>
        public const string time = "time";
    }
}

