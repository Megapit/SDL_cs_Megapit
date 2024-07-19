﻿using System.Runtime.InteropServices;

namespace SDL_cs;

/// <summary>
/// Defines the C# bindings to operate with SDL.
/// </summary>
public static unsafe partial class SDL
{
	/// <summary>
	/// The name of the library: SDL3.
	/// </summary>
	private const string LibraryName = "SDL3";

	/// <summary>
	/// The size of SDL_bool: an i4.
	/// </summary>
	private const UnmanagedType NativeBool = UnmanagedType.I4;
}