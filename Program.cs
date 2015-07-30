/*
 * TieSoundEditor.exe, Editor for BLAS and VOIC resources in LFD files
 * Copyright (C) 2007 Michael Gaisser (mjgaisser@gmail.com)
 * 
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the Mozilla Public License; either version 2.0 of the
 * License, or (at your option) any later version.
 *
 * This program is "as is" without warranty of any kind; including that the
 * program is free of defects, merchantable, fit for a particular purpose or
 * non-infringing. See the full license text for more details.
 *
 * If a copy of the MPL (MPL.txt) was not distributed with this file,
 * you can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Version: 1.1.1
 */

using System;
using System.Windows.Forms;

namespace Idmr.TieSoundEditor
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmTSE());
		}
	}
}
