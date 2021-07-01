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
using NAudio;
using NAudio.Wave;
using System.Threading;
using System.IO;
namespace SLAM
{

	public partial class TrimForm
	{
		public string WavFile;
		public int startpos;

		public int endpos;
		private void TrimForm_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(WavFile)) {
				using (NAudio.Wave.WaveFileReader reader = new NAudio.Wave.WaveFileReader(WavFile)) {
					AdvWaveViewer1.WaveStream = new NAudio.Wave.WaveFileReader(WavFile);
					//reader.WaveFormat.SampleRate
				}

				NumericRightS.Maximum = decimal.MaxValue;
				NumericRight.Maximum = AdvWaveViewer1.MaxSamples;
				NumericRight.Increment = AdvWaveViewer1.SamplesPerPixel;

				NumericLeftS.Maximum = decimal.MaxValue;
				NumericLeft.Maximum = decimal.MaxValue;
				NumericLeft.Increment = AdvWaveViewer1.SamplesPerPixel;

				if (startpos == endpos & endpos == 0) {
					NumericRight.Value = AdvWaveViewer1.MaxSamples;
				} else {
					AdvWaveViewer1.rightpos = endpos;
					AdvWaveViewer1.leftpos = startpos;
					NumericRight.Value = AdvWaveViewer1.rightSample;
					NumericLeft.Value = AdvWaveViewer1.leftSample;
				}

			}
		}

		private void TrimForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (BackgroundPlayer.IsBusy) {
				BackgroundPlayer.CancelAsync();
			}
		}

		private void AdvWaveViewer1_MouseUp(object sender, MouseEventArgs e)
		{
			NumericRight.Value = AdvWaveViewer1.rightSample;
			NumericLeft.Value = AdvWaveViewer1.leftSample;
		}

		private void NumericLeft_ValueChanged(object sender, EventArgs e)
		{
			if (NumericLeft.Value >= AdvWaveViewer1.rightSample) {
				NumericLeft.Value = NumericRight.Value - 1;
			}
			AdvWaveViewer1.leftSample = (int)NumericLeft.Value;
			NumericLeftS.Value = NumericLeft.Value / AdvWaveViewer1.SampleRate;
		}

		private void NumericRight_ValueChanged(object sender, EventArgs e)
		{
			if (NumericRight.Value <= AdvWaveViewer1.leftSample) {
				NumericRight.Value = NumericLeft.Value + 1;
			}
			AdvWaveViewer1.rightSample = (int)NumericRight.Value;
			NumericRightS.Value = NumericRight.Value / AdvWaveViewer1.SampleRate;
		}

		private void DoneButton_Click(object sender, EventArgs e)
		{
			startpos = AdvWaveViewer1.leftpos;

			if (AdvWaveViewer1.rightSample == AdvWaveViewer1.MaxSamples & AdvWaveViewer1.leftpos == 0) {
				endpos = 0;
			} else {
				endpos = AdvWaveViewer1.rightpos;
			}


			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void TrimForm_Resize(object sender, EventArgs e)
		{
			NumericLeft.Increment = AdvWaveViewer1.SamplesPerPixel;
			NumericRight.Increment = AdvWaveViewer1.SamplesPerPixel;
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			NumericLeft.Value = 0;
			NumericRight.Value = AdvWaveViewer1.MaxSamples;
		}

		private void NumericLeftS_ValueChanged(object sender, EventArgs e)
		{
			NumericLeft.Value = NumericLeftS.Value * AdvWaveViewer1.SampleRate;
		}

		private void NumericRightS_ValueChanged(object sender, EventArgs e)
		{
			if ((NumericRightS.Value * AdvWaveViewer1.SampleRate) <= NumericRight.Maximum) {
				NumericRight.Value = NumericRightS.Value * AdvWaveViewer1.SampleRate;
			} else {
				NumericRight.Value = NumericRight.Maximum;
				NumericRightS.Value = NumericRight.Value / AdvWaveViewer1.SampleRate;
			}

		}

		private void PlayButton_Click(object sender, EventArgs e)
		{
			if (BackgroundPlayer.IsBusy == false) {
				BackgroundPlayer.RunWorkerAsync(new object[3] {
					AdvWaveViewer1.WaveStream,
					AdvWaveViewer1.leftpos,
					AdvWaveViewer1.rightpos
				});
				PlayButton.Text = "Stop";
				DisableInterface();
				PlayButton.Enabled = true;
			} else {
				BackgroundPlayer.CancelAsync();
				PlayButton.Text = "Play";
			}
		}

		private void BackgroundPlayer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			WaveStream WaveFloat = (e.Argument as object[])[0] as WaveStream;
			int LeftPos = (int)(e.Argument as object[])[1];
			int RightPos = (int)(e.Argument as object[])[2];

			byte[] bytes = new byte[(RightPos - LeftPos) + 1];

			WaveFloat.Position = LeftPos;
			WaveFloat.Read(bytes, 0, (RightPos - LeftPos));

			WaveFloat = new RawSourceWaveStream(new MemoryStream(bytes), WaveFloat.WaveFormat);
			//WaveFloat.PadWithZeroes = False

			using (var output = new WaveOutEvent()) {
				output.Init(WaveFloat);
				output.Play();
				while (output.PlaybackState == PlaybackState.Playing & !BackgroundPlayer.CancellationPending) {
					Thread.Sleep(45);
					BackgroundPlayer.ReportProgress((int) output.GetPosition() / (WaveFloat.WaveFormat.BitsPerSample / 8));
				}
			}
		}

		private void BackgroundPlayer_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			AdvWaveViewer1.marker = e.ProgressPercentage;
		}

		private void BackgroundPlayer_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			PlayButton.Text = "Play";
			AdvWaveViewer1.marker = 0;
			EnableInterface();
		}

		private void EnableInterface()
		{
			foreach (Control control in this.Controls) {
                control.Enabled = true;
			}
		}

		private void DisableInterface()
		{
			foreach (Control control in this.Controls) {
                control.Enabled = false;
			}
		}
	}
}
