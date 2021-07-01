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

using System.ComponentModel;
using NAudio.Wave;
namespace SLAM
{

	/// <summary>
	/// Control for viewing waveforms
	/// </summary>
	public class AdvWaveViewer : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private WaveStream m_waveStream;
		private int m_samplesPerPixel = 128;
		private long m_startPosition;
		private int bytesPerSample = 2;
		/// <summary>
		/// Creates a new WaveViewer control
		/// </summary>
		public AdvWaveViewer()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.DoubleBuffered = true;

		}

		public void Fit()
		{
			if (m_waveStream == null) {
				return;
			}

			if (!(this.Width > 0)) {
				return;
			}

			int samples = Convert.ToInt32(m_waveStream.Length / bytesPerSample);
			m_startPosition = 0;
			SamplesPerPixel = samples / this.Width;

		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Fit();
		}

		private Point mousePos;
		private Point startPos;

		private bool mouseDrag = false;
		protected override void OnMouseDown(MouseEventArgs e)
		{

			if (e.Button == System.Windows.Forms.MouseButtons.Left & this.Enabled) {
				startPos = e.Location;
				mousePos = new Point(-1, -1);
				mouseDrag = true;
				DrawVerticalLine(e.X);

			}

			base.OnMouseDown(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.X >= 0 & e.X <= this.Width & this.Enabled) {
				if (mouseDrag) {
					DrawVerticalLine(e.X);
					if (mousePos.X != -1) {
						DrawVerticalLine(mousePos.X);
					}
					mousePos = e.Location;
				}
			}
			base.OnMouseMove(e);
		}

		public int MaxSamples {
			get { return (int) m_waveStream.Length / bytesPerSample; }
		}

		private int m_leftSample = -1;
		public int leftSample {
			get { return m_leftSample; }
			set {
				m_leftSample = value;
				this.Invalidate();
			}
		}
		private int m_rightSample = -1;
		public int rightSample {
			get { return m_rightSample; }
			set {
				m_rightSample = value;
				this.Invalidate();
			}
		}

		public int leftpos {
			get { return m_leftSample * bytesPerSample; }
			set {
				m_leftSample = value / bytesPerSample;
				this.Invalidate();
			}
		}

		public int rightpos {
			get { return m_rightSample * bytesPerSample; }
			set {
				m_rightSample = value / bytesPerSample;
				this.Invalidate();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (mouseDrag && e.Button == System.Windows.Forms.MouseButtons.Left && this.Enabled) {
				mouseDrag = false;
				//DrawVerticalLine(startPos.X)


				if (mousePos.X == -1) {
					if (!(startPos.X == 0)) {
						DrawVerticalLine(startPos.X);
					}

					return;
				}
				//DrawVerticalLine(mousePos.X)

				m_leftSample = Convert.ToInt32(StartPosition / bytesPerSample + m_samplesPerPixel * Math.Min(startPos.X, mousePos.X));
				m_rightSample = Convert.ToInt32(StartPosition / bytesPerSample + m_samplesPerPixel * Math.Max(startPos.X, mousePos.X));
				this.Invalidate();
			}

			base.OnMouseUp(e);
		}

		private void DrawVerticalLine(int x)
		{
			ControlPaint.DrawReversibleLine(PointToScreen(new Point(x, 0)), PointToScreen(new Point(x, Height)), Color.Black);
		}

		/// <summary>
		/// sets the associated wavestream
		/// </summary>
		public WaveStream WaveStream {
			get { return m_waveStream; }
			set {
				m_waveStream = value;
				if (m_waveStream != null) {
					bytesPerSample = (m_waveStream.WaveFormat.BitsPerSample / 8) * m_waveStream.WaveFormat.Channels;
					Fit();
				}
				this.Invalidate();
			}
		}

		public int SampleRate {
			get { return m_waveStream.WaveFormat.SampleRate; }
		}

		/// <summary>
		/// The zoom level, in samples per pixel
		/// </summary>
		public int SamplesPerPixel {
			get { return m_samplesPerPixel; }
			set {
				m_samplesPerPixel = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// Start position (currently in bytes)
		/// </summary>
		public long StartPosition {
			get { return m_startPosition; }
			set { m_startPosition = value; }
		}

		private int m_marker;
		public long marker {
			get { return m_marker; }
			set {
				if (value <= MaxSamples) {
					m_marker = (int)value;
					this.Invalidate();
				}
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// <see cref="Control.OnPaint"/>
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			if (m_waveStream != null) {
				m_waveStream.Position = 0;
				int bytesRead = 0;
				byte[] waveData = new byte[m_samplesPerPixel * bytesPerSample];
				m_waveStream.Position = m_startPosition + (e.ClipRectangle.Left * bytesPerSample * m_samplesPerPixel);

				int leftpos = Convert.ToInt32(m_leftSample / m_samplesPerPixel - StartPosition / bytesPerSample / m_samplesPerPixel);
				int rightpos = Convert.ToInt32(m_rightSample / m_samplesPerPixel - StartPosition / bytesPerSample / m_samplesPerPixel);
				int markerpos = Convert.ToInt32((m_marker + m_leftSample) / m_samplesPerPixel - StartPosition / bytesPerSample / m_samplesPerPixel);

				for (float x = e.ClipRectangle.X; x <= e.ClipRectangle.Right - 1; x++) {
					short low = 0;
					short high = 0;
					bytesRead = m_waveStream.Read(waveData, 0, m_samplesPerPixel * bytesPerSample);
					if (bytesRead == 0) {
						break; // TODO: might not be correct. Was : Exit For
					}
					for (int n = 0; n <= bytesRead - 1; n += 2) {
						short sample = BitConverter.ToInt16(waveData, n);
						if (sample < low) {
							low = sample;
						}
						if (sample > high) {
							high = sample;
						}
					}
					float lowPercent = ((Convert.ToSingle(low) - short.MinValue) / ushort.MaxValue);
					float highPercent = ((Convert.ToSingle(high) - short.MinValue) / ushort.MaxValue);
					using (Pen DodgerBluePen = new Pen(Color.DodgerBlue)) {
						using (Pen BluePen = new Pen(Color.Blue)) {
							using (Pen RedPen = new Pen(Color.Red)) {
								using (Pen GreenPen = new Pen(Color.Green)) {

									if (x == leftpos & !(leftSample == rightSample) | x == rightpos & !(rightSample == leftSample)) {
										e.Graphics.DrawLine(RedPen, x, 0, x, this.Height);

									} else if (x == markerpos & m_marker > 0) {
										e.Graphics.DrawLine(GreenPen, x, 0, x, this.Height);

									} else if (x > leftpos & x < rightpos) {
										e.Graphics.DrawLine(BluePen, x, this.Height * lowPercent, x, this.Height * highPercent);

									} else {
										e.Graphics.DrawLine(DodgerBluePen, x, this.Height * lowPercent, x, this.Height * highPercent);

									}

								}
							}
						}
					}
				}
			}

			base.OnPaint(e);
		}


		#region "Component Designer generated code"
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
