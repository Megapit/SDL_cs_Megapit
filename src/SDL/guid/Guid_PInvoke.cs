﻿using System.Runtime.InteropServices;

namespace SDL_cs;

unsafe partial class PInvoke
{
	[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GUIDToString(SDL_Guid guid, byte* pszGuid, int cbGuid);

	[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_Guid SDL_GUIDFromString(byte* pchGuid);
}