// Decompiled with JetBrains decompiler
// Type: SqlServerTypes.Utilities
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SqlServerTypes
{
  public class Utilities
  {
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr LoadLibrary(string libname);

    public static void LoadNativeAssemblies(string rootApplicationPath)
    {
      string nativeBinaryPath = IntPtr.Size > 4 ? Path.Combine(rootApplicationPath, "SqlServerTypes\\x64\\") : Path.Combine(rootApplicationPath, "SqlServerTypes\\x86\\");
      Utilities.LoadNativeAssembly(nativeBinaryPath, "msvcr120.dll");
      Utilities.LoadNativeAssembly(nativeBinaryPath, "SqlServerSpatial140.dll");
    }

    private static void LoadNativeAssembly(string nativeBinaryPath, string assemblyName)
    {
      if (Utilities.LoadLibrary(Path.Combine(nativeBinaryPath, assemblyName)) == IntPtr.Zero)
        throw new Exception(string.Format("Error loading {0} (ErrorCode: {1})", (object) assemblyName, (object) Marshal.GetLastWin32Error()));
    }
  }
}
