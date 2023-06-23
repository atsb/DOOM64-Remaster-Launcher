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
    public static class BNETZipButtonListener
    {
        public static void bNetZipButton_Click()
        {
            System.IO.DirectoryInfo deleteEntireDirectory = new DirectoryInfo(GlobalDeclarations.BNETDIR);

            // If the BNet.kpf exists, delete it
            if (File.Exists(GlobalDeclarations.BNETKPF))
            {
                File.Delete(GlobalDeclarations.BNETKPF);
            }

            // Zip the BNet directory into BNet.kpf
            ZipDirectory.ZipKPFDirectory(GlobalDeclarations.BNETDIR, GlobalDeclarations.BNETKPF);
            if (File.Exists(GlobalDeclarations.BNETKPF))
            {
                foreach (FileInfo file in deleteEntireDirectory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in deleteEntireDirectory.GetDirectories())
                {
                    dir.Delete(true);
                }
                Directory.Delete(GlobalDeclarations.BNETDIR);
                AutoClosingMessageBox.Show("SUCCESS: BNet.kpf has been created!", "KPF Creation", 3000);
            }
        }
    }
}
