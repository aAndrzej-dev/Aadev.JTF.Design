using System.Runtime.InteropServices;

namespace Aadev.JTF.Design;
internal static partial class PInvoke
{
    [LibraryImport("user32.dll")]
    internal static partial IntPtr SetClipboardViewer(IntPtr hWnd);
    [LibraryImport("user32.dll")]
    internal static partial IntPtr ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNext);
}
