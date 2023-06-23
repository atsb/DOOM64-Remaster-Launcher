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
    public static class BNETBackupButtonListener
    {
        public static void backupOriginalBNetButton_Click()
        {
            // Copy the kpf file and rename it
            if (File.Exists(GlobalDeclarations.BNETKPF))
            {
                string filePath = GlobalDeclarations.BNETKPF;
                string expectedHash = "F97BF88B1AB7364C089F533B5B8D1AC574FEF6165D066258308688F64AA46801";

                using (var sha256 = SHA256.Create())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        byte[] computedHash = sha256.ComputeHash(stream);

                        // Convert the expected hash from hex to byte
                        byte[] expectedHashBytes = new byte[expectedHash.Length / 2];
                        for (int i = 0; i < expectedHashBytes.Length; i++)
                        {
                            expectedHashBytes[i] = Convert.ToByte(expectedHash.Substring(i * 2, 2), 16);
                        }

                        // Compare the hash
                        if (StructuralComparisons.StructuralEqualityComparer.Equals(computedHash, expectedHashBytes))
                        {
                            if (File.Exists(GlobalDeclarations.BNETKPFORIG))
                            {
                                MessageBox.Show("INFORMATION: BNet.kpf backup already exists",
                                                "KPF Backup",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Information);
                            } else {
                                File.Copy(GlobalDeclarations.BNETKPF, GlobalDeclarations.BNETKPFORIG);
                            }

                            if (File.Exists(GlobalDeclarations.BNETKPFORIG))
                            {
                                MessageBox.Show("SUCCESS: BNet.kpf has been backed up.",
                                    "KPF Backup",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR: BNet.kpf hash does not match the expected hash.",
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
