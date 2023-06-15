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

namespace GameLauncher
{
    public static class KPFZipButtonListener
    {
        public static void kpfZipButton_Click(object? sender, EventArgs e)
        {
            // If the Doom64.kpf exists, delete it
            if (File.Exists(GlobalDeclarations.DOOM64KPF))
            {
                File.Delete(GlobalDeclarations.DOOM64KPF);
            }

            // Zip the Doom64 directory into Doom64.kpf
            ZipDirectory.ZipKPFDirectory(GlobalDeclarations.DOOM64DIR, GlobalDeclarations.DOOM64KPF);
            if (File.Exists(GlobalDeclarations.DOOM64KPF))
            {
                MessageBox.Show("SUCCESS: Doom64.kpf has been created.",
                    "KPF Creation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
