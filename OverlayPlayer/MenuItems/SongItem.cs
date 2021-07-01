using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayPlayer.MenuItems
{
    class CsGoSongItem : AMenuItem
    {
        public const string WAV_EXTESION = "wav";
        string mSongPath = "";

        protected virtual string CsComand => "voice_inputfromfile 1; voice_loopback 1; +voicerecord";

        public CsGoSongItem(string songPath)
        {
            Contract.Requires(File.Exists(songPath));
            Contract.Requires(songPath.EndsWith(WAV_EXTESION, StringComparison.CurrentCultureIgnoreCase));

            SubItems = Enumerable.Empty<AMenuItem>();
            mSongPath = songPath;
            Caption = Path.GetFileNameWithoutExtension(songPath);
        }

        public override void Execute()
        {
            //WaveChannel32 WaveFloat = new WaveChannel32(new WaveFileReader(mSongPath));
            MediaFoundationReader reader = new MediaFoundationReader(mSongPath);

            VolumeWaveProvider16 ww = new VolumeWaveProvider16(reader);

            if (ApplicationSettings.Volume != 100)
                ww.Volume = (float)Math.Pow((ApplicationSettings.Volume / 100.0),3);

         
            var outFormat = new WaveFormat(22050, 16, 1);
            var resampler = new MediaFoundationResampler(ww, outFormat);
            resampler.ResamplerQuality = 60;

            string wavFileName = Path.Combine(CsGoLocationFinder.GetCsGoLocation(), ApplicationSettings.WavFileName);

            if (File.Exists(wavFileName))
                File.Delete(wavFileName);

            WaveFileWriter.CreateWaveFile(wavFileName, resampler);

            resampler.Dispose();

            Key.CsGoKeySender.SendCommands(CsComand);
        }
    }
}
