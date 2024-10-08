﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SDL3;

// SDL_hints.h located at https://github.com/libsdl-org/SDL/blob/main/include/SDL3/SDL_hints.h.
unsafe partial class SDL
{
	/// <summary>
	/// Set a hint with a specific priority.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetHintWithPriority">documentation</see> for more details.
	/// </remarks>
	/// <param name="name">The hint to set.</param>
	/// <param name="value">The value of the hint variable.</param>
	/// <param name="priority">The <see cref="SDL_HintPriority"/> level for the hint.</param>
	/// <returns>True on success or false on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetHintWithPriority", StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalAs(NativeBool)]
	public static partial bool SetHintWithPriority(string name, string value, SDL_HintPriority priority);

	/// <summary>
	/// Set a hint with normal priority.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetHint">documentation</see> for more details.
	/// </remarks>
	/// <param name="name">The hint to set.</param>
	/// <param name="value">The value of the hint variable.</param>
	/// <returns>True on success or false on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetHint", StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalAs(NativeBool)]
	public static partial bool SetHint(string name, string value);

	/// <summary>
	/// Reset a hint to the default value.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_ResetHint">documentation</see> for more details.
	/// </remarks>
	/// <param name="name">The hint to set.</param>
	/// <returns>True on success or false on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_ResetHint", StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalAs(NativeBool)]
	public static partial bool ResetHint(string name);

	/// <summary>
	/// Reset all hints to the default values.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_ResetHints">documentation</see> for more details.
	/// </remarks>
	[LibraryImport(LibraryName, EntryPoint = "SDL_ResetHints")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void ResetHints();

	/// <summary>
	/// Get the value of a hint.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_GetHint">documentation</see> for more details.
	/// </remarks>
	/// <param name="name">The hint to query.</param>
	/// <returns>The string value of a hint or <see langword="null"/> if the hint isn't set.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_GetHint", StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDL_StringMarshaller))]
	public static partial string? GetHint(string name);

	/// <summary>
	/// Get the boolean value of a hint variable.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_GetHintBoolean">documentation</see> for more details.
	/// </remarks>
	/// <param name="name">The name of the hint to get the boolean value from.</param>
	/// <param name="defaultValue">The value to return if the hint does not exist.</param>
	/// <returns>The boolean value of a hint or the provided default value if the hint does not exist.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_GetHintBoolean", StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalAs(NativeBool)]
	public static partial bool GetHintBoolean(string name, [MarshalAs(NativeBool)] bool defaultValue);

	/// <summary>
	/// Add a function to watch a particular hint.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_AddHintCallback">documentation</see> for more details.
	/// </remarks>
	/// <param name="name">The hint to watch.</param>
	/// <param name="callback">An <c>SDL_HintCallback</c> function that will be called when the hint value changes.</param>
	/// <param name="userData">A pointer to pass to the callback function.</param>
	/// <returns>True on success or false on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_AddHintCallback", StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalAs(NativeBool)]
	public static partial bool AddHintCallback(string name, delegate* unmanaged[Cdecl]<nint, byte*, byte*, byte*, void> callback, nint userData);

	/// <summary>
	/// Remove a function watching a particular hint.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_RemoveHintCallbackHintCallback">documentation</see> for more details.
	/// </remarks>
	/// <param name="name">The hint being watched.</param>
	/// <param name="callback">An <c>SDL_HintCallback</c> function that will be called when the hint value changes.</param>
	/// <param name="userData">A pointer being passed to the callback function.</param>
	[LibraryImport(LibraryName, EntryPoint = "SDL_RemoveHintCallback", StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void RemoveHintCallback(string name, delegate* unmanaged[Cdecl]<nint, byte*, byte*, byte*, void> callback, nint userData);
}