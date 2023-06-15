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
    public static class KPFBackupButtonListener
    {
        public static void backupOriginalKPFButton_Click(object? sender, EventArgs e)
        {
            // Copy the kpf file and rename it
            if (File.Exists(GlobalDeclarations.DOOM64KPF))
            {
                string filePath = GlobalDeclarations.DOOM64KPF;
                byte[] expectedHash = new byte[]
                {
                    0xA1, 0x11, 0x3F, 0x6B, 0x5F, 0x87, 0x8A, 0xC9,
                    0x09, 0x61, 0xD4, 0x38, 0xA7, 0x0F, 0xBB, 0x0A,
                    0x3E, 0xCB, 0x60, 0xC0, 0x71, 0xA6, 0xC1, 0xF0,
                    0xC7, 0x86, 0x7A, 0x0E, 0x5A, 0xD4, 0x3F, 0x32
                };

                using (var sha256 = SHA256.Create())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        byte[] hash = sha256.ComputeHash(stream);

                        if (StructuralComparisons.StructuralEqualityComparer.Equals(hash, expectedHash))
                        {
                            // Happy
                            File.Copy(GlobalDeclarations.DOOM64KPF, GlobalDeclarations.DOOM64KPFORIG);
                            if (File.Exists(GlobalDeclarations.DOOM64KPFORIG))
                            {
                                MessageBox.Show("SUCCESS: Doom64.kpf has been backed up.",
                                    "KPF Backup",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR: Doom64.kpf hash does not match the expected hash.",
                                    "KPF Hash Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
