﻿using Objects;
using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// Resets the transform's position and rotation.
    /// </summary>
    /// <param name="transform">The transform to reset.</param>
    /// <param name="resetPosition">Whether to reset the position.</param>
    /// <param name="resetRotation">Whether to reset the rotation.</param>
    public static void Reset(this Transform transform,
        bool resetPosition = true,
        bool resetRotation = false)
    {
        if (resetPosition) transform.position = Vector3.zero;

        if (resetRotation) transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// Returns true if the collider is a player.
    /// </summary>
    /// <param name="collider">The collider to check.</param>
    public static bool IsPlayer(this Collider collider)
        => collider.CompareTag("Player") || collider.gameObject.CompareLayer("Player");

    /// <summary>
    /// Returns true if the collision is a player.
    /// </summary>
    /// <param name="collision">The collision to check.</param>
    public static bool IsPlayer(this Collision collision)
        => collision.gameObject.CompareTag("Player") || collision.gameObject.CompareLayer("Player");

    /// <summary>
    /// Returns true if the game object's layer matches the layer name.
    /// </summary>
    /// <param name="gameObject">The game object to check.</param>
    /// <param name="layerName">The layer name to compare.</param>
    /// <returns>true or false.</returns>
    public static bool CompareLayer(this GameObject gameObject, string layerName)
        => gameObject.layer == LayerMask.NameToLayer(layerName);
    
    /// <summary>
    /// Configures the audio source with the audio data.
    /// </summary>
    /// <param name="audioSource">The audio source to configure.</param>
    /// <param name="audioData">The audio data to use.</param>
    public static void Configure(this AudioSource audioSource, AudioData audioData)
    {
        audioSource.clip = audioData.clip;
        audioSource.outputAudioMixerGroup = audioData.mixerGroup;
        audioSource.playOnAwake = audioData.playOnAwake;
        audioSource.loop = audioData.loop;
        audioSource.volume = audioData.volume;
        audioSource.spatialize = audioData.spatialize;
    }
    
    /// <summary>
    /// Configures the audio source with the audio data and plays it.
    /// </summary>
    /// <param name="audioSource">The audio source to configure.</param>
    /// <param name="audioData">The audio data to use.</param>
    public static void ConfigureAndPlay(this AudioSource audioSource, AudioData audioData)
    {
        audioSource.Configure(audioData);
        audioSource.Play();
    }
}