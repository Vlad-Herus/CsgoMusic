using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
namespace SLAM
{
	public class SourceGame
	{
		public string Name;
		public int Id;
		public string Directory;
		public string ToCfg;
		public string Libraryname;
		public bool VoiceFadeOut = true;

		public string Exename = "hl2";
		public string FileExtension = ".wav";
		public int Samplerate = 11025;
		public int Bits = 16;

		public int Channels = 1;

		public int PollInterval = 100;
		public List<Track> Tracks = new List<Track>();
		public List<string> Blacklist = new List<string> {
			"slam",
			"slam_listtracks",
			"list",
			"tracks",
			"la",
			"slam_play",
			"slam_play_on",
			"slam_play_off",
			"slam_updatecfg",
			"slam_curtrack",
			"slam_saycurtrack",
			"slam_sayteamcurtrack"

		};
		public class Track
		{
			public string Name;
			public List<string> Tags = new List<string>();
			public string Hotkey = Constants.vbNullString;
			public int Volume = 100;
			public int Startpos;
			public int Endpos;
		}
	}
}
