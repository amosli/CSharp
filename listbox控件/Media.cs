using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
namespace listbox控件
{

    class Media
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        private static extern int mciSendString(
            string lpstrCommand,
            string lpstrReturnString,
            int uReturnLength,
            int hwndCallback
            );

        [DllImport("winmm.dll", EntryPoint = "mciGetDeviceID", CharSet = CharSet.Auto)]
        private static extern int mciGetDeviceID(string lpstrName);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
         string lpszLongPath,
         string shortFile,
         int cchBuffer
        );

        public enum PlayTypeName : byte
        {
            File = 1,
            CDAudio = 2,
            VCD = 3,
            RealPlay = 4
        }

        public enum AudioSource : byte
        {
            H = 0,
            L = 1,
            R = 2
        }

        public enum Playstate : byte
        {
            Stopped = 1,
            Playing = 2,
            Pause = 3
        }

        public enum PlayStyle : byte
        {
            顺序 = 1,
            随机 = 2,
            循环 = 3
        }

        public PlayTypeName PlayType;

        public int Temp; //零时变量 工程中将使用

        public String SongName;  //储存当前真正播放的歌曲名称

        public string PreSongName;

        public string NextSongName;

        public int SongIndex; //储存当前播放的歌曲列表的位置

        public int totalSong;

        public PlayStyle PlayerStyle;//播放模式

        public int Valume;//音量大小

        public AudioSource audiosource;

        public bool IsSlowly;//播放速度       

        /// <summary>
        /// 获取DeviceID
        /// </summary>
        /// <returns>返回设备类型</returns>

        public int GetDeviceID()
        {
            return mciGetDeviceID("NOWMUSIC");
        }

        /// <summary>
        /// 根据文件名，确定设备
        /// </summary>
        /// <param name="ff">文件名</param>
        /// <returns></returns>

        public string GetDriverID(string ff)
        {
            string result = "";
            ff = ff.ToUpper().Trim();
            switch (ff.Substring(ff.Length - 3))
            {
                case "MID":
                    result = "Sequencer";
                    break;

                case "RMI":
                    result = "Sequencer";
                    break;

                case "IDI":
                    result = "Sequencer";
                    break;

                case "WAV":
                    result = "Waveaudio";
                    break;

                case "ASX":
                    result = "MPEGVideo2";
                    break;

                case "IVF":
                    result = "MPEGVideo2";
                    break;

                case "LSF":
                    result = "MPEGVideo2";
                    break;

                case "LSX":
                    result = "MPEGVideo2";
                    break;

                case "P2V":
                    result = "MPEGVideo2";
                    break;

                case "WAX":
                    result = "MPEGVideo2";
                    break;

                case "WVX":
                    result = "MPEGVideo2";
                    break;

                case ".WM":
                    result = "MPEGVideo2";
                    break;

                case "WMX":
                    result = "MPEGVideo2";
                    break;

                case "WMP":
                    result = "MPEGVideo2";
                    break;

                case ".RM":
                    result = "RealPlay";
                    break;

                case "RAM":
                    result = "RealPlay";
                    break;

                case ".RA":
                    result = "RealPlay";
                    break;

                case "MVB":
                    result = "RealPlay";
                    break;

                default:
                    result = "MPEGVideo";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 打开MCI设备，
        /// </summary>
        /// <param name="FileName">要打开的文件名</param>
        /// <param name="Handle">mci设备的窗口句柄</param>
        /// <returns>传值代表成功与否</returns>

        public bool OpenMusic(string FileName, IntPtr Handle)
        {
            bool result = false;
            string MciCommand;
            int RefInt;

            CloseMusic();

            ShortPathName = "";
            ShortPathName = ShortPathName.PadLeft(260, Convert.ToChar(" "));
            RefInt = GetShortPathName(FileName, ShortPathName, ShortPathName.Length);
            ShortPathName = GetCurrPath(ShortPathName);
            string DriverID = GetDriverID(ShortPathName);
            if (DriverID == "RealPlay")
                return false;

            MciCommand = string.Format("open {0} type {1} alias NOWMUSIC ", ShortPathName, DriverID);//"open " & RefShortName & " type " & DriverID & " alias NOWMUSIC"

            if (DriverID == "AVIVideo" || DriverID == "MPEGVideo" || DriverID == "MPEGVideo2")
            {
                if (Handle != IntPtr.Zero)
                {
                    MciCommand = MciCommand + string.Format(" parent {0} style child ", Handle);// " parent " & Hwnd & " style child"
                }
                else
                {
                    MciCommand = MciCommand + " style overlapped ";
                }
            }

            TemStr = "";
            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));
            RefInt = mciSendString(MciCommand, null, 0, 0);
            mciSendString("set NOWMUSIC time format milliseconds", null, 0, 0);

            if (RefInt == 0)
            {
                result = true;
                SongName = Path.GetFileNameWithoutExtension(FileName);
            }
            return result;
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        /// <returns></returns>
        public bool PlayMusic()
        {
            bool result = false;
            int RefInt = mciSendString("play NOWMUSIC", null, 0, 0);
            if (RefInt == 0)
            {
                result = true;
                SetValume(Valume);//当前音量大小
                //检测播放速度
                if (IsSlowly)
                    SetSpeed(800);
                else
                    SetSpeed(1200);
                //检测声道
                switch ((int)audiosource)
                {
                    case 0:
                        SetAudioSource(AudioSource.H);
                        break;

                    case 1:
                        SetAudioSource(AudioSource.L);
                        break;

                    case 2:
                        SetAudioSource(AudioSource.R);
                        break;
                }
            }
            return result;
        }

        /// <summary>
        /// 设置声音大小
        /// </summary>
        /// <param name="Valume">音量大小</param>
        /// <returns></returns>
        public bool SetValume(int Valume)
        {
            bool result = false;
            string MciCommand = string.Format("setaudio NOWMUSIC volume to {0}", Valume);
            int RefInt = mciSendString(MciCommand, null, 0, 0);
            if (RefInt == 0)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 设置播放速度
        /// </summary>
        /// <param name="Speed"></param>
        /// <returns></returns>
        public bool SetSpeed(int Speed)
        {

            bool result = false;
            string MciCommand = string.Format("set NOWMUSIC speed to {0}", Speed);
            int RefInt = mciSendString(MciCommand, null, 0, 0);
            if (RefInt == 0)
                result = true;
            return result;
        }

        /// <summary>
        /// 设置声道
        /// </summary>
        /// <param name="audioSource"></param>
        /// <returns></returns>

        public bool SetAudioSource(AudioSource audioSource)
        {
            bool result = false;
            string strSource = "";
            switch ((int)audioSource)
            {
                case 1: strSource = "left"; break;

                case 2: strSource = "right"; break;

                case 0: strSource = "stereo"; break;
            }

            int RefInt = mciSendString("setaudio  NOWMUSIC source to " + strSource, null, 0, 0);
            if (RefInt == 0)
                result = true;
            return result;
        }

        /// <summary>
        /// 设置静音 True为静音，FALSE为取消静音
        /// </summary>
        /// <param name="AudioOff"></param>
        /// <returns></returns>
        public bool SetAudioOnOff(bool AudioOff)
        {

            bool resut = false;

            string OnOff;

            if (AudioOff)

                OnOff = "off";

            else

                OnOff = "on";

            int RefInt = mciSendString("setaudio NOWMUSIC " + OnOff, null, 0, 0);

            if (RefInt == 0)

                resut = true;

            return resut;

        }

        /// <summary>

        /// 关闭媒体

        /// </summary>

        /// <returns></returns>

        public bool CloseMusic()
        {

            int RefInt = mciSendString("close NOWMUSIC", null, 0, 0);

            if (RefInt == 0)

                return true;

            return false;

        }

        /// <summary>

        /// 暂停播放

        /// </summary>

        /// <returns></returns>

        public bool PauseMusic()
        {

            int RefInt = mciSendString("pause NOWMUSIC", null, 0, 0);

            if (RefInt == 0)

                return true;

            return false;

        }

        /// <summary>

        /// 获得当前媒体的状态是不是在播放

        /// </summary>

        /// <returns></returns>

        public Playstate IsPlaying()
        {

            Playstate isPlaying = Playstate.Stopped;
            try
            {

                durLength = "";

                durLength = durLength.PadLeft(128, Convert.ToChar(" "));

                int RefInt = mciSendString("status NOWMUSIC mode", durLength, durLength.Length, 0);

                durLength = durLength.Trim();

                if (durLength.Substring(0, 7) == "playing" || durLength.Substring(0, 2) == "播放")

                    isPlaying = Playstate.Playing;

                else if (durLength.Substring(0, 7) == "stopped" || durLength.Substring(0, 2) == "停止")

                    isPlaying = Playstate.Stopped;

                else isPlaying = Playstate.Pause;
            }
            catch
            {
            }

            return isPlaying;

        }

        /// <summary>

        /// 获取当前播放进度 毫秒

        /// </summary>

        /// <returns></returns>

        public int GetMusicPos()
        {

            durLength = "";

            durLength = durLength.PadLeft(128, Convert.ToChar(" "));

            mciSendString("status NOWMUSIC position", durLength, durLength.Length, 0);

            durLength = durLength.Trim();

            if (string.IsNullOrEmpty(durLength))

                return 0;

            else

                return (int)(Convert.ToDouble(durLength));

        }

        /// <summary>

        /// 获取当前播放进度 格式 00：00:00

        /// </summary>

        /// <returns></returns>

        public string GetMusicPosString()
        {

            durLength = "";

            durLength = durLength.PadLeft(128, Convert.ToChar(" "));

            mciSendString("status NOWMUSIC position", durLength, durLength.Length, 0);

            durLength = durLength.Trim();

            if (string.IsNullOrEmpty(durLength))

                return "00:00:00";

            else
            {

                int s = Convert.ToInt32(durLength) / 1000;

                int h = s / 3600;

                int m = (s - (h * 3600)) / 60;

                s = s - (h * 3600 + m * 60);

                return string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);

            }

        }

        /// <summary>

        /// 获取媒体的长度

        /// </summary>

        /// <returns></returns>

        public int GetMusicLength()
        {

            durLength = "";

            durLength = durLength.PadLeft(128, Convert.ToChar(" "));

            mciSendString("status NOWMUSIC length", durLength, durLength.Length, 0);

            durLength = durLength.Trim();

            if (string.IsNullOrEmpty(durLength))

                return 0;

            else

                return Convert.ToInt32(durLength);

        }

        /// <summary>

        /// 获取媒体的长度 00:00:00

        /// </summary>

        /// <returns></returns>

        public string GetMusicLengthString()
        {

            durLength = "";

            durLength = durLength.PadLeft(128, Convert.ToChar(" "));

            mciSendString("status NOWMUSIC length", durLength, durLength.Length, 0);

            durLength = durLength.Trim();

            if (string.IsNullOrEmpty(durLength))

                return "00:00:00";

            else
            {

                int s = Convert.ToInt32(durLength) / 1000;

                int h = s / 3600;

                int m = (s - (h * 3600)) / 60;

                s = s - (h * 3600 + m * 60);

                return string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);

            }



        }



        public bool SetMusicPos(int Position)
        {

            string MciCommand = string.Format("seek NOWMUSIC to {0}", Position);

            int RefInt = mciSendString(MciCommand, null, 0, 0);

            if (RefInt == 0)

                return true;

            else

                return false;

        }

        private string GetCurrPath(string name)
        {

            if (name.Length < 1) return "";

            name = name.Trim();

            name = name.Substring(0, name.Length - 1);

            return name;

        }



        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]

        private string ShortPathName = "";

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]

        private string durLength = "";

        [MarshalAs(UnmanagedType.LPTStr, SizeConst = 128)]

        private string TemStr = "";

    }

}
