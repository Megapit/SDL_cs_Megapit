﻿using System;

namespace SDL_cs;

/// <summary>
/// A bitmask of pressed mouse buttons, as reported by <see cref="GetMouseState(out float, out float)"/>, etc.
/// </summary>
/// <remarks>
/// Refer to the official documentation <see href="https://wiki.libsdl.org/SDL3/SDL_MouseButtonFlags">here</see> for more details.
/// </remarks>
[Flags]
public enum SDL_MouseButtonFlags : uint
{
	Lmask = 1u << (SDL_MouseButton.Left - 1),
	Mmask = 1u << (SDL_MouseButton.Middle - 1),
	Rmask = 1u << (SDL_MouseButton.Right - 1),
	X1mask = 1u << (SDL_MouseButton.X1 - 1),
	X2mask = 1u << (SDL_MouseButton.X2 - 1)
}