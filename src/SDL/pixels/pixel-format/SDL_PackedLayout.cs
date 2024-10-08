﻿namespace SDL3;

/// <summary>
/// Packed component layout.
/// </summary>
/// <remarks>
/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_PackedLayout">documentation</see> for more details.
/// </remarks>
public enum SDL_PackedLayout
{
	None,
	_332,
	_4444,
	_1555,
	_5551,
	_565,
	_8888,
	_2101010,
	_1010102
}