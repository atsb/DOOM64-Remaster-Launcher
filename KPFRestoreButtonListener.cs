/*  A DOOM64 Remaster Launcher
    Copyright (C) 2023 Gibbon

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml.Linq;
using DOOM64_Launcher;

namespace GameLauncher
{
    public static class KPFRestoreButtonListener
    {
        public static void restoreOriginalKPFButton_Click(object? sender, EventArgs e)
        {   // Happy
            if (File.Exists(GlobalDeclarations.DOOM64KPFORIG))
            {
                File.Delete(GlobalDeclarations.DOOM64KPF);
                File.Copy(GlobalDeclarations.DOOM64KPFORIG, GlobalDeclarations.DOOM64KPF);
                AutoClosingMessageBox.Show("SUCCESS: Doom64.kpf has been restored.", "KPF Restore", 3000);
            }
            if (File.Exists(GlobalDeclarations.BNETKPFORIG))
            {
                File.Delete(GlobalDeclarations.BNETKPF);
                File.Copy(GlobalDeclarations.BNETKPFORIG, GlobalDeclarations.BNETKPF);
                AutoClosingMessageBox.Show("SUCCESS: BNet.kpf has been restored.", "KPF Restore", 3000);
            }
            else if (!File.Exists(GlobalDeclarations.BNETKPFORIG) || !File.Exists(GlobalDeclarations.DOOM64KPFORIG))
            {
                AutoClosingMessageBox.Show("ERROR: Backup KPF's are missing.", "KPF Missing", 3000);
            }
        }
    }
}
