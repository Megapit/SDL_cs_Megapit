﻿using System.Runtime.InteropServices;

namespace SDL_cs;

/// <summary>
/// The structure that defines a display mode.
/// </summary>
/// <remarks>
/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_DisplayMode">documentation</see> for more details.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SDL_DisplayMode
{
	/// <summary>
	/// The display this mode is associated with.
	/// </summary>
	public SDL_DisplayId DisplayId;

	/// <summary>
	/// Pixel format.
	/// </summary>
	public SDL_PixelFormat Format;

	/// <summary>
	/// Width, in pixels.
	/// </summary>
	public int Width;

	/// <summary>
	/// Height, in pixels.
	/// </summary>
	public int Height;

	/// <summary>
	/// Scale converting size to pixels (e.g. a 1920x1080 mode with 2.0 scale would have 3840x2160 pixels).
	/// </summary>
	public float PixelDensity;

	/// <summary>
	/// Refresh rate (or zero for unspecified).
	/// </summary>
	public float RefreshRate;

	private readonly nint _driverData;
}