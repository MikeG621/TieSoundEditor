/*
 * TieSoundEditor.exe, Editor for BLAS and VOIC resources in LFD files
 * Copyright (C) 2007 Michael Gaisser (mjgaisser@gmail.com)
 * Licensed under the MPL v2.0 or later.
 * 
 * Full notice in Program.cs
 * Version: 1.1.1
 */

/* CHANGELOG
 * v1.1.1, 150729
 * - Released under MPL 2.0
 * 
 * v1.1, 090918
 * - Updates to WAV processing
 * 
 * v1.0, 071215
 * - Release
*/
using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Idmr.LfdReader;

namespace Idmr.TieSoundEditor
{
	public partial class frmTSE : Form
	{
		LfdFile _lfd;

		public frmTSE()
		{
			InitializeComponent();
		}

		// this gets us the required function to play .WAV
		[DllImport("winmm.dll", SetLastError=true, CallingConvention=CallingConvention.Winapi)]
		static extern bool PlaySound(byte[] b_ary, IntPtr ptr, SoundFlags sf);		// from memory
		[Flags]
		public enum SoundFlags : int
		{
			//SND_SYNC = 0x0000,  // play synchronously (default) 
			SND_ASYNC=0x0001,  // play asynchronously 
			//SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found 
			SND_MEMORY=0x0004,  // pszSound points to a memory file
			//SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound 
			//SND_NOSTOP = 0x0010,  // don't stop any currently playing sound 
			//SND_NOWAIT = 0x00002000, // don't wait if the driver is busy 
			//SND_ALIAS = 0x00010000, // name is a registry alias 
			//SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
			SND_FILENAME=0x00020000, // name is file name 
			//SND_RESOURCE = 0x00040004  // name is resource name or atom 
		}

		private void cmdLFD_Click(object sender, EventArgs e)
		{
			opnFile.ShowDialog();	// yes, I'm aware I'm using opn even for the WAVtoLFD
		}
		private void cmdWave_Click(object sender, EventArgs e)
		{
			savFile.FileName = lstVOIC.SelectedItem.ToString();
			savFile.ShowDialog();	// yes, I'm aware I'm using sav even for the WAVtoLFD
		}
		private void opnFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try { _lfd = new LfdFile(opnFile.FileName); }
			catch (Exception x)
			{
				MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			txtLFD.Text = opnFile.FileName;
			lstVOIC.Items.Clear();
			txtWave.Enabled = false;
			cmdWave.Enabled = false;
			if (!_lfd.HasRmap)
				if (_lfd.Resources[0].Type == Resource.ResourceType.Voic || _lfd.Resources[0].Type == Resource.ResourceType.Blas)
				{
					_lfd.Resources[0].Tag = lstVOIC.Items.Add(_lfd.Resources[0].Name);
					return;
				}
				else return;

			for (int i = 0; i < _lfd.Rmap.NumberOfHeaders; i++)
				if (_lfd.Rmap.SubHeaders[i].Type == Resource.ResourceType.Voic || _lfd.Rmap.SubHeaders[i].Type == Resource.ResourceType.Blas)
				{
					_lfd.Resources[i].Tag = lstVOIC.Items.Add(_lfd.Rmap.SubHeaders[i].Name);		// if valid source, add it to the lst
				}
		}
		private void lstVOIC_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtWave.Enabled = true;
			cmdWave.Enabled = true;
			txtWave.Text = Directory.GetCurrentDirectory() + "\\" + lstVOIC.SelectedItem.ToString() + ".wav";
			cmdSave.Enabled = true;
			// play sound from memory as index changes for preview
			MemoryStream mem = new MemoryStream();
			vocToWav(mem);
			byte[] soundBytes = new byte[mem.Length];
			mem.Position = 0;
			mem.Read(soundBytes, 0, (int)mem.Length);	//read it back into an array
			PlaySound(soundBytes, IntPtr.Zero, SoundFlags.SND_MEMORY | SoundFlags.SND_ASYNC);
			mem.Close();
		}
		private void savFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			cmdSave.Enabled = true;
			txtWave.Text = savFile.FileName;
		}
		private void cmdSave_Click(object sender, EventArgs e)
		{
			if (optExport.Checked)
			{
				FileStream stream = null;
				try
				{
					stream = File.OpenWrite(txtWave.Text);
					stream.SetLength(1);	//resets file in case of overwrite
					vocToWav(stream);
					stream.Close();
				}
				catch (Exception x)
				{
					MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					stream.Close();
					return;
				}
			}
			else
			{
				try
				{
					string s_name = Path.GetFileNameWithoutExtension(txtWave.Text);
					if (lstVOIC.Items.IndexOf(s_name) == -1) throw new Exception("WAV file name must match an existing VOIC/BLAS to overwrite");
					wavToVoc(lstVOIC.Items.IndexOf(s_name));
				}
				catch (Exception x) { MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			}
		}

		private void vocToWav(Stream s)
		{
			BinaryWriter bw = new BinaryWriter(s);
			Blas blas = _currentBlas;
			// WAV_HEADER
			bw.Write("RIFF".ToCharArray());
			s.Position += 4;				// skip over, come back to later, P = 4  (file.length-8)
			bw.Write("WAVE".ToCharArray());
			// WAV_DATA_BLOCK
			// fmt_HEADER
			bw.Write("fmt ".ToCharArray());
			bw.Write((uint)16);				// fmt block length
			// fmt_DATA_BLOCK
			bw.Write((short)1);				// uncompressed PCM
			bw.Write((short)1);				// NumChannels (Mono)
			bw.Write((uint)blas.Frequency);			// SampleRate
			bw.Write((uint)blas.Frequency);			// ByteRate (SampleRate * NumChannels * BitsPerSample/8) [SR * 1 * 8/8]
			bw.Write((short)1);				// BlockAlign (NumChannels * BitsPerSample/8) [1 * 8/8]
			bw.Write((short)8);				// BitsPerSample
			// data_HEADER
			bw.Write("data".ToCharArray());
			s.Position += 4;				// skip over, come back to later, P = 40 (file.length-44);
			foreach (Blas.SoundDataBlock sdb in blas.SoundBlocks)
				if (sdb.Data != null)
					if (sdb.DoesRepeat)
						for (int i = 0; i < (sdb.NumberOfRepeats != -1 ? sdb.NumberOfRepeats + 1 : 4); i++)	// repeat 4 times for infinite repeats
							bw.Write(sdb.Data);
					else bw.Write(sdb.Data);
			s.SetLength(s.Position);
			s.Position = 4;
			bw.Write((uint)(s.Length-8));
			s.Position = 40;
			bw.Write((uint)(s.Length-44));
		}
		private void wavToVoc(int index)
		{
			/// okay, here's what I'm going to allow:
			/// 10-12 kHz , mono, 8bit sample size, uncompressed, single data chunk, filename must match VOIC name
			/// anything other than that, and I'll try to figure something out (after a lot of testing)
			FileStream stream = File.Open(txtWave.Text, FileMode.Open, FileAccess.ReadWrite);
			long pos_fmt, pos_data,  data_length;
			BinaryReader br = new BinaryReader(stream);
			stream.Position = 0;
			// going to start with just ensuring the format is right
			#region validation
			if (new string(br.ReadChars(4)) != "RIFF") throw new Exception("Invalid file type");
			stream.Position += 4;
			if (new string(br.ReadChars(4)) != "WAVE") throw new Exception("Invalid file type");
			// find the right chunks, since they can technically be *anywhere* in the file (fucking non-standard filetype)
			for (;;)
			{
				if (new string(br.ReadChars(4)) == "fmt ")
				{
					pos_fmt = stream.Position - 4;
					break;
				}
				if ((stream.Position + 10) == stream.Length) throw new Exception("fmt chunk missing, invalid WAV file");
				stream.Position -= 3;
			}
			stream.Position = 12;
			for (;;)
			{
				if (new string(br.ReadChars(4)) == "data")
				{
					pos_data = stream.Position - 4;
					break;
				}
				if ((stream.Position + 4) == stream.Length) throw new Exception("data chunk missing, invalid WAV file");
				stream.Position -= 3;
			}
			stream.Position = pos_fmt + 8;
			if (br.ReadUInt16() != 1) throw new Exception("Incorrect format, WAV must be uncompressed PCM");
			if (br.ReadUInt16() != 1) throw new Exception("Incorrect format, WAV must be mono");
			int freq = br.ReadInt32();
			if (freq < 10000 || freq > 12000) throw new Exception("Incorrect format, WAV must be between 10-12 kHz");
			stream.Position += 6;
			if (br.ReadUInt16() != 8) throw new Exception("Incorrect format, WAV must be 8-bit");
			#endregion
			/// okay, now that the file has been confirmed as legit, time to write this thing.
			/// the header (including the VOC header) is predetermined, and already in place.
			/// Really only need to take care of a couple length values, which we need to calculate first
			/// to determine if we need to follow up with shifting the entire file past that point (which is most likely)
			stream.Position = pos_data + 4;
			data_length = br.ReadUInt32();					// WAV data block length
			Blas blas = null;
			for (int i = 0; i < _lfd.Resources.Count; i++)
				if ((int)_lfd.Resources[i].Tag == index)
				{
					blas = (Blas)_lfd.Resources[i];
					index = i;
					break;
				}
			stream.Position = pos_data + 8;
			blas.SoundBlocks[0].Data = br.ReadBytes((int)data_length);
			stream.Close();
			blas.Frequency = freq;
			_lfd.Resources[index] = blas;
			_lfd.Write();
		}

		private void optExport_CheckedChanged(object sender, EventArgs e)
		{
			if (optExport.Checked)
			{
				label1.Text = "Resource file (LFD) to extract sound from";
				label3.Text = "Wave file to save as";
			}
			else
			{
				label1.Text = "Resource file (LFD) to save sound in";
				label3.Text = "Wave file to load (must match VOIC/BLAS name)";
			}
		}
		private void cmdExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void cmdDump_Click(object sender, EventArgs e)
		{
			Blas blas = _currentBlas;
			FileStream dump = File.OpenWrite(_lfd.FilePath + "_dump.txt");
			new BinaryWriter(dump).Write(blas.RawData);
			dump.SetLength(dump.Position);
			dump.Close();
		}

		Blas _currentBlas
		{
			get
			{
				for (int i = 0; i < _lfd.Resources.Count; i++)
					if ((int)_lfd.Resources[i].Tag == lstVOIC.SelectedIndex) return (Blas)_lfd.Resources[i];
				return null;
			}
		}
	}
}
