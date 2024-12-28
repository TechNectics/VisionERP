using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

public class CustomAssemblyLoadContext : AssemblyLoadContext
{
    public IntPtr LoadUnmanagedLibrary(string absolutePath)
    {
        try
        {
            return LoadUnmanagedDll(absolutePath);
        }
        catch (DllNotFoundException ex)
        {
            Console.WriteLine($"DLL Not Found: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Loading DLL: {ex.Message}");
            throw;
        }
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        try
        {
            return LoadUnmanagedDllFromPath(unmanagedDllName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load unmanaged DLL '{unmanagedDllName}': {ex.Message}");
            throw;
        }
    }

    protected override Assembly Load(AssemblyName assemblyName)
    {
        throw new NotImplementedException();
    }
}
