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

using System.IO;

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

                if (File.Exists(GlobalDeclarations.BNETKPFORIG))
                {
                    MessageBox.Show("INFORMATION: BNet.kpf backup already exists",
                                    "KPF Backup",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                }
                else
                {
                    File.Copy(GlobalDeclarations.BNETKPF, GlobalDeclarations.BNETKPFORIG);
                }
            }
        }
    }
}
