using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayPlayer
{
    static class ApplicationSettings
    {
       static int _Volume = 50;
       static string _MenuFolder = @"D:\CsGo";
       static string _WavFileName = @"voice_input.wav";

        public static int Volume
        {
            get
            {
                return _Volume;
            }
            set
            {
                if (value >= 0 && value <= 100)
                    _Volume = value;
                else
                    throw new Exception("Volume must be between 0 and 100.");
            }
        }

        public static string MenuFolder
        {
            get
            {
                return _MenuFolder;
            }
            set
            {
                _MenuFolder = value;
            }
        }

        public static string WavFileName
        {
            get
            {
                return _WavFileName;
            }
            set
            {
                _WavFileName = value;
            }
        }

    }
}
