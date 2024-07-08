﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace SDL_cs;

// SDL_surface.h located at https://github.com/libsdl-org/SDL/blob/main/include/SDL3/SDL_surface.h.
unsafe partial class SDL
{
	/// <summary>
	/// Evaluates to true if the surface needs to be locked before access.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_MUSTLOCK">here</see>
	/// </remarks>
	/// <param name="s">The <see cref="SDL_Surface"/> structure to evaluate.</param>
	/// <returns>True if <paramref name="s"/> needs to be locked, otherwise false.</returns>
	[Macro]
	public static bool MustLock(SDL_Surface* s)
	{
		return (s->Flags & SDL_SurfaceFlags.RleAccel) != 0;
	}

	/// <summary>
	/// Allocate a new RGB surface with a specific pixel format.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_CreateSurface">documentation</see> for more details.
	/// </remarks>
	/// <param name="width">The width of the surface.</param>
	/// <param name="height">The height of the surface.</param>
	/// <param name="format">The <see cref="SDL_PixelFormatEnum"/> for the new surface's pixel format.</param>
	/// <returns>The new <see cref="SDL_Surface"/> structure that is created or <see langword="null"/> if it fails; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_CreateSurface")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* CreateSurface(int width, int height, SDL_PixelFormatEnum format);

	/// <summary>
	/// Allocate a new RGB surface with a specific pixel format and existing pixel data.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_CreateSurfaceFrom">documentation</see> for more details.
	/// </remarks>
	/// <param name="pixels">A pointer to existing pixel data.</param>
	/// <param name="width">The width of the surface.</param>
	/// <param name="height">The height of the surface.</param>
	/// <param name="pitch">The number of bytes between each row, including padding.</param>
	/// <param name="format">The <see cref="SDL_PixelFormatEnum"/> for the new surface's pixel format.</param>
	/// <returns>The new <see cref="SDL_Surface"/> structure that is created or <see langword="null"/> if it fails; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_CreateSurfaceFrom")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* CreateSurfaceFrom([In] byte[]? pixels, int width, int height, int pitch, SDL_PixelFormatEnum format);

	/// <summary>
	/// Free an RGB surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_DestroySurface">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> to free.</param>
	[LibraryImport(LibraryName, EntryPoint = "SDL_DestroySurface")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void DestroySurface(SDL_Surface* surface);

	/// <summary>
	/// Get the properties associated with a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_GetSurfaceProperties">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to query.</param>
	/// <returns>A valid property ID on success or <see cref="SDL_PropertiesId.Invalid"/> on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_GetSurfaceProperties")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_PropertiesId GetSurfaceProperties(SDL_Surface* surface);

	/// <summary>
	/// Set the colorspace used by a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetSurfaceColorspace">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to update.</param>
	/// <param name="colorspace">An <see cref="SDL_Colorspace"/> value describing the surface colorspace.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetSurfaceColorspace")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SetSurfaceColorspace(SDL_Surface* surface, SDL_Colorspace colorspace);

	/// <summary>
	/// Get the colorspace used by a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_GetSurfaceColorspace">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to query.</param>
	/// <param name="colorspace">A pointer filled in with an <see cref="SDL_Colorspace"/> value describing the surface colorspace.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_GetSurfaceColorspace")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int GetSurfaceColorspace(SDL_Surface* surface, out SDL_Colorspace colorspace);

	/// <summary>
	/// Set the palette used by a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetSurfacePalette">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to update.</param>
	/// <param name="palette">The <see cref="SDL_Palette"/> structure to use.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetSurfacePalette")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SetSurfacePalette(SDL_Surface* surface, SDL_Palette* palette);

	/// <summary>
	/// Set up a surface for directly accessing the pixels.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_LockSurface">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to be locked.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_LockSurface")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int LockSurface(SDL_Surface* surface);

	/// <summary>
	/// Release a surface after directly accessing the pixels.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_UnlockSurface">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to be unlocked.</param>
	[LibraryImport(LibraryName, EntryPoint = "SDL_UnlockSurface")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void UnlockSurface(SDL_Surface* surface);

	// FIXME: implement SDL_LoadBMP_IO()

	/// <summary>
	/// Load a BMP image from a file.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_LoadBMP">documentation</see> for more details.
	/// </remarks>
	/// <param name="file">The BMP file to load.</param>
	/// <returns>A pointer to a new <see cref="SDL_Surface"/> structure or <see langword="null"/> if there was an error; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_LoadBMP", StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* LoadBMP(string file);

	// FIXME: implement SDL_SaveBMP_IO()

	/// <summary>
	/// Save a surface to a file.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SaveBMP">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure containing the image to be saved.</param>
	/// <param name="file">A file to save to.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SaveBMP", StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SaveBMP(SDL_Surface* surface, string file);

	/// <summary>
	/// Set the RLE acceleration hint for a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetSurfaceRLE">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to optimize.</param>
	/// <param name="enable">False to disable, true to enable RLE acceleration.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetSurfaceRLE")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SetSurfaceRLE(SDL_Surface* surface, [MarshalAs(UnmanagedType.I4)] bool flag);

	/// <summary>
	/// Returns whether the surface is RLE enabled.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SurfaceHasRLE">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to query.</param>
	/// <returns>True if the surface has RLE enabled, false otherwise.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SurfaceHasRLE")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalAs(UnmanagedType.I4)]
	public static partial bool SurfaceHasRLE(SDL_Surface* surface);

	/// <summary>
	/// Set the color key (transparent pixel) in a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetSurfaceColorKey">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to update.</param>
	/// <param name="enable">True to enable color key, false to disable color key.</param>
	/// <param name="key">The transparent pixel.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetSurfaceColorKey")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SetSurfaceColorKey(SDL_Surface* surface, [MarshalAs(UnmanagedType.I4)] bool flag, uint key);

	/// <summary>
	/// Returns whether the surface has a color key.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SurfaceHasColorKey">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to query.</param>
	/// <returns>True if the surface has a color key, false otherwise.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SurfaceHasColorKey")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalAs(UnmanagedType.I4)]
	public static partial bool SurfaceHasColorKey(SDL_Surface* surface);

	/// <summary>
	/// Get the color key (transparent pixel) for a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_GetSurfaceColorKey">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to query.</param>
	/// <param name="key">A pointer filled in with the transparent pixel.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_GetSurfaceColorKey")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int GetSurfaceColorKey(SDL_Surface* surface, out uint key);

	/// <summary>
	/// Set an additional color value multiplied into blit operations.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetSurfaceColorMod">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to update.</param>
	/// <param name="r">The red color value multiplied into blit operations.</param>
	/// <param name="g">The green color value multiplied into blit operations.</param>
	/// <param name="b">The blue color value multiplied into blit operations.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetSurfaceColorMod")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SetSurfaceColorMod(SDL_Surface* surface, byte r, byte g, byte b);

	/// <summary>
	/// Get the additional color value multiplied into blit operations.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_GetSurfaceColorMod">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to query.</param>
	/// <param name="r">A pointer filled in with the current red color value.</param>
	/// <param name="g">A pointer filled in with the current green color value.</param>
	/// <param name="b">A pointer filled in with the current blue color value.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_GetSurfaceColorMod")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int GetSurfaceColorMod(SDL_Surface* surface, out byte r, out byte g, out byte b);

	/// <summary>
	/// Set an additional alpha value used in blit operations.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetSurfaceAlphaMod">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to update.</param>
	/// <param name="alpha">The alpha value multiplied into blit operations.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetSurfaceAlphaMod")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SetSurfaceAlphaMod(SDL_Surface* surface, byte alpha);

	/// <summary>
	/// Get the additional alpha value used in blit operations.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_GetSurfaceAlphaMod">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to query.</param>
	/// <param name="alpha">A pointer filled in with the current alpha value.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_GetSurfaceAlphaMod")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int GetSurfaceAlphaMod(SDL_Surface* surface, out byte alpha);

	/// <summary>
	/// Set the blend mode used for blit operations.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetSurfaceBlendMode">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to update.</param>
	/// <param name="blendMode">The <see cref="SDL_BlendMode"/> to use for blit blending.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetSurfaceBlendMode")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode blendMode);

	/// <summary>
	/// Get the blend mode used for blit operations.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_GetSurfaceBlendMode">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to query.</param>
	/// <param name="blendMode">A pointer filled in with the current <see cref="SDL_BlendMode"/>.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_GetSurfaceBlendMode")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int GetSurfaceBlendMode(SDL_Surface* surface, out SDL_BlendMode blendMode);

	/// <summary>
	/// Set the clipping rectangle for a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetSurfaceClipRect">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to be clipped.</param>
	/// <param name="rect">The <see cref="SDL_Rect"/> structure representing the clipping rectangle, or <see cref="nint.Zero""/> to disable clipping.</param>
	/// <returns>True if the rectangle intersects the surface, otherwise false and blits will be completely clipped.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetSurfaceClipRect")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalAs(UnmanagedType.I4)]
	public static partial bool SetSurfaceClipRect(SDL_Surface* surface, in SDL_Rect rect);

	/// <summary>
	/// Set the clipping rectangle for a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SetSurfaceClipRect">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure to be clipped.</param>
	/// <param name="rect">The <see cref="SDL_Rect"/> structure representing the clipping rectangle, or <see cref="nint.Zero"/> to disable clipping.</param>
	/// <returns>True if the rectangle intersects the surface, otherwise false and blits will be completely clipped.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SetSurfaceClipRect")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalAs(UnmanagedType.I4)]
	public static partial bool SetSurfaceClipRect(SDL_Surface* surface, nint rect);

	/// <summary>
	/// Get the clipping rectangle for a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_GetSurfaceClipRect">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The <see cref="SDL_Surface"/> structure representing the surface to be clipped.</param>
	/// <param name="rect">An <see cref="SDL_Rect"/> structure representing the clipping rectangle for the surface.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_GetSurfaceClipRect")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int GetSurfaceClipRect(SDL_Surface* surface, out SDL_Rect rect);

	/// <summary>
	/// Flip a surface vertically or horizontally.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_FlipSurface">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The surface to flip.</param>
	/// <param name="flip">The direction to flip.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_FlipSurface")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int FlipSurface(SDL_Surface* surface, SDL_FlipMode flip);

	/// <summary>
	/// Creates a new surface identical to the existing surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_DuplicateSurface">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The surface to duplicate.</param>
	/// <returns>A copy of the surface, or <see langword="null"/> on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_DuplicateSurface")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* DuplicateSurface(SDL_Surface* surface);

	/// <summary>
	/// Copy an existing surface to a new surface of the specified format.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_ConvertSurface">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The existing <see cref="SDL_Surface"/> structure to convert.</param>
	/// <param name="format">The <see cref="SDL_PixelFormat"/> structure that the new surface is optimized for.</param>
	/// <returns>The new <see cref="SDL_Surface"/> structure that is created or <see langword="null"/> if it fails; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_ConvertSurface")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* ConvertSurface(SDL_Surface* surface, SDL_PixelFormat* format);

	/// <summary>
	/// Copy an existing surface to a new surface of the specified format.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_ConvertSurfaceFormat">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The existing <see cref="SDL_Surface"/> structure to convert.</param>
	/// <param name="format">The new pixel format.</param>
	/// <returns>The new <see cref="SDL_Surface"/> structure that is created or <see langword="null"/> if it fails; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_ConvertSurfaceFormat")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* ConvertSurfaceFormat(SDL_Surface* surface, SDL_PixelFormatEnum format);

	/// <summary>
	/// Copy an existing surface to a new surface of the specified format and colorspace.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_ConvertSurfaceFormatAndColorspace">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The existing <see cref="SDL_Surface"/> structure to convert.</param>
	/// <param name="format">The new pixel format.</param>
	/// <param name="colorspace">The new colorspace.</param>
	/// <param name="props">An <see cref="SDL_PropertiesId"/> with additional color properties, or <see cref="SDL_PropertiesId.Invalid"/>.</param>
	/// <returns>The new <see cref="SDL_Surface"/> structure that is created or <see langword="null"/> if it fails; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_ConvertSurfaceFormatAndColorspace")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* ConvertSurfaceFormatAndColorspace(SDL_Surface* surface, SDL_PixelFormatEnum format, SDL_Colorspace colorspace, SDL_PropertiesId props);

	/// <summary>
	/// Copy a block of pixels of one format to another format.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_ConvertPixels">documentation</see> for more details.
	/// </remarks>
	/// <param name="width">The width of the block to copy, in pixels.</param>
	/// <param name="height">The height of the block to copy, in pixels.</param>
	/// <param name="srcFormat">An <see cref="SDL_PixelFormatEnum"/> value of the <paramref name="src"/> pixels format.</param>
	/// <param name="src">A pointer to the source pixels.</param>
	/// <param name="srcPitch">The pitch of the source pixels, in bytes.</param>
	/// <param name="dstFormat">An <see cref="SDL_PixelFormatEnum"/> value of the <paramref name="dst"/> pixels format.</param>
	/// <param name="dst">A pointer to be filled in with new pixel data.</param>
	/// <param name="dstPitch">The pitch of the destination pixels, in bytes.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_ConvertPixels")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int ConvertPixels(int width, int height, SDL_PixelFormatEnum srcFormat, [In] byte[] src, int srcPitch, SDL_PixelFormatEnum dstFormat, [In, Out] byte[] dst, int dstPitch);

	/// <summary>
	/// Copy a block of pixels of one format and colorspace to another format and colorspace.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_ConvertPixelsAndColorspace">documentation</see> for more details.
	/// </remarks>
	/// <param name="width">The width of the block to copy, in pixels.</param>
	/// <param name="height">The height of the block to copy, in pixels.</param>
	/// <param name="srcFormat">An <see cref="SDL_PixelFormatEnum"/> value of the <paramref name="src"/> pixels format.</param>
	/// <param name="srcColorspace">An <see cref="SDL_Colorspace"/> value describing the colorspace of the <paramref name="src"/> pixels.</param>
	/// <param name="srcProps">An <see cref="SDL_PropertiesId"/> with additional source color properties, or <see cref="SDL_PropertiesId.Invalid"/>.</param>
	/// <param name="src">A pointer to the source pixels.</param>
	/// <param name="srcPitch">The pitch of the source pixels, in bytes.</param>
	/// <param name="dstFormat">An <see cref="SDL_PixelFormatEnum"/> value of the <paramref name="dst"/> pixels format.</param>
	/// <param name="dstColorspace">An <see cref="SDL_Colorspace"/> value describing the colorspace of the <paramref name="dst"/> pixels.</param>
	/// <param name="dstProps">An <see cref="SDL_PropertiesId"/> with additional destination color properties, or <see cref="SDL_PropertiesId.Invalid"/>.</param>
	/// <param name="dst">A pointer to be filled in with new pixel data.</param>
	/// <param name="dstPitch">The pitch of the destination pixels, in bytes.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_ConvertPixelsAndColorspace")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int ConvertPixelsAndColorspace(int width, int height, SDL_PixelFormatEnum srcFormat, SDL_Colorspace srcColorspace, SDL_PropertiesId srcProps, [In] byte[] src, int srcPitch, SDL_PixelFormatEnum dstFormat, SDL_Colorspace dstColorspace, SDL_PropertiesId dstProps, [In, Out] byte[] dst, int dstPitch);

	/// <summary>
	/// Premultiply the alpha on a block of pixels.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_PremultiplyAlpha">documentation</see> for more details.
	/// </remarks>
	/// <param name="width">The width of the block to convert, in pixels.</param>
	/// <param name="height">The height of the block to convert, in pixels.</param>
	/// <param name="srcFormat">An <see cref="SDL_PixelFormatEnum"/> value of the <paramref name="src"/> pixels format.</param>
	/// <param name="src">A pointer to the source pixels.</param>
	/// <param name="srcPitch">The pitch of the source pixels, in bytes.</param>
	/// <param name="dstFormat">An <see cref="SDL_PixelFormatEnum"/> value of the <paramref name="dst"/> pixels format.</param>
	/// <param name="dst">A pointer to be filled in with premultiplied pixel data.</param>
	/// <param name="dstPitch">The pitch of the destination pixels, in bytes.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_PremultiplyAlpha")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int PremultiplyAlpha(int width, int height, SDL_PixelFormatEnum srcFormat, [In] byte[] src, int srcPitch, SDL_PixelFormatEnum dstFormat, [In, Out] byte[] dst, int dstPitch);

	/// <summary>
	/// Perform a fast fill of a rectangle with a specific color.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_FillSurfaceRect">documentation</see> for more details.
	/// </remarks>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the drawing target.</param>
	/// <param name="rect">The <see cref="SDL_Rect"/> structure representing the rectangle to fill, or <see cref="nint.Zero""/> to fill the entire surface.</param>
	/// <param name="color">The color to fill with.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_FillSurfaceRect")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int FillSurfaceRect(SDL_Surface* dst, in SDL_Rect rect, uint color);

	/// <summary>
	/// Perform a fast fill of a rectangle with a specific color.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_FillSurfaceRect">documentation</see> for more details.
	/// </remarks>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the drawing target.</param>
	/// <param name="rect">The <see cref="SDL_Rect"/> structure representing the rectangle to fill, or <see cref="nint.Zero"/> to fill the entire surface.</param>
	/// <param name="color">The color to fill with.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_FillSurfaceRect")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int FillSurfaceRect(SDL_Surface* dst, nint rect, uint color);

	/// <summary>
	/// Perform a fast fill of a set of rectangles with a specific color.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_FillSurfaceRects">documentation</see> for more details.
	/// </remarks>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the drawing target.</param>
	/// <param name="rects">An array of <see cref="SDL_Rect"/>s representing the rectangles to fill.</param>
	/// <param name="count">The number of rectangles in the array. Corresponds to <paramref name="rects"/>.Length.</param>
	/// <param name="color">The color to fill with.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_FillSurfaceRects")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int FillSurfaceRects(SDL_Surface* dst, [In] SDL_Rect[] rects, int count, uint color);

	/// <summary>
	/// Performs a fast blit from the source surface to the destination surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_BlitSurface">documentation</see> for more details.
	/// </remarks>
	/// <param name="src">The <see cref="SDL_Surface"/> structure to be copied from.</param>
	/// <param name="srcRect">The <see cref="SDL_Rect"/> structure representing the rectangle to be copied, or <see cref="nint.Zero"/> to copy the entire surface.</param>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the blit target.</param>
	/// <param name="dstRect">The <see cref="SDL_Rect"/> structure representing the x and y position in the destination surface. On input the width and height are ignored (taken from <paramref name="srcRect"/>), and on output this is filled in with the actual rectangle used after clipping.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_BlitSurface")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int BlitSurface(SDL_Surface* src, in SDL_Rect srcRect, SDL_Surface* dst, ref SDL_Rect dstRect);

	/// <summary>
	/// Performs a fast blit from the source surface to the destination surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_BlitSurface">documentation</see> for more details.
	/// </remarks>
	/// <param name="src">The <see cref="SDL_Surface"/> structure to be copied from.</param>
	/// <param name="srcRect">The <see cref="SDL_Rect"/> structure representing the rectangle to be copied, or <see cref="nint.Zero"/> to copy the entire surface.</param>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the blit target.</param>
	/// <param name="dstRect">The <see cref="SDL_Rect"/> structure representing the x and y position in the destination surface. On input the width and height are ignored (taken from <paramref name="srcRect"/>), and on output this is filled in with the actual rectangle used after clipping.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_BlitSurface")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int BlitSurface(SDL_Surface* src, nint srcRect, SDL_Surface* dst, nint dstRect);

	/// <summary>
	/// Perform low-level surface blitting only.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_BlitSurfaceUnchecked">documentation</see> for more details.
	/// </remarks>
	/// <param name="src">The <see cref="SDL_Surface"/> structure to be copied from.</param>
	/// <param name="srcRect">The <see cref="SDL_Rect"/> structure representing the rectangle to be copied, or <see cref="nint.Zero"/> to copy the entire surface.</param>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the blit target.</param>
	/// <param name="dstRect">The <see cref="SDL_Rect"/> structure representing the x and y position in the destination surface.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_BlitSurfaceUnchecked")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int BlitSurfaceUnchecked(SDL_Surface* src, in SDL_Rect srcRect, SDL_Surface* dst, in SDL_Rect dstRect);

	/// <summary>
	/// Perform low-level surface blitting only.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_BlitSurfaceUnchecked">documentation</see> for more details.
	/// </remarks>
	/// <param name="src">The <see cref="SDL_Surface"/> structure to be copied from.</param>
	/// <param name="srcRect">The <see cref="SDL_Rect"/> structure representing the rectangle to be copied, or <see cref="nint.Zero"/> to copy the entire surface.</param>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the blit target.</param>
	/// <param name="dstRect">The <see cref="SDL_Rect"/> structure representing the x and y position in the destination surface.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_BlitSurfaceUnchecked")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int BlitSurfaceUnchecked(SDL_Surface* src, nint srcRect, SDL_Surface* dst, nint dstRect);

	/// <summary>
	/// Perform stretch blit between two surfaces of the same format.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_SoftStretch">documentation</see> for more details.
	/// </remarks>
	/// <param name="src">The <see cref="SDL_Surface"/> structure to be copied from.</param>
	/// <param name="srcRect">The <see cref="SDL_Rect"/> structure representing the rectangle to be copied.</param>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the blit target.</param>
	/// <param name="dstRect">The <see cref="SDL_Rect"/> structure representing the target rectangle in the destination surface.</param>
	/// <param name="scaleMode">Scale algorithm to be used.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_SoftStretch")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SoftStretch(SDL_Surface* src, in SDL_Rect srcRect, SDL_Surface* dst, in SDL_Rect dstRect, SDL_ScaleMode scaleMode);

	/// <summary>
	/// Perform a scaled blit to a destination surface, which may be of a different format.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_BlitSurfaceScaled">documentation</see> for more details.
	/// </remarks>
	/// <param name="src">The <see cref="SDL_Surface"/> structure to be copied from.</param>
	/// <param name="srcRect">The <see cref="SDL_Rect"/> structure representing the rectangle to be copied.</param>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the blit target.</param>
	/// <param name="dstRect">The <see cref="SDL_Rect"/> structure representing the target rectangle in the destination surface, filled with the actual rectangle used after clipping.</param>
	/// <param name="scaleMode">The <see cref="SDL_ScaleMode"/> to be used.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_BlitSurfaceScaled")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int BlitSurfaceScaled(SDL_Surface* src, in SDL_Rect srcRect, SDL_Surface* dst, ref SDL_Rect dstRect, SDL_ScaleMode scaleMode);

	/// <summary>
	/// Perform low-level surface scaled blitting only.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_BlitSurfaceUncheckedScaled">documentation</see> for more details.
	/// </remarks>
	/// <param name="src">The <see cref="SDL_Surface"/> structure to be copied from.</param>
	/// <param name="srcRect">The <see cref="SDL_Rect"/> structure representing the rectangle to be copied.</param>
	/// <param name="dst">The <see cref="SDL_Surface"/> structure that is the blit target.</param>
	/// <param name="dstRect">The <see cref="SDL_Rect"/> structure representing the target rectangle in the destination surface.</param>
	/// <param name="scaleMode">Scale algorithm to be used.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_BlitSurfaceUncheckedScaled")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int BlitSurfaceUncheckedScaled(SDL_Surface* src, in SDL_Rect srcRect, SDL_Surface* dst, in SDL_Rect dstRect, SDL_ScaleMode scaleMode);

	/// <summary>
	/// Retrieves a single pixel from a surface.
	/// </summary>
	/// <remarks>
	/// Refer to the official <see href="https://wiki.libsdl.org/SDL3/SDL_ReadSurfacePixel">documentation</see> for more details.
	/// </remarks>
	/// <param name="surface">The surface to read.</param>
	/// <param name="x">The horizontal coordinate, 0 &lt;= x &lt; width.</param>
	/// <param name="y">The vertical coordinate, 0 &lt;= y &lt; height.</param>
	/// <param name="r">A pointer filled in with the red channel, 0-255.</param>
	/// <param name="g">A pointer filled in with the green channel, 0-255.</param>
	/// <param name="b">A pointer filled in with the blue channel, 0-255.</param>
	/// <param name="a">A pointer filled in with the alpha channel, 0-255.</param>
	/// <returns>0 on success or a negative error code on failure; call <see cref="GetError"/> for more information.</returns>
	[LibraryImport(LibraryName, EntryPoint = "SDL_ReadSurfacePixel")]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int ReadSurfacePixel(SDL_Surface* surface, int x, int y, out byte r, out byte g, out byte b, out byte a);
}